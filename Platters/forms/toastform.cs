using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Configuration;
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
    private static Platters.Properties.Settings mySettings = new Platters.Properties.Settings();


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
        this.lifeTimer.Interval = 5000;
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

        hostingChoicesComboBox.SelectedIndex = 0;


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

        //see what option they chose.
        switch (hostingChoicesComboBox.SelectedItem.ToString().ToLower())
        {
            case "kalleload.com":
               // textBox2.Clear();
                form = new MultipartForm("http://kalleload.net");
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "selector";
                form.setField("progress", "1");
                form.setField("markurl", "http://www.clantemplates.com/v5/html/images/gametracker.gif");
                form.setField("MAX_UPLOAD_SIZE", "16777216");
                form.sendFile(_FileNameToHandle);
                Clipboard.SetText(utilities.parsePOSTData("kalleload", form.ResponseText.ToString()), TextDataFormat.Text);
                break;
                
            case "imgpurse.com":
                form = new MultipartForm("http://imgpurse.com/index.php");
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "file";
                form.setField("upload", "1");
                form.sendFile(_FileNameToHandle);
                Clipboard.SetText(utilities.parsePOSTData("imgpurse", form.ResponseText.ToString()), TextDataFormat.Text);
                break;
            case "tinypic.com":
                form = new MultipartForm("http://s4.tinypic.com/upload.php");                
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "the_file";
                form.setField("UPLOAD_IDENTIFIER", "1154009790_1225587842");
                form.setField("upk", "e8bd19dfda564c710e602341ed9ffdec");
                form.setField("action", "upload");
                form.sendFile(_FileNameToHandle);
                Console.WriteLine (form.ResponseText.ToString());
                Clipboard.SetText(utilities.parsePOSTData("tinypic", form.ResponseText.ToString()), TextDataFormat.Text);
                break;
            case "imageshack.us":
                form = new MultipartForm("http://imageshack.us");
                form.FileContentType = "image/jpeg";
                form.InputBoxName = "fileupload";
                form.setField("swfbutan", "1");
                form.sendFile(_FileNameToHandle);
                Clipboard.SetText(utilities.parsePOSTData("imageshack", form.ResponseText.ToString()), TextDataFormat.Text);
                break;
            default:
                break;
        }
        this.lifeTimer.Enabled = true;

    }

    private void uploadtoFtpBtn_Click(object sender, EventArgs e)
    {
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
    }







}
