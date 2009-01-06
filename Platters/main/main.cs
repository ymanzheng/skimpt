#region "License Agreement"
/* Skimpt, an open source screenshot utility.
      Copyright (C) <year>  <name of author>

      This program is free software: you can redistribute it and/or modify
      it under the terms of the GNU General Public License as published by
      the Free Software Foundation, either version 3 of the License, or
      (at your option) any later version.

      this program is distributed in the hope that it will be useful,
      but WITHOUT ANY WARRANTY; without even the implied warranty of
      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      GNU General Public License for more details.

      You should have received a copy of the GNU General Public License
      along with this program.  If not, see <http://www.gnu.org/licenses/>. */
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using Util;
using Microsoft.Win32;
using Microsoft.CSharp;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;



public class main : Form
{
    #region GUI CODE - DO NOT CHANGE
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.exitButton = new System.Windows.Forms.Button();
        this.cameraButton = new SkimptControls.GlassButton();
        this.hightlightButton = new SkimptControls.GlassButton();
        this.updateMessageLink = new System.Windows.Forms.LinkLabel();
        this.updateMessageLabel = new System.Windows.Forms.Label();
        this.unhookButton = new System.Windows.Forms.Button();
        this.mainProgramMessage = new System.Windows.Forms.TextBox();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.browseButton = new System.Windows.Forms.Button();
        this.fileLocationTextBox = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.radioButton2 = new System.Windows.Forms.RadioButton();
        this.radioButton1 = new System.Windows.Forms.RadioButton();
        this.saveFileSettingButton = new SkimptControls.GlassButton();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.saveFtpSettingButton = new SkimptControls.GlassButton();
        this.ftpTestConnButton = new SkimptControls.GlassButton();
        this.ftpDirTxtBox = new System.Windows.Forms.TextBox();
        this.ftpPortTxtBox = new System.Windows.Forms.TextBox();
        this.ftpPassTxtBox = new System.Windows.Forms.TextBox();
        this.ftpUserTxtBox = new System.Windows.Forms.TextBox();
        this.ftpHostTxtBox = new System.Windows.Forms.TextBox();
        this.label6 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.tabPage4 = new System.Windows.Forms.TabPage();
        this.savePSDasFileCheckbox = new System.Windows.Forms.CheckBox();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.removeContextMenuButton = new SkimptControls.GlassButton();
        this.attachContextMenuButton = new SkimptControls.GlassButton();
        this.ShowMessagesCheckbox = new System.Windows.Forms.CheckBox();
        this.HideUponLaunchCheckbox = new System.Windows.Forms.CheckBox();
        this.startOnWindowsLoadCheckBox = new System.Windows.Forms.CheckBox();
        this.saveGlobalSettingButton = new SkimptControls.GlassButton();
        this.tabPage5 = new System.Windows.Forms.TabPage();
        this.fontDialog1 = new System.Windows.Forms.FontDialog();
        this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
        this.notificationIconContext = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.contextStartCamera = new System.Windows.Forms.ToolStripMenuItem();
        this.contextHighlightMode = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.contextShowMenu = new System.Windows.Forms.ToolStripMenuItem();
        this.contextExitMenu = new System.Windows.Forms.ToolStripMenuItem();
        this.tabControl1.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.tabPage3.SuspendLayout();
        this.tabPage4.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.notificationIconContext.SuspendLayout();
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
        this.tabControl1.Size = new System.Drawing.Size(483, 250);
        this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        this.tabControl1.TabIndex = 0;
        // 
        // tabPage1
        // 
        this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        this.tabPage1.Controls.Add(this.exitButton);
        this.tabPage1.Controls.Add(this.cameraButton);
        this.tabPage1.Controls.Add(this.hightlightButton);
        this.tabPage1.Controls.Add(this.updateMessageLink);
        this.tabPage1.Controls.Add(this.updateMessageLabel);
        this.tabPage1.Controls.Add(this.unhookButton);
        this.tabPage1.Controls.Add(this.mainProgramMessage);
        this.tabPage1.Location = new System.Drawing.Point(4, 30);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(475, 216);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "Main";
        this.tabPage1.ToolTipText = "Main screen";
        // 
        // exitButton
        // 
        this.exitButton.Location = new System.Drawing.Point(13, 178);
        this.exitButton.Name = "exitButton";
        this.exitButton.Size = new System.Drawing.Size(88, 31);
        this.exitButton.TabIndex = 5;
        this.exitButton.Text = "Exit Skimpt";
        this.exitButton.UseVisualStyleBackColor = true;
        this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
        // 
        // cameraButton
        // 
        this.cameraButton.BackColor = System.Drawing.Color.DarkViolet;
        this.cameraButton.ForeColor = System.Drawing.Color.Black;
        this.cameraButton.Location = new System.Drawing.Point(12, 73);
        this.cameraButton.Name = "cameraButton";
        this.cameraButton.ShineColor = System.Drawing.Color.Thistle;
        this.cameraButton.Size = new System.Drawing.Size(214, 36);
        this.cameraButton.TabIndex = 6;
        this.cameraButton.Text = "Start Camera Mode";
        this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
        // 
        // hightlightButton
        // 
        this.hightlightButton.BackColor = System.Drawing.Color.SteelBlue;
        this.hightlightButton.Location = new System.Drawing.Point(244, 73);
        this.hightlightButton.Name = "hightlightButton";
        this.hightlightButton.ShineColor = System.Drawing.Color.SkyBlue;
        this.hightlightButton.Size = new System.Drawing.Size(214, 36);
        this.hightlightButton.TabIndex = 5;
        this.hightlightButton.Text = "Start Highlight mode";
        this.hightlightButton.Click += new System.EventHandler(this.hightlightButton_Click);
        // 
        // updateMessageLink
        // 
        this.updateMessageLink.AutoSize = true;
        this.updateMessageLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
        this.updateMessageLink.Location = new System.Drawing.Point(184, 151);
        this.updateMessageLink.Name = "updateMessageLink";
        this.updateMessageLink.Size = new System.Drawing.Size(126, 19);
        this.updateMessageLink.TabIndex = 4;
        this.updateMessageLink.TabStop = true;
        this.updateMessageLink.Text = "Skimpt Homepage";
        this.updateMessageLink.Visible = false;
        this.updateMessageLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateMessageLink_LinkClicked);
        // 
        // updateMessageLabel
        // 
        this.updateMessageLabel.AutoSize = true;
        this.updateMessageLabel.ForeColor = System.Drawing.Color.Red;
        this.updateMessageLabel.Location = new System.Drawing.Point(15, 151);
        this.updateMessageLabel.Name = "updateMessageLabel";
        this.updateMessageLabel.Size = new System.Drawing.Size(173, 19);
        this.updateMessageLabel.TabIndex = 3;
        this.updateMessageLabel.Text = "New Update Available on";
        this.updateMessageLabel.Visible = false;
        // 
        // unhookButton
        // 
        this.unhookButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.unhookButton.Location = new System.Drawing.Point(320, 177);
        this.unhookButton.Name = "unhookButton";
        this.unhookButton.Size = new System.Drawing.Size(149, 33);
        this.unhookButton.TabIndex = 1;
        this.unhookButton.Text = "Unhook Print Screen";
        this.unhookButton.UseVisualStyleBackColor = true;
        this.unhookButton.Click += new System.EventHandler(this.unhookButton_Click);
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
        this.tabPage2.Controls.Add(this.groupBox1);
        this.tabPage2.Controls.Add(this.radioButton2);
        this.tabPage2.Controls.Add(this.radioButton1);
        this.tabPage2.Controls.Add(this.saveFileSettingButton);
        this.tabPage2.Location = new System.Drawing.Point(4, 30);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(475, 216);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "File";
        this.tabPage2.ToolTipText = "change file settings including save path";
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.browseButton);
        this.groupBox1.Controls.Add(this.fileLocationTextBox);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Location = new System.Drawing.Point(6, 74);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(463, 92);
        this.groupBox1.TabIndex = 3;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "File Location";
        // 
        // browseButton
        // 
        this.browseButton.Location = new System.Drawing.Point(416, 49);
        this.browseButton.Name = "browseButton";
        this.browseButton.Size = new System.Drawing.Size(32, 27);
        this.browseButton.TabIndex = 2;
        this.browseButton.Text = "...";
        this.browseButton.UseVisualStyleBackColor = true;
        this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
        // 
        // fileLocationTextBox
        // 
        this.fileLocationTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.fileLocationTextBox.Location = new System.Drawing.Point(17, 50);
        this.fileLocationTextBox.Name = "fileLocationTextBox";
        this.fileLocationTextBox.ReadOnly = true;
        this.fileLocationTextBox.Size = new System.Drawing.Size(393, 27);
        this.fileLocationTextBox.TabIndex = 1;
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
        this.radioButton2.Location = new System.Drawing.Point(26, 45);
        this.radioButton2.Name = "radioButton2";
        this.radioButton2.Size = new System.Drawing.Size(213, 23);
        this.radioButton2.TabIndex = 1;
        this.radioButton2.Text = "Allow me to specify each file";
        this.radioButton2.UseVisualStyleBackColor = true;
        // 
        // radioButton1
        // 
        this.radioButton1.AutoSize = true;
        this.radioButton1.Checked = true;
        this.radioButton1.Location = new System.Drawing.Point(26, 16);
        this.radioButton1.Name = "radioButton1";
        this.radioButton1.Size = new System.Drawing.Size(185, 23);
        this.radioButton1.TabIndex = 0;
        this.radioButton1.TabStop = true;
        this.radioButton1.Text = "Randomly name my files";
        this.radioButton1.UseVisualStyleBackColor = true;
        // 
        // saveFileSettingButton
        // 
        this.saveFileSettingButton.Location = new System.Drawing.Point(155, 172);
        this.saveFileSettingButton.Name = "saveFileSettingButton";
        this.saveFileSettingButton.Size = new System.Drawing.Size(141, 36);
        this.saveFileSettingButton.TabIndex = 5;
        this.saveFileSettingButton.Text = "Save File Settings";
        this.saveFileSettingButton.Click += new System.EventHandler(this.saveFileSettingButton_Click);
        // 
        // tabPage3
        // 
        this.tabPage3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        this.tabPage3.Controls.Add(this.saveFtpSettingButton);
        this.tabPage3.Controls.Add(this.ftpTestConnButton);
        this.tabPage3.Controls.Add(this.ftpDirTxtBox);
        this.tabPage3.Controls.Add(this.ftpPortTxtBox);
        this.tabPage3.Controls.Add(this.ftpPassTxtBox);
        this.tabPage3.Controls.Add(this.ftpUserTxtBox);
        this.tabPage3.Controls.Add(this.ftpHostTxtBox);
        this.tabPage3.Controls.Add(this.label6);
        this.tabPage3.Controls.Add(this.label5);
        this.tabPage3.Controls.Add(this.label4);
        this.tabPage3.Controls.Add(this.label3);
        this.tabPage3.Controls.Add(this.label2);
        this.tabPage3.Location = new System.Drawing.Point(4, 30);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Size = new System.Drawing.Size(475, 216);
        this.tabPage3.TabIndex = 2;
        this.tabPage3.Text = "Upload";
        this.tabPage3.ToolTipText = "Set upload settings to remote server";
        // 
        // saveFtpSettingButton
        // 
        this.saveFtpSettingButton.BackColor = System.Drawing.Color.DarkSlateBlue;
        this.saveFtpSettingButton.Location = new System.Drawing.Point(332, 173);
        this.saveFtpSettingButton.Name = "saveFtpSettingButton";
        this.saveFtpSettingButton.ShineColor = System.Drawing.Color.SlateBlue;
        this.saveFtpSettingButton.Size = new System.Drawing.Size(135, 35);
        this.saveFtpSettingButton.TabIndex = 13;
        this.saveFtpSettingButton.Text = "Save FTP Settings";
        this.saveFtpSettingButton.Click += new System.EventHandler(this.saveFtpSettingButton_Click);
        // 
        // ftpTestConnButton
        // 
        this.ftpTestConnButton.BackColor = System.Drawing.Color.Crimson;
        this.ftpTestConnButton.Location = new System.Drawing.Point(191, 173);
        this.ftpTestConnButton.Name = "ftpTestConnButton";
        this.ftpTestConnButton.ShineColor = System.Drawing.Color.Pink;
        this.ftpTestConnButton.Size = new System.Drawing.Size(135, 35);
        this.ftpTestConnButton.TabIndex = 12;
        this.ftpTestConnButton.Text = "Test Connection";
        this.ftpTestConnButton.Click += new System.EventHandler(this.ftpTestConnButton_Click);
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
        this.tabPage4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        this.tabPage4.Controls.Add(this.savePSDasFileCheckbox);
        this.tabPage4.Controls.Add(this.groupBox2);
        this.tabPage4.Controls.Add(this.ShowMessagesCheckbox);
        this.tabPage4.Controls.Add(this.HideUponLaunchCheckbox);
        this.tabPage4.Controls.Add(this.startOnWindowsLoadCheckBox);
        this.tabPage4.Controls.Add(this.saveGlobalSettingButton);
        this.tabPage4.Location = new System.Drawing.Point(4, 30);
        this.tabPage4.Name = "tabPage4";
        this.tabPage4.Size = new System.Drawing.Size(475, 216);
        this.tabPage4.TabIndex = 3;
        this.tabPage4.Text = "Settings";
        this.tabPage4.ToolTipText = "Set global application settings";
        // 
        // savePSDasFileCheckbox
        // 
        this.savePSDasFileCheckbox.AutoSize = true;
        this.savePSDasFileCheckbox.Location = new System.Drawing.Point(25, 90);
        this.savePSDasFileCheckbox.Name = "savePSDasFileCheckbox";
        this.savePSDasFileCheckbox.Size = new System.Drawing.Size(191, 23);
        this.savePSDasFileCheckbox.TabIndex = 15;
        this.savePSDasFileCheckbox.Text = "Save a JPEG of a PSD file.";
        this.savePSDasFileCheckbox.UseVisualStyleBackColor = true;
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.removeContextMenuButton);
        this.groupBox2.Controls.Add(this.attachContextMenuButton);
        this.groupBox2.Location = new System.Drawing.Point(25, 119);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(428, 62);
        this.groupBox2.TabIndex = 14;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Windows Context Menu";
        // 
        // removeContextMenuButton
        // 
        this.removeContextMenuButton.BackColor = System.Drawing.Color.Crimson;
        this.removeContextMenuButton.Location = new System.Drawing.Point(220, 21);
        this.removeContextMenuButton.Name = "removeContextMenuButton";
        this.removeContextMenuButton.ShineColor = System.Drawing.Color.Pink;
        this.removeContextMenuButton.Size = new System.Drawing.Size(198, 35);
        this.removeContextMenuButton.TabIndex = 14;
        this.removeContextMenuButton.Text = " Remove";
        this.removeContextMenuButton.Click += new System.EventHandler(this.removeContextMenuButton_Click);
        // 
        // attachContextMenuButton
        // 
        this.attachContextMenuButton.BackColor = System.Drawing.Color.Crimson;
        this.attachContextMenuButton.Location = new System.Drawing.Point(16, 21);
        this.attachContextMenuButton.Name = "attachContextMenuButton";
        this.attachContextMenuButton.ShineColor = System.Drawing.Color.Pink;
        this.attachContextMenuButton.Size = new System.Drawing.Size(198, 35);
        this.attachContextMenuButton.TabIndex = 13;
        this.attachContextMenuButton.Text = "Attach ";
        this.attachContextMenuButton.Click += new System.EventHandler(this.attachToWindowsButton_Click);
        // 
        // ShowMessagesCheckbox
        // 
        this.ShowMessagesCheckbox.AutoSize = true;
        this.ShowMessagesCheckbox.Location = new System.Drawing.Point(25, 61);
        this.ShowMessagesCheckbox.Name = "ShowMessagesCheckbox";
        this.ShowMessagesCheckbox.Size = new System.Drawing.Size(306, 23);
        this.ShowMessagesCheckbox.TabIndex = 3;
        this.ShowMessagesCheckbox.Text = "Show program messages in a message box";
        this.ShowMessagesCheckbox.UseVisualStyleBackColor = true;
        // 
        // HideUponLaunchCheckbox
        // 
        this.HideUponLaunchCheckbox.AutoSize = true;
        this.HideUponLaunchCheckbox.Location = new System.Drawing.Point(25, 32);
        this.HideUponLaunchCheckbox.Name = "HideUponLaunchCheckbox";
        this.HideUponLaunchCheckbox.Size = new System.Drawing.Size(284, 23);
        this.HideUponLaunchCheckbox.TabIndex = 1;
        this.HideUponLaunchCheckbox.Text = "Hide instantly upon launch of program. ";
        this.HideUponLaunchCheckbox.UseVisualStyleBackColor = true;
        // 
        // startOnWindowsLoadCheckBox
        // 
        this.startOnWindowsLoadCheckBox.AutoSize = true;
        this.startOnWindowsLoadCheckBox.Location = new System.Drawing.Point(25, 3);
        this.startOnWindowsLoadCheckBox.Name = "startOnWindowsLoadCheckBox";
        this.startOnWindowsLoadCheckBox.Size = new System.Drawing.Size(307, 23);
        this.startOnWindowsLoadCheckBox.TabIndex = 0;
        this.startOnWindowsLoadCheckBox.Text = "Start this program when Windows boots up";
        this.startOnWindowsLoadCheckBox.UseVisualStyleBackColor = true;
        // 
        // saveGlobalSettingButton
        // 
        this.saveGlobalSettingButton.BackColor = System.Drawing.Color.Chocolate;
        this.saveGlobalSettingButton.Location = new System.Drawing.Point(158, 186);
        this.saveGlobalSettingButton.Name = "saveGlobalSettingButton";
        this.saveGlobalSettingButton.OuterBorderColor = System.Drawing.Color.LightSalmon;
        this.saveGlobalSettingButton.Size = new System.Drawing.Size(161, 27);
        this.saveGlobalSettingButton.TabIndex = 6;
        this.saveGlobalSettingButton.Text = "Save Program Settings";
        this.saveGlobalSettingButton.Click += new System.EventHandler(this.saveGlobalSettingButton_Click);
        // 
        // tabPage5
        // 
        this.tabPage5.Location = new System.Drawing.Point(4, 30);
        this.tabPage5.Name = "tabPage5";
        this.tabPage5.Size = new System.Drawing.Size(475, 216);
        this.tabPage5.TabIndex = 4;
        this.tabPage5.Text = "Log";
        this.tabPage5.ToolTipText = "Check log files";
        this.tabPage5.UseVisualStyleBackColor = true;
        // 
        // notifyIcon
        // 
        this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        this.notifyIcon.BalloonTipText = "Program Status: Running";
        this.notifyIcon.BalloonTipTitle = "Skimpt v1.01";
        this.notifyIcon.ContextMenuStrip = this.notificationIconContext;
        this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
        this.notifyIcon.Text = "Skimpt v1.01\r\nProgram Status: Running";
        this.notifyIcon.Visible = true;
        this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
        // 
        // notificationIconContext
        // 
        this.notificationIconContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextStartCamera,
            this.contextHighlightMode,
            this.toolStripSeparator1,
            this.contextShowMenu,
            this.contextExitMenu});
        this.notificationIconContext.Name = "notificationIconContext";
        this.notificationIconContext.Size = new System.Drawing.Size(172, 98);
        // 
        // contextStartCamera
        // 
        this.contextStartCamera.Name = "contextStartCamera";
        this.contextStartCamera.Size = new System.Drawing.Size(171, 22);
        this.contextStartCamera.Text = "Start Camera Mode";
        this.contextStartCamera.Click += new System.EventHandler(this.contextStartCamera_Click);
        // 
        // contextHighlightMode
        // 
        this.contextHighlightMode.Name = "contextHighlightMode";
        this.contextHighlightMode.Size = new System.Drawing.Size(171, 22);
        this.contextHighlightMode.Text = "Start Highlight Mode";
        this.contextHighlightMode.Click += new System.EventHandler(this.contextHighlightMode_Click);
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
        // 
        // contextShowMenu
        // 
        this.contextShowMenu.Name = "contextShowMenu";
        this.contextShowMenu.Size = new System.Drawing.Size(171, 22);
        this.contextShowMenu.Text = "Show Main Window";
        this.contextShowMenu.Click += new System.EventHandler(this.contextShowMenu_Click);
        // 
        // contextExitMenu
        // 
        this.contextExitMenu.Name = "contextExitMenu";
        this.contextExitMenu.Size = new System.Drawing.Size(171, 22);
        this.contextExitMenu.Text = "Exit Skimpt";
        this.contextExitMenu.Click += new System.EventHandler(this.contextExitMenu_Click);
        // 
        // main
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoSize = true;
        this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        this.ClientSize = new System.Drawing.Size(483, 250);
        this.Controls.Add(this.tabControl1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "main";
        this.Opacity = 0.9;
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Text = "Skimpt v 1.01";
        this.TopMost = true;
        this.Load += new System.EventHandler(this.main_Load);
        this.Shown += new System.EventHandler(this.main_Shown);
        this.Closing += new System.ComponentModel.CancelEventHandler(this.main_Closing);
        this.tabControl1.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.tabPage1.PerformLayout();
        this.tabPage2.ResumeLayout(false);
        this.tabPage2.PerformLayout();
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.tabPage3.ResumeLayout(false);
        this.tabPage3.PerformLayout();
        this.tabPage4.ResumeLayout(false);
        this.tabPage4.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.notificationIconContext.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.TabPage tabPage5;
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
    private Button unhookButton;
    public Rectangle CameraCoords;
    private CheckBox HideUponLaunchCheckbox;
    private CheckBox startOnWindowsLoadCheckBox;
    private CheckBox ShowMessagesCheckbox;
    #endregion

    #region Global public/private Variables

    private KeyboardHook KeyboardHookInstance;
    private bool isBusy = false;
    public bool _cameraMode = false;
    public bool _highlightMode = false;
    private bool _updateFound = false;
    private BackgroundWorker bg;
    private Button browseButton;
    private FontDialog fontDialog1;
    private Label updateMessageLabel;
    private SkimptControls.GlassButton hightlightButton;
    private SkimptControls.GlassButton cameraButton;
    private SkimptControls.GlassButton saveFileSettingButton;
    private SkimptControls.GlassButton ftpTestConnButton;
    private SkimptControls.GlassButton saveFtpSettingButton;
    private SkimptControls.GlassButton saveGlobalSettingButton;
    private NotifyIcon notifyIcon;
    private LinkLabel updateMessageLink;
    private Button exitButton;
    private ContextMenuStrip notificationIconContext;
    private ToolStripMenuItem contextExitMenu;
    private ToolStripMenuItem contextShowMenu;
    private ToolStripMenuItem contextStartCamera;
    private ToolStripMenuItem contextHighlightMode;
    private ToolStripSeparator toolStripSeparator1;
    private SkimptControls.GlassButton attachContextMenuButton;
    private GroupBox groupBox2;
    private SkimptControls.GlassButton removeContextMenuButton;
    private CheckBox savePSDasFileCheckbox;
    private static Skimpt.Properties.Settings mySettings = new Skimpt.Properties.Settings();
    


    #endregion

    #region Delegates
    private delegate void ShowToastFormInvoker(string filename);

    #endregion

    #region Properties
    public bool ToggleCameraMode { get { return _cameraMode; } set { _cameraMode = value; } }

    #endregion

    #region Construtor
    public main()
    {
        //constructor.
        //dont delete this line. It creates all the GUI stuff.
        //Check the main.designer.cs to see GUI code.
        InitializeComponent();

        //The following sets up a hook as soon as the program is launched.
        KeyboardHookInstance = new KeyboardHook();
        KeyboardHookInstance.KeyIntercepted += new KeyboardHookCaptureHandler(KeyboardHookInstance_KeyIntercepted);

        //Create a timer for checking for updates
        System.Threading.Timer tm = new System.Threading.Timer(new TimerCallback(timerProcCallBack));
        tm.Change(10000, 600000);

        //Configure the background worker. 
        bg = new BackgroundWorker();
        bg.WorkerReportsProgress = false;
        bg.DoWork += new DoWorkEventHandler(bg_DoWork);
        
    }

    private void timerProcCallBack(Object state)
    {
        if(!bg.IsBusy && !_updateFound)
            bg.RunWorkerAsync();

        if(_updateFound)
        {
            System.Threading.Timer tm = (System.Threading.Timer)state;
            tm.Dispose();
        }
            
    }

    /// <summary>
    /// This function is invoked when RunWorkerAsync is called in the constructor.
    /// It runs on a seperate thread to check for a program update.
    /// </summary>
    void bg_DoWork(object sender, DoWorkEventArgs e)
    {
        int curVer;
        autoupdater.GetLatestVersion();
        curVer = Convert.ToInt32(Application.ProductVersion.Replace(".", string.Empty));

        if (autoupdater.GetLatestVersion() > curVer)
        {
            _updateFound = true;
            updateMessageLabel.Invoke(new MethodInvoker(ShowUpdateLabel));
        }
    }


    #endregion

    #region KeyboardShortCut Pressed


    /// <summary>
    /// This function is an event handler for the KeyIntercepted.
    /// It intercepts ALL keys from the keyboard input from the buffer.
    /// </summary>
    /// <param name="keyboardEvents">Contains the Key Enum, and the Key Code</param>
    void KeyboardHookInstance_KeyIntercepted(KeyboardHookEventArgs keyboardEvents)
    {
        if (keyboardEvents.PressedKey == Keys.PrintScreen)
        {
            takeSnapShot();
        }

        if (keyboardEvents.PressedKey == Keys.F8)
        {
            this.Visible = !this.Visible;
        }
    }

    #endregion

    #region Private Functions
    /// <summary>
    /// This validates the inputbox and checks if we have zero length.
    /// The inputbox is shown when the user chooses to specify a filename
    /// rather then randomly renaming it.
    /// </summary>
    private void inputBox_Validating(object sender, InputBoxValidatingArgs argE)
    {
        if (argE.Text.Trim().Length == 0)
        {
            //if the text is not valid, cancel the event. 
            argE.Cancel = true;
            argE.Message = "Required";
        }
    }

    /// <summary>
    /// This function, when executed, shows the toast form
    /// with animation. 
    /// </summary>
    /// <param name="filename">Full path needed to send to toast form</param>
    private void ShowToastForm(string filename)
    {
        //create a new random instance.
        Random rand = new Random();
        //create a new toastform instance.
        toastform slice = new toastform(System.IO.Path.Combine(mySettings.fileLocationSetting.ToString(), filename) + ".jpg");
        slice.Show();
        isBusy = false;
        rand = null;
    }

    /// <summary>
    /// This function, when executed, displays the
    /// hidden "update" label. It gets the update from
    /// google code. A seperate function is required because 
    /// a delegate is used to access this function.
    /// </summary>
    private void ShowUpdateLabel()
    {
        updateMessageLabel.Visible = true;
        updateMessageLink.Visible = true;
        notifyIcon.ShowBalloonTip(60000, "Update", "Skimpt has a new update!", ToolTipIcon.Info);
    }

    /// <summary>
    /// This function takes a snapshop. 
    /// If the camera is on, it only takes a specified window area.
    /// </summary>
    private void takeSnapShot()
    {
        Bitmap PictureTaken = null; //local variable for the captured Bitmap
        string filename = string.Empty; //local variable for filename
        if (!isBusy)
        {
            isBusy = true;
            //check if its a valid file and that the directory exists
            if (!String.IsNullOrEmpty(mySettings.fileLocationSetting.ToString()) || System.IO.Directory.Exists(mySettings.fileLocationSetting.ToString()))
            {

                //Check if user wants random filename
                if (mySettings.randomFileNameSetting)
                {
                    //check to see if they want randomized letters
                    //or current date and time.
                    if (mySettings.fileasdatesetting)
                        filename = utilities.GetRandomFileName();
                    else
                        filename = System.IO.Path.GetRandomFileName();
                }
                else
                {
                    //user has chosen to specify their own filename.
                    //Show the input box to get data.
                    InputBoxResult result = InputBox.Show("Enter Filename", "Filename Entry", String.Empty, new InputBoxValidatingHandler(inputBox_Validating));
                    if (result.OK)
                        filename = result.Text;
                    else
                        filename = System.IO.Path.GetRandomFileName(); //if the input box fails, randomize the filename.                    
                    result = null;
                }

                //clean the input incase it has an extension.
                filename = System.IO.Path.GetFileNameWithoutExtension(filename);
                
                //if camera mode is on
                if (_cameraMode)
                {
                    //try block to prevent errors
                    try
                    {
                        //take picture
                        PictureTaken = ScreenCapture.CaptureDeskTopRectangle(CameraCoords, CameraCoords.Width, CameraCoords.Height);
                        //save the file
                        PictureTaken.Save(System.IO.Path.Combine(mySettings.fileLocationSetting.ToString(), filename) + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        //set the program message.
                        utilities.SetProgramMessage("Picture Saved", mainProgramMessage);
                        //invoke toast form to display picture options
                        this.Invoke(new ShowToastFormInvoker(ShowToastForm), filename);
                    }
                    catch (Exception ex)
                    {
                        //image capture failed.
                        //we were unable to save file.                        
                        if (mySettings.showErrorMessagesSetting)
                            MessageBox.Show("Unable to save file", "Error", MessageBoxButtons.OK);
                        isBusy = false;
                        utilities.SetProgramMessage(ex.Message, mainProgramMessage);
                    }
                    finally
                    {
                        if (PictureTaken != null)
                        {
                            PictureTaken.Dispose();
                            PictureTaken = null;
                        }

                    }
                }
                else
                {
                    //Camera mode is turned off, so we do the whole screen.
                    try
                    {

                        //PictureTaken = ScreenCapture.GetDesktopWindowCaptureAsBitmap();
                        //PictureTaken.Save(System.IO.Path.Combine(mySettings.fileLocationSetting.ToString(), filename) + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        SkimptImage ski = new SkimptImage();
                        ski.ImageFormat = new JPGFormat();
                        ski.CaptureDesktop(CameraCoords);           
                     
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.Source.ToString() );
                        Console.WriteLine(ex.StackTrace.ToString());

                        //we were unable to save file.                        
                        if (mySettings.showErrorMessagesSetting)
                            MessageBox.Show("Unable to save file", "Error", MessageBoxButtons.OK);

                        isBusy = false;
                        utilities.SetProgramMessage(ex.Message, mainProgramMessage);
                    }
                    finally
                    {
                        if (PictureTaken != null)
                        {
                            PictureTaken.Dispose();
                            PictureTaken = null;
                        }

                    }
                }

                isBusy = false; //last of the code is executed. 
            }
            else
            {
                //filepath is not valid
                if (mySettings.showErrorMessagesSetting)
                    MessageBox.Show("File location not found", "Error", MessageBoxButtons.OK);

                isBusy = false;
                utilities.SetProgramMessage("File location not found", mainProgramMessage);

            }

        }

    }

    /// <summary>
    /// This function enables the camera and turns it off if already enabled. 
    /// </summary>
    private void startCameraMode() {
        _cameraMode = !_cameraMode;
        bool _alreadyopen = false;

        if(_cameraMode)
        {
            foreach(var item in Application.OpenForms)
            {
                if(item is MainCropForm)
                    _alreadyopen = true;


            }
            if(!_alreadyopen)
            {
                MainCropForm mc = new MainCropForm(this);
                mc.Show();
                this.Hide();
            }

        }
    }

    /// <summary>
    /// This function enables the camera, yet takes a full screenshot with highlight.
    /// </summary>
    private void startHighlightMode()
    {
        _highlightMode = !_highlightMode;
        bool _alreadyopen = false;

        if(_highlightMode)
        {
            foreach(var item in Application.OpenForms)
            {
                if(item is MainCropForm)
                    _alreadyopen = true;
            }
            if(!_alreadyopen)
            {
                MainCropForm mc = new MainCropForm(this);
                mc.Show();
                this.Hide();
            }

        }
    }

    #endregion

    #region Settings Related Functions

    /// <summary>
    /// This function loads all the settings in the appropriate textboxes
    /// </summary>
    private void LoadSettings()
    {

        if (mySettings.randomFileNameSetting)
            this.radioButton1.Checked = true;
        else
            this.radioButton2.Checked = true;

        //check if a valid path exists.
        if (mySettings.fileLocationSetting != String.Empty && 
            System.IO.Directory.Exists (mySettings.fileLocationSetting))
        {
            this.fileLocationTextBox.Text = mySettings.fileLocationSetting;
        }
        else
        {
            //valid path does not exist. 
            mySettings.fileLocationSetting = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            mySettings.Save();
            this.fileLocationTextBox.Text = mySettings.fileLocationSetting;      

        }
        this.ftpHostTxtBox.Text = mySettings.ftphostSetting;
        this.ftpPassTxtBox.Text = mySettings.ftppasswordSetting;
        this.ftpUserTxtBox.Text = mySettings.ftpusernameSetting;
        this.ftpDirTxtBox.Text = mySettings.ftpdirectorySetting;
        this.ftpPortTxtBox.Text = mySettings.ftpportSetting.ToString();

        this.savePSDasFileCheckbox.Checked  = mySettings.savePSDasFileSetting;
        this.HideUponLaunchCheckbox.Checked = mySettings.hideOnLoad;
        this.ShowMessagesCheckbox.Checked = mySettings.showErrorMessagesSetting;
        
    }
    /// <summary>
    /// The file SaveSettings button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void saveFileSettingButton_Click(object sender, EventArgs e)
    {
        mySettings.fileLocationSetting = fileLocationTextBox.Text;
        if(radioButton1.Checked)
            mySettings.randomFileNameSetting = true;
        else if(radioButton2.Checked)
            mySettings.randomFileNameSetting = false;
        else
            mySettings.randomFileNameSetting = true;
        mySettings.Save();
    }


    /// <summary>
    /// The FTP SaveSettings button is clicked
    /// </summary>  
    private void saveFtpSettingButton_Click(object sender, EventArgs e)
    {
        mySettings.ftphostSetting = ftpHostTxtBox.Text;
        mySettings.ftpusernameSetting = ftpUserTxtBox.Text;
        mySettings.ftppasswordSetting = ftpPassTxtBox.Text;
        mySettings.ftpdirectorySetting = ftpDirTxtBox.Text;
        mySettings.ftpportSetting = Convert.ToInt32(ftpPortTxtBox.Text);
        mySettings.ftpOKsettings = false;
    }

    /// <summary>
    /// This function tests the FTP connection if valid values are given
    /// </summary>
    private void ftpTestConnButton_Click(object sender, EventArgs e)
    {
      
        try
        {
            FTP f = new FTP(mySettings.ftphostSetting.ToString(), ".", mySettings.ftpusernameSetting, mySettings.ftppasswordSetting, mySettings.ftpportSetting);
            f.ChangeDirectory(mySettings.ftpdirectorySetting);
            mySettings.ftpOKsettings = true;
            mySettings.Save();
            utilities.ShowMessage("Test Successfull", "FTP Test");
        }
        catch(Exception ex)
        {
            mySettings.ftpOKsettings = false;
            mySettings.Save();
            utilities.ShowMessage(ex.Message + Environment.NewLine + "Test Failed", "Failed");
        }
    }


    /// <summary>
    /// This function is an event handler for the SaveGlobalSettings 
    /// button click. If its pressed it saves the global settings 
    /// to the XML file.
    /// </summary>
    private void saveGlobalSettingButton_Click(object sender, EventArgs e)
    {
        mySettings.hideOnLoad = HideUponLaunchCheckbox.Checked;
        mySettings.showErrorMessagesSetting = ShowMessagesCheckbox.Checked;
        mySettings.savePSDasFileSetting = savePSDasFileCheckbox.Checked;

        //set or delete the registry key upon Windows Startup.
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        if(startOnWindowsLoadCheckBox.Checked)
        {
            rkApp.SetValue("Skimpt", Application.ExecutablePath.ToString());
        }
        else
        {
            rkApp.DeleteValue("Skimpt", false);
        }

        mySettings.Save();

    }

    /// <summary>
    /// This attaches the context menu to Windows
    /// </summary>
    private void attachToWindowsButton_Click(object sender, EventArgs e)
    {
        ContextHandler ch = new ContextHandler();
        if(!ch.Add())
        {
            utilities.ShowMessage("Unable to add to windows", "failed");
        }
    }
    /// <summary>
    /// This function removes the context menu from windows
    /// </summary>
    private void removeContextMenuButton_Click(object sender, EventArgs e)
    {
        if(!ContextHandler.Remove())
            utilities.ShowMessage("Unable to remove Skimpt from context menu", "failed");
    }
    #endregion

    #region Form Events

    /// <summary>
    /// This function is an event handler for when the form 
    /// loads. It is run after the constructor.   
    /// </summary>
    private void main_Load(object sender, EventArgs e)
    {
        if (mySettings.hideOnLoad)
            this.Hide();
        //When the form loads, load up all settings.
        LoadSettings();

        //update the title bar
        this.Text = "Skimpt V: " + Application.ProductVersion.ToString();

        //use the notify icon to tell the user its been started
        notifyIcon.ShowBalloonTip(1000, "Skimpt", "Skimpt is now running", ToolTipIcon.Info);

    }

    ///<summary>
    ///The following function hides the form if the close button is pressed,
    ///instead of closing the application. Also, it enables the Notification Icon.
    /// </summary>
    private void main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        // Hide the form...
        this.Hide();
        // Cancel the close...
        e.Cancel = true;
        //Enable Notification Icon
        notifyIcon.Visible = true;
    }
    
    /// <summary>
    /// This function is an event handler which unhooks the 
    /// Keyboard Intercepting. Clicking this will not cause the
    /// event to fire in the future.
    /// </summary>
    private void unhookButton_Click(object sender, EventArgs e)
    {

        //run the UnHookKey method. If it returns true,
        //display message to user.
        if (KeyboardHookInstance.UnHookKey())
        {
            if (mySettings.showErrorMessagesSetting)
                utilities.ShowMessage("prtscr unhooked from program", "prtscr marshall");
        }
    }


    /// <summary>
    /// This function is an event handler for when the hightligt 
    /// button is clicked.
    /// </summary>
    private void hightlightButton_Click(object sender, EventArgs e)
    {
        startHighlightMode();
    }

    /// <summary>
    /// This function is an event handler for when the toggle camera 
    /// button is clicked.
    /// </summary>
    private void cameraButton_Click(object sender, EventArgs e)
    {
        startCameraMode();
    }
   

    /// <summary>
    /// This function is an event handler for the FolderBrowse button
    /// It opens a new instance of the folderBrowser to allow
    /// the user to select a path 
    /// </summary>
    private void browseButton_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        fbd.ShowDialog();
        if (System.IO.Directory.Exists(fbd.SelectedPath))
            fileLocationTextBox.Text = fbd.SelectedPath;

        saveFileSettingButton.PerformClick();
        fbd.Dispose();
        fbd = null;
    }


    /// <summary>
    /// This function occurs when the form is first SHOWN. 
    /// This function happens after the load event.
    /// </summary>
    private void main_Shown(object sender, EventArgs e)
    {
        if (mySettings.hideOnLoad)
            this.Hide();
    }

    //Open Browser Window on clicking website link
    private void updateMessageLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        System.Diagnostics.Process.Start("http://code.google.com/p/skimpt");
    }


    private void exitButton_Click(object sender, EventArgs e)
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }

    //Show the form screen on double clicking 
    //Notification Icon
    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        this.Show();
    }

    private void contextExitMenu_Click(object sender, EventArgs e)
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }

    private void contextShowMenu_Click(object sender, EventArgs e)
    {
        notifyIcon.Visible = false;
        this.Show();
    }

    private void contextStartCamera_Click(object sender, EventArgs e)
    {
        startCameraMode();
    }

    private void contextHighlightMode_Click(object sender, EventArgs e)
    {
        startHighlightMode();
    }
    #endregion




    



   


   





   



  
  

 
}
