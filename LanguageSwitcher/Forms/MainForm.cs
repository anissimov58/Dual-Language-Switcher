using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;
using KeyBoardHook;
using LanguageSwitcher.Helpers;
using LanguageSwitcher.Data;
using System.Runtime.ExceptionServices;
using LanguageSwitcher.Settings;

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

        private static int Registry_Language_Toggle_Value_OnStartup;
        private static KeyboardHook? keyboardHook;


        public MainForm()
        {



            InitializeComponent();


            //read user values and save them
            Init();


        }

        private void Init()
        {
            //Setup proccess

            //Save current user settings
            SaveLanguageToggleSetting();
            //Get all enabled languages and place them into inputLanguages
            GetEnabledLanguages();

            InitGUI();

            ////Init Hook
            //InitKeyboardHook();

            //switch (Registry_Language_Toggle_Value_OnStartup)
            //{
            //    case (int)MyConstants.LANGTOGGLE_VALUES.CTRL_SHIFT:
            //        SetUpToggleForCtrlShift();
            //        break;

            //    case (int)MyConstants.LANGTOGGLE_VALUES.ALT_SHIFT:
            //        SetUpToggleForAltShift();
            //        break;
            //    default: //if NONE or any other value
            //        //then set it to ALT+SHIFT because 99.9% uses ALT+Shift
            //        SetUpToggleForAltShift();
            //        break;
            //}
        }

        private void InitGUI()
        {
            //Populate language selectors

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

            //Then, lets check Settings.
            if (MySettings.Default.LanguageIndex1 == 0 && MySettings.Default.LanguageIndex2 == 0)
            {
                //this means that we have not setup app just yet.

                //Select first and second languages.

                Language1Selector.SelectedIndex = 0;
                Language2Selector.SelectedIndex = 1;
            }



        }

        private void GetEnabledLanguages()
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                inputLanguages.Add(lang);
            }
        }

        private static void InitKeyboardHook()
        {
            //create hook
            keyboardHook = new KeyboardHook();

            //Wiring up what to do
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(KeyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyboardHook.KeyboardHookCallback(KeyboardHook_KeyUp);
        }

        private void SaveLanguageToggleSetting()
        {
            //read Language Toggle value from registry
            Registry_Language_Toggle_Value_OnStartup = RegistryHelper.Get_Language_Toggle_Value();
            Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] Reading Lang Toggle is " + Registry_Language_Toggle_Value_OnStartup + " which is :" + Enum.GetName(typeof(MyConstants.LANGTOGGLE_VALUES), Registry_Language_Toggle_Value_OnStartup));
        }

        private static void SetUpToggleForAltShift()
        {
            //disable Build-in toggles
            RegistryHelper.Set_Language_Toggle_Value((int)MyConstants.LANGTOGGLE_VALUES.NONE);

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
            //disable Build-in toggles
            RegistryHelper.Set_Language_Toggle_Value((int)MyConstants.LANGTOGGLE_VALUES.NONE);

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

        private static void KeyboardHook_KeyDown(KeyBoardHook.KeyboardHook.VKeys key)
        {
            //if activeKey and is not pressed yet



            if (activeKeys.Contains(key) && !pressedKeys.Contains(key))
            {
                pressedKeys.Add(key);

                //now we need to check, if combination of Left pairs (indixes of 0 and 1) or right pairs (indixes of 2 and 3) have been pressed
                if ((pressedKeys.Contains(activeKeys[0]) && pressedKeys.Contains(activeKeys[1]))
                || (pressedKeys.Contains(activeKeys[2]) && pressedKeys.Contains(activeKeys[3])))
                {

                    IntPtr hkl = GetKeyboardLayout(0x00000000);

                    Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "]Prepearing to change layout. Current handle is:" + hkl);
                    //0x04190419 Русская
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
                        Console.WriteLine("we have an error in LoadKeyboardLayout. error code:" + error);
                        return;
                    }

                    result = ActivateKeyboardLayout(handle, 0);
                    if (result == IntPtr.Zero)
                    {
                        int error = Marshal.GetLastWin32Error();
                        Console.WriteLine("we have an error in ActivateKeyboardLayout. error code:" + error);
                        return;
                    }

                    result = SendMessage(MyConstants.HWND_BROADCAST, MyConstants.WM_INPUTLANGCHANGEREQUEST, IntPtr.Zero, handle);
                    if (result == IntPtr.Zero)
                    {
                        int error = Marshal.GetLastWin32Error();
                        Console.WriteLine("we have an error in WM_INPUTLANGCHANGEREQUEST. error code:" + error);
                        return;
                    }

                    Console.WriteLine("Layout changed ! ==========================================================");

                    return;
                }
            }
        }
        //keyboardHook.Uninstall();
        //    RegistryHelper.Set_Language_Toggle_Value(Registry_Language_Toggle_Value_OnStartup);
        //    Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] Lang Toggle Restored to " + Registry_Language_Toggle_Value_OnStartup);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            this.Show();
        }

        private void Language1Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Language2Selector.Items.Clear();

            int selectedIndexInOther = Language1Selector.SelectedIndex;

            for (int i = 0; i < inputLanguages.Count; i++)
            {
                if (i != selectedIndexInOther)
                {
                    Language2Selector.Items.Add(inputLanguages[i].LayoutName);
                }
            }
        }
    }
}