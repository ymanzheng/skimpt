
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mainProgramMessage = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.saveFileSettingBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileLocationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ftpDirTxtBox = new System.Windows.Forms.TextBox();
            this.ftpPortTxtBox = new System.Windows.Forms.TextBox();
            this.ftpPassTxtBox = new System.Windows.Forms.TextBox();
            this.ftpUserTxtBox = new System.Windows.Forms.TextBox();
            this.ftpSettingsBtn = new System.Windows.Forms.Button();
            this.ftptestConnectionbutton = new System.Windows.Forms.Button();
            this.ftpHostTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.shortcut1 = new MCLHotkey.SystemWideHotkeyComponent(this.components);
            this.systemWideHotkeyComponent2 = new MCLHotkey.SystemWideHotkeyComponent(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(96, 26);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(487, 261);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.mainProgramMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(479, 227);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.ToolTipText = "Main screen";
            // 
            // mainProgramMessage
            // 
            this.mainProgramMessage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainProgramMessage.ForeColor = System.Drawing.Color.Green;
            this.mainProgramMessage.Location = new System.Drawing.Point(8, 19);
            this.mainProgramMessage.Multiline = true;
            this.mainProgramMessage.Name = "mainProgramMessage";
            this.mainProgramMessage.Size = new System.Drawing.Size(463, 48);
            this.mainProgramMessage.TabIndex = 0;
            this.mainProgramMessage.Text = "Program messages will be displayed here";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.saveFileSettingBtn);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.radioButton2);
            this.tabPage2.Controls.Add(this.radioButton1);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(479, 227);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File";
            this.tabPage2.ToolTipText = "change file settings including save path";
            // 
            // saveFileSettingBtn
            // 
            this.saveFileSettingBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveFileSettingBtn.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFileSettingBtn.ForeColor = System.Drawing.Color.DarkGreen;
            this.saveFileSettingBtn.Location = new System.Drawing.Point(133, 177);
            this.saveFileSettingBtn.Name = "saveFileSettingBtn";
            this.saveFileSettingBtn.Size = new System.Drawing.Size(221, 42);
            this.saveFileSettingBtn.TabIndex = 4;
            this.saveFileSettingBtn.Text = "Save File Settings";
            this.saveFileSettingBtn.UseVisualStyleBackColor = false;
            this.saveFileSettingBtn.Click += new System.EventHandler(this.saveFileSettingBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fileLocationTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 90);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Location";
            // 
            // fileLocationTextBox
            // 
            this.fileLocationTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLocationTextBox.Location = new System.Drawing.Point(17, 50);
            this.fileLocationTextBox.Name = "fileLocationTextBox";
            this.fileLocationTextBox.Size = new System.Drawing.Size(426, 27);
            this.fileLocationTextBox.TabIndex = 1;
            this.fileLocationTextBox.Text = "enter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save my file to this location:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(25, 46);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(213, 23);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Allow me to specify each file";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(185, 23);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Randomly name my files";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage3.Controls.Add(this.ftpDirTxtBox);
            this.tabPage3.Controls.Add(this.ftpPortTxtBox);
            this.tabPage3.Controls.Add(this.ftpPassTxtBox);
            this.tabPage3.Controls.Add(this.ftpUserTxtBox);
            this.tabPage3.Controls.Add(this.ftpSettingsBtn);
            this.tabPage3.Controls.Add(this.ftptestConnectionbutton);
            this.tabPage3.Controls.Add(this.ftpHostTxtBox);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(479, 227);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Upload";
            this.tabPage3.ToolTipText = "Set upload settings to remote server";
            // 
            // ftpDirTxtBox
            // 
            this.ftpDirTxtBox.Location = new System.Drawing.Point(163, 140);
            this.ftpDirTxtBox.Name = "ftpDirTxtBox";
            this.ftpDirTxtBox.Size = new System.Drawing.Size(307, 27);
            this.ftpDirTxtBox.TabIndex = 11;
            // 
            // ftpPortTxtBox
            // 
            this.ftpPortTxtBox.Location = new System.Drawing.Point(163, 107);
            this.ftpPortTxtBox.Name = "ftpPortTxtBox";
            this.ftpPortTxtBox.Size = new System.Drawing.Size(307, 27);
            this.ftpPortTxtBox.TabIndex = 10;
            this.ftpPortTxtBox.Text = "21";
            // 
            // ftpPassTxtBox
            // 
            this.ftpPassTxtBox.Location = new System.Drawing.Point(163, 74);
            this.ftpPassTxtBox.Name = "ftpPassTxtBox";
            this.ftpPassTxtBox.Size = new System.Drawing.Size(307, 27);
            this.ftpPassTxtBox.TabIndex = 9;
            this.ftpPassTxtBox.UseSystemPasswordChar = true;
            // 
            // ftpUserTxtBox
            // 
            this.ftpUserTxtBox.Location = new System.Drawing.Point(163, 41);
            this.ftpUserTxtBox.Name = "ftpUserTxtBox";
            this.ftpUserTxtBox.Size = new System.Drawing.Size(307, 27);
            this.ftpUserTxtBox.TabIndex = 8;
            // 
            // ftpSettingsBtn
            // 
            this.ftpSettingsBtn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ftpSettingsBtn.Location = new System.Drawing.Point(325, 173);
            this.ftpSettingsBtn.Name = "ftpSettingsBtn";
            this.ftpSettingsBtn.Size = new System.Drawing.Size(145, 37);
            this.ftpSettingsBtn.TabIndex = 7;
            this.ftpSettingsBtn.Text = "save settings";
            this.ftpSettingsBtn.UseVisualStyleBackColor = true;
            this.ftpSettingsBtn.Click += new System.EventHandler(this.ftpSettingsBtn_Click_1);
            // 
            // ftptestConnectionbutton
            // 
            this.ftptestConnectionbutton.Location = new System.Drawing.Point(174, 173);
            this.ftptestConnectionbutton.Name = "ftptestConnectionbutton";
            this.ftptestConnectionbutton.Size = new System.Drawing.Size(145, 37);
            this.ftptestConnectionbutton.TabIndex = 6;
            this.ftptestConnectionbutton.Text = "test connection";
            this.ftptestConnectionbutton.UseVisualStyleBackColor = true;
            this.ftptestConnectionbutton.Click += new System.EventHandler(this.ftptestConnectionbutton_Click);
            // 
            // ftpHostTxtBox
            // 
            this.ftpHostTxtBox.Location = new System.Drawing.Point(163, 11);
            this.ftpHostTxtBox.Name = "ftpHostTxtBox";
            this.ftpHostTxtBox.Size = new System.Drawing.Size(307, 27);
            this.ftpHostTxtBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Initial Directory (./)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Remote Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Remote Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Remote Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Remote Host Name:";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(479, 227);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Settings";
            this.tabPage4.ToolTipText = "Set global application settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 30);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(479, 227);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Log";
            this.tabPage5.ToolTipText = "Check log files";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // shortcut1
            // 
            this.shortcut1.HotkeyCombination = "SHIFT+U";
            this.shortcut1.HotkeyPressed += new System.EventHandler(this.shortcut1_HotkeyPressed);
            // 
            // systemWideHotkeyComponent2
            // 
            this.systemWideHotkeyComponent2.HotkeyCombination = "SHIFT+P";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(487, 261);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Skimpt v 1.01";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private MCLHotkey.SystemWideHotkeyComponent shortcut1;
        private MCLHotkey.SystemWideHotkeyComponent systemWideHotkeyComponent2;
        private System.Windows.Forms.Button saveFileSettingBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fileLocationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.TextBox mainProgramMessage;
        private System.Windows.Forms.TextBox ftpHostTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ftpDirTxtBox;
        private System.Windows.Forms.TextBox ftpPortTxtBox;
        private System.Windows.Forms.TextBox ftpPassTxtBox;
        private System.Windows.Forms.TextBox ftpUserTxtBox;
        private System.Windows.Forms.Button ftpSettingsBtn;
        private System.Windows.Forms.Button ftptestConnectionbutton;

    }
