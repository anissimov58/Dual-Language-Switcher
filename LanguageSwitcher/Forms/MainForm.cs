using System.Runtime.InteropServices;
using System.Text;
using KeyBoardHook;
using LanguageSwitcher.Helpers;
using LanguageSwitcher.Data;
using LanguageSwitcher.Settings;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Windows.Forms;

namespace LanguageSwitcher
{
    public partial class MainForm : Form
    {
        //WIN API imports
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint idThread);
        [DllImport("user32.dll")]
        private static extern IntPtr ActivateKeyboardLayout(IntPtr hkl, uint flags);
        [DllImport("user32.dll")]
        private static extern int GetKeyboardLayoutNameA([Out] StringBuilder pwszKLID);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);


        //keys that are beeing listend to
        private static List<KeyboardHook.VKeys> activeKeys = new List<KeyboardHook.VKeys>();    //keys that are beeing listend to
        private static List<KeyboardHook.VKeys> pressedKeys = new List<KeyboardHook.VKeys>();   //keys that has been pressed, but not released

        private static List<InputLanguage> inputLanguages = new List<InputLanguage>();          //list of all the input Languages on this current machine

        private static int ToggleValue;             //value of Registry Key "HKEY_CURRENT_USER\Keyboard Layout\Toggle\Language Hotkey"

        private static KeyboardHook keyboardHook = new KeyboardHook();  //Keyboard Hook

        private static bool IsRunning = false;      //If we capturing keyboard presses - true, else false;

        public MainForm()
        {
            InitializeComponent();

            //Init GUI elements
            InitGUI();



        }

        private void InitGUI()
        {
            //Populate language selectors
            InitLanguageSelectors();

            //Select correct layout switching method based on current user settings
            InitSwitchingMethodSelectors();
        }

        private void InitSwitchingMethodSelectors()
        {
            //int ToggleValue;
            if (Settings.MySettings.Default.Language_Toggle == -1 || MySettings.Default.Language_Toggle > 3)
            {
                ToggleValue = RegistryHelper.Get_Language_Toggle_Value();
            }
            else
            {
                ToggleValue = MySettings.Default.Language_Toggle;
            }

            switch (ToggleValue)
            {
                case (int)MyConstants.LANGTOGGLE_VALUES.ALT_SHIFT:
                    radioButtonAltShift.Checked = true;
                    break;

                case (int)MyConstants.LANGTOGGLE_VALUES.CTRL_SHIFT:
                    radioButtonAltShift.Checked = false;
                    break;

                default:
                    radioButtonAltShift.Checked = true;
                    break;
            }
            radioButtonCtrlShift.Checked = !radioButtonAltShift.Checked;
        }

        private void InitLanguageSelectors()
        {
            //Get Enabled Languages;
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                inputLanguages.Add(lang);
            }

            //check for out of bounds
            if (inputLanguages.Count < 2)
            {
                MessageBox.Show("Error, app won't work, if there is only 1 layout enabled. Please enable additional layouts and try again. Thank you. Closing the app now.");
                this.Close();
            }
            foreach (var language in inputLanguages)
            {
                Language1Selector.Items.Add(language.LayoutName);
                Language2Selector.Items.Add(language.LayoutName);
            }

            //Then, lets check Settings and get previously selected languages
            if (MySettings.Default.LanguageIndex1 == -1 && MySettings.Default.LanguageIndex2 == -1)
            {
                //this means that we have not setup app just yet.
                //Select first and second languages.
                Language1Selector.SelectedIndex = 0;
                Language2Selector.SelectedIndex = 1;
            }
            else
            {
                //App has been ran before, simply apply settings and hide window.
                //  Hide the form from the taskbar
                this.Visible = false;


                //bounds checking and assigning values
                //Second goes first, so that after checking - they will be in accending order
                if (MySettings.Default.LanguageIndex2 > 0 && MySettings.Default.LanguageIndex2 < inputLanguages.Count)
                {
                    Language2Selector.SelectedIndex = MySettings.Default.LanguageIndex2;
                }
                else
                {
                    Language2Selector.SelectedIndex = 1;
                }

                if (MySettings.Default.LanguageIndex1 > 0 && MySettings.Default.LanguageIndex1 < inputLanguages.Count)
                {
                    Language1Selector.SelectedIndex = MySettings.Default.LanguageIndex1;
                }
                else
                {
                    Language1Selector.SelectedIndex = 0;
                }
            }
        }

        private void InitKeyboardHook()
        {

            if (IsRunning)
                return; //if for some reason this happened - there is a bug and we heed to fix it, but just to be safe, we disable adding new hooks on top of existing ones 

            //create hook
            keyboardHook = new KeyboardHook();

            //Wiring up what to do
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(KeyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyboardHook.KeyboardHookCallback(KeyboardHook_KeyUp);

            //Populate activeKeys based of toggleValue
            switch (ToggleValue)
            {
                case (int)MyConstants.LANGTOGGLE_VALUES.CTRL_SHIFT:
                    SetUpToggleForCtrlShift();
                    break;

                case (int)MyConstants.LANGTOGGLE_VALUES.ALT_SHIFT:
                    SetUpToggleForAltShift();
                    break;
                default: //if NONE or any other value
                    //then set it to ALT+SHIFT because 95% users use Alt+Shift
                    SetUpToggleForAltShift();
                    break;
            }

            //Installing the Keyboard Hooks
            keyboardHook.Install();

            IsRunning = true;

            // disable built-in Keyboard toggle switcher to avoid interference and double-switching
            RegistryHelper.Set_Language_Toggle_Value((int)MyConstants.LANGTOGGLE_VALUES.NONE);

            UpdateAndSaveSettings();

        }

        private void UpdateAndSaveSettings()
        {
            //saving settings so that we can reapply them later
            MySettings.Default.LanguageIndex1 = Language1Selector.SelectedIndex;
            MySettings.Default.LanguageIndex2 = Language2Selector.SelectedIndex;
            MySettings.Default.Language_Toggle = ToggleValue;

            //Saving Settings
            MySettings.Default.Save();
        }

        private void RemoveKeyboardHook()
        {
            //We heed to restore build-in keyboard toggle
            RegistryHelper.Set_Language_Toggle_Value(ToggleValue);

            //now lets uninstall our hook
            keyboardHook.Uninstall();
            //Done
        }

        private static void SetUpToggleForAltShift()
        {
            //clearing list (just in case)
            activeKeys.Clear();

            //adding keys to listen to
            //left pair
            activeKeys.Add(KeyboardHook.VKeys.LSHIFT);
            activeKeys.Add(KeyboardHook.VKeys.LMENU);

            //right pair
            activeKeys.Add(KeyboardHook.VKeys.RSHIFT);
            activeKeys.Add(KeyboardHook.VKeys.RMENU);
        }

        private static void SetUpToggleForCtrlShift()
        {
            //clearing list (just in case)
            activeKeys.Clear();

            //adding keys to listen to
            //left pair
            activeKeys.Add(KeyboardHook.VKeys.LCONTROL);
            activeKeys.Add(KeyboardHook.VKeys.LSHIFT);

            //right pair
            activeKeys.Add(KeyboardHook.VKeys.RCONTROL);
            activeKeys.Add(KeyboardHook.VKeys.RSHIFT);
        }

        private static void KeyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            pressedKeys.Remove(key);
        }

        private static void KeyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if (activeKeys.Contains(key) && !pressedKeys.Contains(key))
            {
                pressedKeys.Add(key);

                //now we need to check, if combination of Left pairs (indixes of 0 and 1) or right pairs (indixes of 2 and 3) have been pressed
                if ((pressedKeys.Contains(activeKeys[0]) && pressedKeys.Contains(activeKeys[1]))
                || (pressedKeys.Contains(activeKeys[2]) && pressedKeys.Contains(activeKeys[3])))
                {

                    IntPtr hkl = GetKeyboardLayout(0x00000000);

                    //Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "]Prepearing to change layout. Current handle is:" + hkl);
                    //0x04190419 �������
                    //0x04090409 English
                    //0xf03d040d Hebrew

                    int i = hkl == inputLanguages[0].Handle ? 1 : 0;

                    //convert 0xXXXXYYYY => 0000YYYY
                    IntPtr handle = inputLanguages[i].Handle;
                    string kblID = "0000" + handle.ToString("X").Substring(3);

                    IntPtr result;


                    //Load, then Activate, Then Apply KeyboardLayout
                    result = LoadKeyboardLayout(kblID, 0x00000003); // KLF_ACTIVATE && KLF_SUBSTITUTE_OK
                    if (result == IntPtr.Zero)
                    {
                        int error = Marshal.GetLastWin32Error();
                        MessageBox.Show("We have an error in LoadKeyboardLayout. error code:" + error);
                        return;
                    }

                    result = ActivateKeyboardLayout(handle, 0);
                    if (result == IntPtr.Zero)
                    {
                        int error = Marshal.GetLastWin32Error();
                        MessageBox.Show("We have an error in ActivateKeyboardLayout. error code:" + error);
                        return;
                    }

                    result = SendMessage(MyConstants.HWND_BROADCAST, MyConstants.WM_INPUTLANGCHANGEREQUEST, IntPtr.Zero, handle);
                    if (result == IntPtr.Zero)
                    {
                        int error = Marshal.GetLastWin32Error();
                        MessageBox.Show("We have an error in WM_INPUTLANGCHANGEREQUEST. error code:" + error);
                        return;
                    }

                    //Console.WriteLine("Layout changed ! ==========================================================");

                    return;
                }
            }
        }

        private void Language1Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Language1Selector.SelectedIndex == Language2Selector.SelectedIndex)
            {
                if (Language2Selector.SelectedIndex == Language2Selector.Items.Count - 1)
                {
                    Language2Selector.SelectedIndex = 0;
                }
                else
                {
                    Language2Selector.SelectedIndex = Language2Selector.SelectedIndex + 1;
                }
            }
        }

        private void Language2Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Language1Selector.SelectedIndex == Language2Selector.SelectedIndex)
            {
                if (Language1Selector.SelectedIndex == Language1Selector.Items.Count - 1)
                {
                    Language1Selector.SelectedIndex = 0;
                }
                else
                {
                    Language1Selector.SelectedIndex = Language1Selector.SelectedIndex + 1;
                }
            }
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                InitKeyboardHook();
                buttonStartStop.Text = "Enabled. Running.";
                IsRunning = true;
            }
            else
            {
                RemoveKeyboardHook();
                buttonStartStop.Text = "Stopped. Press to start.";
                IsRunning = false;
            }

        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;  // Cancel the close operation
                this.Hide();      // Hide the form instead of closing it
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Show the main form when the user double-clicks the system tray icon
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }


        private void CloseApplication()
        {
            RemoveKeyboardHook();
            
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the main form when the user double-clicks the system tray icon
            this.Visible = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}