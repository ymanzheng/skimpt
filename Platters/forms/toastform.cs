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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Util;

public class toastform : Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;   
    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.lifeTimer = new System.Windows.Forms.Timer(this.components);
        this.fileNameLabel = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.uploadtoFtpBtn = new System.Windows.Forms.Button();
        this.uploadBtn = new System.Windows.Forms.Button();
        this.hostingChoicesComboBox = new System.Windows.Forms.ComboBox();
        this.hostingPictureList = new System.Windows.Forms.ImageList(this.components);
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.applyEffectsButton = new System.Windows.Forms.Button();
        this.effectsComboBox = new System.Windows.Forms.ComboBox();
        this.previewPictureBox = new System.Windows.Forms.PictureBox();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
        this.SuspendLayout();
        // 
        // lifeTimer
        // 
        this.lifeTimer.Tick += new System.EventHandler(this.lifeTimer_Tick);
        // 
        // fileNameLabel
        // 
        this.fileNameLabel.AutoSize = true;
        this.fileNameLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.fileNameLabel.ForeColor = System.Drawing.Color.Blue;
        this.fileNameLabel.Location = new System.Drawing.Point(48, 7);
        this.fileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.fileNameLabel.Name = "fileNameLabel";
        this.fileNameLabel.Size = new System.Drawing.Size(15, 18);
        this.fileNameLabel.TabIndex = 4;
        this.fileNameLabel.Text = "#";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 7);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(38, 18);
        this.label1.TabIndex = 5;
        this.label1.Text = "File: ";
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.uploadtoFtpBtn);
        this.groupBox1.Controls.Add(this.uploadBtn);
        this.groupBox1.Controls.Add(this.hostingChoicesComboBox);
        this.groupBox1.Location = new System.Drawing.Point(3, 63);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(302, 57);
        this.groupBox1.TabIndex = 6;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Upload ";
        // 
        // uploadtoFtpBtn
        // 
        this.uploadtoFtpBtn.Location = new System.Drawing.Point(217, 23);
        this.uploadtoFtpBtn.Name = "uploadtoFtpBtn";
        this.uploadtoFtpBtn.Size = new System.Drawing.Size(66, 26);
        this.uploadtoFtpBtn.TabIndex = 2;
        this.uploadtoFtpBtn.Text = "ftp";
        this.uploadtoFtpBtn.UseVisualStyleBackColor = true;
        this.uploadtoFtpBtn.Click += new System.EventHandler(this.uploadtoFtpBtn_Click);
        // 
        // uploadBtn
        // 
        this.uploadBtn.Location = new System.Drawing.Point(145, 24);
        this.uploadBtn.Name = "uploadBtn";
        this.uploadBtn.Size = new System.Drawing.Size(66, 26);
        this.uploadBtn.TabIndex = 1;
        this.uploadBtn.Text = "site";
        this.uploadBtn.UseVisualStyleBackColor = true;
        this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
        // 
        // hostingChoicesComboBox
        // 
        this.hostingChoicesComboBox.FormattingEnabled = true;
        this.hostingChoicesComboBox.Items.AddRange(new object[] {
            "Kalleload.com",
            "Imgpurse.com",
            "Imageshack.us",
            "Tinypic.com"});
        this.hostingChoicesComboBox.Location = new System.Drawing.Point(18, 23);
        this.hostingChoicesComboBox.Name = "hostingChoicesComboBox";
        this.hostingChoicesComboBox.Size = new System.Drawing.Size(121, 26);
        this.hostingChoicesComboBox.TabIndex = 0;
        // 
        // hostingPictureList
        // 
        this.hostingPictureList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
        this.hostingPictureList.ImageSize = new System.Drawing.Size(16, 16);
        this.hostingPictureList.TransparentColor = System.Drawing.Color.Transparent;
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.applyEffectsButton);
        this.groupBox2.Controls.Add(this.effectsComboBox);
        this.groupBox2.Location = new System.Drawing.Point(3, 126);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(302, 57);
        this.groupBox2.TabIndex = 7;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Effects";
        // 
        // applyEffectsButton
        // 
        this.applyEffectsButton.Location = new System.Drawing.Point(145, 24);
        this.applyEffectsButton.Name = "applyEffectsButton";
        this.applyEffectsButton.Size = new System.Drawing.Size(66, 26);
        this.applyEffectsButton.TabIndex = 1;
        this.applyEffectsButton.Text = "apply";
        this.applyEffectsButton.UseVisualStyleBackColor = true;
        this.applyEffectsButton.Click += new System.EventHandler(this.applyEffectsButton_Click_1);
        // 
        // effectsComboBox
        // 
        this.effectsComboBox.FormattingEnabled = true;
        this.effectsComboBox.Items.AddRange(new object[] {
            "grayscale",
            "invert",
            "flip",
            "watermark"});
        this.effectsComboBox.Location = new System.Drawing.Point(18, 23);
        this.effectsComboBox.Name = "effectsComboBox";
        this.effectsComboBox.Size = new System.Drawing.Size(121, 26);
        this.effectsComboBox.TabIndex = 0;
        // 
        // previewPictureBox
        // 
        this.previewPictureBox.Location = new System.Drawing.Point(70, 7);
        this.previewPictureBox.Name = "previewPictureBox";
        this.previewPictureBox.Size = new System.Drawing.Size(88, 50);
        this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.previewPictureBox.TabIndex = 8;
        this.previewPictureBox.TabStop = false;
        // 
        // toastform
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.ClientSize = new System.Drawing.Size(311, 191);
        this.Controls.Add(this.previewPictureBox);
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.fileNameLabel);
        this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Margin = new System.Windows.Forms.Padding(4);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "toastform";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Text = "Picture Options";
        this.TopMost = true;
        this.Load += new System.EventHandler(this.toastform_Load);
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.toastform_FormClosed);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.toastform_FormClosing);
        this.groupBox1.ResumeLayout(false);
        this.groupBox2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer lifeTimer;
    private System.Windows.Forms.Label fileNameLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.ImageList hostingPictureList;
    private System.Windows.Forms.ComboBox hostingChoicesComboBox;
    private System.Windows.Forms.Button uploadBtn;
    private System.Windows.Forms.Button uploadtoFtpBtn;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button applyEffectsButton;
    private System.Windows.Forms.ComboBox effectsComboBox;

    //The new list of current open ToastForms.
    private static List<toastform> openToastForms = new List<toastform>();

    //The object that creates the sliding animation. 
    private FormAnimator m_Animator;


    
    //the property and variable for the filename
    private string _FileNameToHandle;
    private PictureBox previewPictureBox;

    public string SetFileName { set { _FileNameToHandle = value; } }

    //the private static reference to the settings object
    private static Skimpt.Properties.Settings mySettings = new Skimpt.Properties.Settings();
    
    public toastform(string filename) 
    {
        //design the GUI
        InitializeComponent();

        //check for invalid file
        if (!System.IO.File.Exists(filename))
            this.Close();
        
        this._FileNameToHandle = filename;

        //Set the time for which the form should be displayed. 
        this.lifeTimer.Interval = 10000;

        //Display the form by sliding up. 
        //create a new object.
        this.m_Animator = new FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 400);        
    }




    /// <summary>
    /// Form_load override
    /// </summary>
    private void toastform_Load(object sender, EventArgs e)
    {
        //Display the form just above the system tray. 
        this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5, Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5);

        //Move each open form upwards to make room for this one.
        foreach (toastform oform in toastform.openToastForms)
        {
            oform.Top -= this.Height + 5;
        }
        toastform.openToastForms.Add(this);
        
        if (!string.IsNullOrEmpty(_FileNameToHandle))
            fileNameLabel.Text = _FileNameToHandle;

        //set the initial values for both comobo boxes
        hostingChoicesComboBox.SelectedIndex = 0;
        effectsComboBox.SelectedIndex = 0;

        previewPictureBox.Load(_FileNameToHandle);

        //Start counting down the form's liftime. 
        this.lifeTimer.Start(); 


    }


    #region ToastForm Private Functions, Dont change
  
    private void toastform_FormClosing(object sender, FormClosingEventArgs e)
    {
        //Close the form by sliding down. 
        this.m_Animator.Direction = FormAnimator.AnimationDirection.Down;
    }

    private void toastform_FormClosed(object sender, FormClosedEventArgs e)
    {


        int myFormIndex = toastform.openToastForms.Count - 1;

        //Find the index of this form in the open form list.
        while (!(object.ReferenceEquals(toastform.openToastForms[myFormIndex], this)))
        {
            myFormIndex -= 1;
        }

        toastform openForm = default(toastform);

        //Move down any open forms above this one.
        for (int i = myFormIndex - 1; i >= 0; i += -1)
        {
            openForm = (toastform)toastform.openToastForms[i];
            openForm.Top += this.Height + 5;
            openForm.Refresh();
        }

        //Remove this form from the open form list.
        toastform.openToastForms.Remove(this);
        this.Dispose();
    }

    private void lifeTimer_Tick(object sender, EventArgs e)
    {
        this.Close();
    }

    ~toastform()
    {
        Console.WriteLine("Bye from toastform");
    }


    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
               
        if (disposing && (components != null))
        {
            this.m_Animator = null;
            this.lifeTimer = null;
            components.Dispose();
        }

        base.Dispose(disposing);
    }
    #endregion

    private void uploadBtn_Click(object sender, EventArgs e)
    {
        this.lifeTimer.Enabled = false;
        //declare the form.
        MultipartForm form;

        //define the inputbox as readonly, output only.
        InputBox i = new InputBox("Your URL", "Your URL is also copied to the clipboard automatically", false, true);
        uploadBtn.Enabled = false;
        uploadtoFtpBtn.Enabled = false;
        applyEffectsButton.Enabled = false;
        string returnValue; 
        //see what option they chose.
        switch (hostingChoicesComboBox.SelectedItem.ToString().ToLower())
        {
            case "kalleload.com":
                uploadBtn.Enabled = false;
                form = new MultipartForm("http://kalleload.net");
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "selector";
                form.setField("progress", "1");
                form.setField("markurl", String.Empty);
                form.setField("MAX_UPLOAD_SIZE", "16777216");
                form.sendFile(_FileNameToHandle);
                returnValue = utilities.parsePOSTData("kalleload", form.ResponseText.ToString());
                Clipboard.SetText(returnValue, TextDataFormat.Text);
                i.SetTextbox(returnValue);                
                i.Show();
                break;
                
            case "imgpurse.com":
                form = new MultipartForm("http://imgpurse.com/index.php");
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "file";
                form.setField("upload", "1");
                form.sendFile(_FileNameToHandle);
                returnValue = utilities.parsePOSTData ("imgpurse", form.ResponseText.ToString());
                Clipboard.SetText(returnValue, TextDataFormat.Text);
                i.SetTextbox(returnValue);
                i.Show();
                break;
            case "tinypic.com":
                form = new MultipartForm("http://s4.tinypic.com/upload.php");                
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "the_file";
                form.setField("UPLOAD_IDENTIFIER", "1154009790_1225587842");
                form.setField("upk", "e8bd19dfda564c710e602341ed9ffdec");
                form.setField("action", "upload");
                form.sendFile(_FileNameToHandle);
                returnValue = utilities.parsePOSTData("tinypic", form.ResponseText.ToString());
                Clipboard.SetText(returnValue, TextDataFormat.Text);
                i.SetTextbox(returnValue);
                i.Show();
                break;
            case "imageshack.us":
                form = new MultipartForm("http://imageshack.us");
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "fileupload";
                form.setField("swfbutan", "1");
                form.sendFile(_FileNameToHandle);
                returnValue = utilities.parsePOSTData("imageshack", form.ResponseText.ToString());
                Clipboard.SetText(returnValue, TextDataFormat.Text);
                i.SetTextbox(returnValue);
                i.Show();
                break;
            default:
                break;
        }
        this.lifeTimer.Enabled = true;
        this.applyEffectsButton.Enabled = true;
        this.uploadBtn.Enabled = true;
        this.uploadtoFtpBtn.Enabled = true;
        //get rid of the form.
        form = null;       
    }

    private void uploadtoFtpBtn_Click(object sender, EventArgs e)
    {
        uploadBtn.Enabled = false;
        uploadtoFtpBtn.Enabled = false;
        applyEffectsButton.Enabled = false;
        this.lifeTimer.Enabled = false;
        try
        {
            if (mySettings.ftpOKsettings)
            {
                FTP f = new FTP(mySettings.ftphostSetting.ToString(), ".", mySettings.ftpusernameSetting, mySettings.ftppasswordSetting, mySettings.ftpportSetting);
                f.ChangeDirectory(mySettings.ftpdirectorySetting);
                f.UploadFile(_FileNameToHandle);
            }
            else
            {
                MessageBox.Show("Please supply ftp settings first");
            }

            //MessageBox.Show("Done");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
       
        this.applyEffectsButton.Enabled = true;
        this.uploadBtn.Enabled = true;
        this.uploadtoFtpBtn.Enabled = true;
        this.lifeTimer.Enabled = true;
    }


    private void applyEffectsButton_Click_1(object sender, EventArgs e)
    {
        uploadBtn.Enabled = false;
        uploadtoFtpBtn.Enabled = false;
        applyEffectsButton.Enabled = false;
        this.lifeTimer.Enabled = false;
        try
        {
            Bitmap p = (Bitmap)Bitmap.FromFile(_FileNameToHandle);
            Bitmap bpicture = new Bitmap(p);
            
            p.Dispose();
            System.IO.File.Delete(_FileNameToHandle);

            switch (effectsComboBox.SelectedItem.ToString().ToLower())
            {
                case "grayscale":
                    if (BitmapFilter.GrayScale(bpicture))
                    {
                        bpicture.Save(_FileNameToHandle);
                        MessageBox.Show("image grayscaled");
                    }
                    else
                    {
                        MessageBox.Show("unable to grayscale");                        
                    }
                    break;
                case "invert":
                    if (BitmapFilter.Invert(bpicture))
                    {
                        bpicture.Save(_FileNameToHandle);
                        MessageBox.Show("image inverted");
                    }
                    else
                    {
                        MessageBox.Show("unable to invert");                        
                    }
                    break;
                case "watermark":
                    MessageBox.Show("not supported");
                    break;
                case "flip":
                    MessageBox.Show("not supported");
                    break;
                default:
                    break;
            }

            bpicture.Dispose();
            bpicture = null;
            p = null;          
        }
        catch (Exception)
        {
            MessageBox.Show("unable to apply effect");
        }
        this.applyEffectsButton.Enabled = true;
        this.uploadBtn.Enabled = true;
        this.uploadtoFtpBtn.Enabled = true;
        this.lifeTimer.Enabled = true; 
    }







}
