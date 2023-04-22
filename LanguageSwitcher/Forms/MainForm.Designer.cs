namespace LanguageSwitcher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            notifyIcon1 = new NotifyIcon(components);
            Language1Selector = new ComboBox();
            Language2Selector = new ComboBox();
            radioButtonDefault = new RadioButton();
            radioButtonCtrlShift = new RadioButton();
            radioButtonAltShift = new RadioButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonStartStop = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // Language1Selector
            // 
            Language1Selector.DropDownStyle = ComboBoxStyle.DropDownList;
            Language1Selector.FormattingEnabled = true;
            Language1Selector.Location = new Point(13, 13);
            Language1Selector.Margin = new Padding(4);
            Language1Selector.Name = "Language1Selector";
            Language1Selector.Size = new Size(240, 28);
            Language1Selector.TabIndex = 0;
            Language1Selector.SelectedIndexChanged += Language1Selector_SelectedIndexChanged;
            // 
            // Language2Selector
            // 
            Language2Selector.DropDownStyle = ComboBoxStyle.DropDownList;
            Language2Selector.FormattingEnabled = true;
            Language2Selector.Location = new Point(78, 109);
            Language2Selector.Margin = new Padding(4);
            Language2Selector.Name = "Language2Selector";
            Language2Selector.Size = new Size(240, 28);
            Language2Selector.TabIndex = 1;
            // 
            // radioButtonDefault
            // 
            radioButtonDefault.AutoSize = true;
            radioButtonDefault.Checked = true;
            radioButtonDefault.Location = new Point(214, 15);
            radioButtonDefault.Margin = new Padding(2);
            radioButtonDefault.Name = "radioButtonDefault";
            radioButtonDefault.Size = new Size(76, 24);
            radioButtonDefault.TabIndex = 2;
            radioButtonDefault.TabStop = true;
            radioButtonDefault.Text = "Default";
            radioButtonDefault.UseVisualStyleBackColor = true;
            radioButtonDefault.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButtonCtrlShift
            // 
            radioButtonCtrlShift.AutoSize = true;
            radioButtonCtrlShift.Location = new Point(112, 15);
            radioButtonCtrlShift.Margin = new Padding(2);
            radioButtonCtrlShift.Name = "radioButtonCtrlShift";
            radioButtonCtrlShift.Size = new Size(98, 24);
            radioButtonCtrlShift.TabIndex = 3;
            radioButtonCtrlShift.Text = "Ctrl + Shift";
            radioButtonCtrlShift.UseVisualStyleBackColor = true;
            // 
            // radioButtonAltShift
            // 
            radioButtonAltShift.AutoSize = true;
            radioButtonAltShift.Location = new Point(14, 15);
            radioButtonAltShift.Margin = new Padding(2);
            radioButtonAltShift.Name = "radioButtonAltShift";
            radioButtonAltShift.Size = new Size(94, 24);
            radioButtonAltShift.TabIndex = 4;
            radioButtonAltShift.Text = "Alt + Shift";
            radioButtonAltShift.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radioButtonAltShift);
            flowLayoutPanel1.Controls.Add(radioButtonCtrlShift);
            flowLayoutPanel1.Controls.Add(radioButtonDefault);
            flowLayoutPanel1.Location = new Point(13, 49);
            flowLayoutPanel1.Margin = new Padding(2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(12, 13, 12, 13);
            flowLayoutPanel1.Size = new Size(305, 54);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // buttonStartStop
            // 
            buttonStartStop.Location = new Point(13, 145);
            buttonStartStop.Margin = new Padding(4);
            buttonStartStop.Name = "buttonStartStop";
            buttonStartStop.Size = new Size(305, 38);
            buttonStartStop.TabIndex = 7;
            buttonStartStop.Text = "Enable";
            buttonStartStop.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 196);
            Controls.Add(buttonStartStop);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(Language2Selector);
            Controls.Add(Language1Selector);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            ShowInTaskbar = false;
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ComboBox Language1Selector;
        private ComboBox Language2Selector;
        private RadioButton radioButtonDefault;
        private RadioButton radioButtonCtrlShift;
        private RadioButton radioButtonAltShift;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonStartStop;
    }
}