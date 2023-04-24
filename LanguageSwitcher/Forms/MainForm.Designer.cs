namespace LDS
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
            contextMenuStrip1 = new ContextMenuStrip(components);
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            Language1Selector = new ComboBox();
            Language2Selector = new ComboBox();
            radioButtonCtrlShift = new RadioButton();
            radioButtonAltShift = new RadioButton();
            buttonStartStop = new Button();
            panel1 = new Panel();
            checkBoxEnableStartup = new CheckBox();
            radioButtonReturnCtrlShift = new RadioButton();
            radioButtonReturnNone = new RadioButton();
            label1 = new Label();
            radioButtonReturnAltShift = new RadioButton();
            panel2 = new Panel();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Dual Language Switcher";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(103, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
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
            Language2Selector.SelectedIndexChanged += Language2Selector_SelectedIndexChanged;
            // 
            // radioButtonCtrlShift
            // 
            radioButtonCtrlShift.AutoSize = true;
            radioButtonCtrlShift.Location = new Point(75, 28);
            radioButtonCtrlShift.Margin = new Padding(2);
            radioButtonCtrlShift.Name = "radioButtonCtrlShift";
            radioButtonCtrlShift.Size = new Size(98, 24);
            radioButtonCtrlShift.TabIndex = 3;
            radioButtonCtrlShift.Text = "Ctrl + Shift";
            radioButtonCtrlShift.UseVisualStyleBackColor = true;
            radioButtonCtrlShift.CheckedChanged += radioButtonCtrlShift_CheckedChanged;
            // 
            // radioButtonAltShift
            // 
            radioButtonAltShift.AutoSize = true;
            radioButtonAltShift.Location = new Point(2, 2);
            radioButtonAltShift.Margin = new Padding(2);
            radioButtonAltShift.Name = "radioButtonAltShift";
            radioButtonAltShift.Size = new Size(94, 24);
            radioButtonAltShift.TabIndex = 4;
            radioButtonAltShift.Text = "Alt + Shift";
            radioButtonAltShift.UseVisualStyleBackColor = true;
            radioButtonAltShift.CheckedChanged += radioButtonAltShift_CheckedChanged;
            // 
            // buttonStartStop
            // 
            buttonStartStop.Location = new Point(13, 230);
            buttonStartStop.Margin = new Padding(4);
            buttonStartStop.Name = "buttonStartStop";
            buttonStartStop.Size = new Size(305, 38);
            buttonStartStop.TabIndex = 7;
            buttonStartStop.Text = "Enable";
            buttonStartStop.UseVisualStyleBackColor = true;
            buttonStartStop.Click += buttonStartStop_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonAltShift);
            panel1.Controls.Add(radioButtonCtrlShift);
            panel1.Location = new Point(78, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(175, 54);
            panel1.TabIndex = 8;
            // 
            // checkBoxEnableStartup
            // 
            checkBoxEnableStartup.AutoSize = true;
            checkBoxEnableStartup.Location = new Point(78, 144);
            checkBoxEnableStartup.Name = "checkBoxEnableStartup";
            checkBoxEnableStartup.Size = new Size(167, 24);
            checkBoxEnableStartup.TabIndex = 9;
            checkBoxEnableStartup.Text = "Enable at PC Startup ";
            checkBoxEnableStartup.UseVisualStyleBackColor = true;
            checkBoxEnableStartup.CheckedChanged += checkBoxEnableStartup_CheckedChanged;
            // 
            // radioButtonReturnCtrlShift
            // 
            radioButtonReturnCtrlShift.AutoSize = true;
            radioButtonReturnCtrlShift.Location = new Point(103, 3);
            radioButtonReturnCtrlShift.Margin = new Padding(2);
            radioButtonReturnCtrlShift.Name = "radioButtonReturnCtrlShift";
            radioButtonReturnCtrlShift.Size = new Size(98, 24);
            radioButtonReturnCtrlShift.TabIndex = 5;
            radioButtonReturnCtrlShift.Text = "Ctrl + Shift";
            radioButtonReturnCtrlShift.UseVisualStyleBackColor = true;
            radioButtonReturnCtrlShift.CheckedChanged += radioButtonReturnCtrlShift_CheckedChanged;
            // 
            // radioButtonReturnNone
            // 
            radioButtonReturnNone.AutoSize = true;
            radioButtonReturnNone.Location = new Point(210, 3);
            radioButtonReturnNone.Margin = new Padding(2);
            radioButtonReturnNone.Name = "radioButtonReturnNone";
            radioButtonReturnNone.Size = new Size(63, 24);
            radioButtonReturnNone.TabIndex = 10;
            radioButtonReturnNone.Text = "None";
            radioButtonReturnNone.UseVisualStyleBackColor = true;
            radioButtonReturnNone.CheckedChanged += radioButtonReturnNone_CheckedChanged;
            // 
            // label1
            // 
            label1.Location = new Point(13, 171);
            label1.Name = "label1";
            label1.Size = new Size(305, 27);
            label1.TabIndex = 11;
            label1.Text = "When disabled, switch back to:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButtonReturnAltShift
            // 
            radioButtonReturnAltShift.AutoSize = true;
            radioButtonReturnAltShift.Location = new Point(7, 3);
            radioButtonReturnAltShift.Margin = new Padding(2);
            radioButtonReturnAltShift.Name = "radioButtonReturnAltShift";
            radioButtonReturnAltShift.Size = new Size(94, 24);
            radioButtonReturnAltShift.TabIndex = 5;
            radioButtonReturnAltShift.Text = "Alt + Shift";
            radioButtonReturnAltShift.UseVisualStyleBackColor = true;
            radioButtonReturnAltShift.CheckedChanged += radioButtonReturnAltShift_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(radioButtonReturnAltShift);
            panel2.Controls.Add(radioButtonReturnCtrlShift);
            panel2.Controls.Add(radioButtonReturnNone);
            panel2.Location = new Point(13, 192);
            panel2.Name = "panel2";
            panel2.Size = new Size(305, 31);
            panel2.TabIndex = 12;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 281);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(checkBoxEnableStartup);
            Controls.Add(panel1);
            Controls.Add(buttonStartStop);
            Controls.Add(Language2Selector);
            Controls.Add(Language1Selector);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(347, 320);
            MinimumSize = new Size(347, 264);
            Name = "MainForm";
            RightToLeft = RightToLeft.No;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "DLS - Dual Language Switcher";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ComboBox Language1Selector;
        private ComboBox Language2Selector;
        private RadioButton radioButtonCtrlShift;
        private RadioButton radioButtonAltShift;
        private Button buttonStartStop;
        private Panel panel1;
        private CheckBox checkBoxEnableStartup;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private RadioButton radioButtonReturnCtrlShift;
        private RadioButton radioButtonReturnNone;
        private Label label1;
        private RadioButton radioButtonReturnAltShift;
        private Panel panel2;
    }
}