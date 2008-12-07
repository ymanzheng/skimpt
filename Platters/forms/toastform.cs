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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Util;

public partial class toastform : Form
{
    #region Toast Variables, Do not change
    [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
    private static extern IntPtr GetForegroundWindow();
    [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    //The list of currently open ToastForms. 
    private static ArrayList openForms = new ArrayList();

    //The object that creates the sliding animation. 
    private FormAnimator m_Animator;

    //The handle of the window that currently has focus. 
    private IntPtr m_CurrentForegroundWindow;
    static int static_ToastForm_Activated_activationCount = 0;

    #endregion


    //the property and variable for the filename
    private string _FileNameToHandle;
    public string SetFileName { set { _FileNameToHandle = value; } }

    //the private static reference to the settings object
    private static Skimpt.Properties.Settings mySettings = new Skimpt.Properties.Settings();


    //private constructor
    private toastform()
    {
        InitializeComponent();
    }

    public toastform(string filename)
        : this()
    {
        this._FileNameToHandle = filename;
        //Set the time for which the form should be displayed. 
        this.lifeTimer.Interval = 10000;
        //Display the form by sliding up. 
        this.m_Animator = new FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 400);

    }


    public new void Show()
    {
        //Determine the current foreground window so it can be reactivated each time this form tries to get the focus. 
        this.m_CurrentForegroundWindow = toastform.GetForegroundWindow();

        //Display the form. 
        base.Show();
    }

    private void toastform_Load(object sender, EventArgs e)
    {


        //Display the form just above the system tray. 
        this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5, Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5);

        //Move each open form upwards to make room for this one. 
        foreach (toastform openForm in toastform.openForms)
        {
            openForm.Top -= this.Height + 5;
        }

        //Add this form from the open form list. 
        toastform.openForms.Add(this);

        if (!string.IsNullOrEmpty(_FileNameToHandle))
            fileNameLabel.Text = _FileNameToHandle;

        //set the initial values for both comobo boxes
        hostingChoicesComboBox.SelectedIndex = 0;
        effectsComboBox.SelectedIndex = 0;

        //Start counting down the form's liftime. 
        this.lifeTimer.Start();

    }


    #region ToastForm Private Functions, Dont change
    private void toastform_Activated(object sender, EventArgs e)
    {
        //The number of times the form has been actiavted. 

        //This form will try to take the focus times as it is being displayed. 
        if (static_ToastForm_Activated_activationCount < 5)
        {
            //Activate the window that previously had the focus. 
            toastform.SetForegroundWindow(this.m_CurrentForegroundWindow);
        }

        //Increment the activation counter. 
        static_ToastForm_Activated_activationCount += 1;
    }

    private void toastform_FormClosing(object sender, FormClosingEventArgs e)
    {
        //Close the form by sliding down. 
        this.m_Animator.Direction = FormAnimator.AnimationDirection.Down;

    }

    private void toastform_FormClosed(object sender, FormClosedEventArgs e)
    {
        int myFormIndex = toastform.openForms.Count - 1;

        //Find the index of this form in the open form list. 
        while (!(object.ReferenceEquals(toastform.openForms[myFormIndex], this)))
        {
            myFormIndex -= 1;
        }

        toastform openForm = default(toastform);

        //Move down any open forms above this one. 
        for (int i = myFormIndex - 1; i >= 0; i += -1)
        {
            openForm = (toastform)toastform.openForms[i];
            openForm.Top += this.Height + 5;
            openForm.Refresh();
        }

        //Remove this form from the open form list. 
        toastform.openForms.Remove(this);

    }

    private void lifeTimer_Tick(object sender, EventArgs e)
    {
        this.Close();
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
            case "kalleload.net":
                form = new MultipartForm("http://ww.kalleload.net/");
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
                form = new MultipartForm("http://www.imgpurse.com/");
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "file";
                form.setField("upload", "1");
                form.sendFile(_FileNameToHandle);
                returnValue = utilities.parsePOSTData("imgpurse", form.ResponseText.ToString());
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
                form = new MultipartForm("http://www.imageshack.us");
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

