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
using Skimpt3.classes;
using System.Net;
using System.Text;
using System.IO;


public partial class toastform : Form
{


    //The list of currently open ToastForms. 
    private static ArrayList openForms = new ArrayList();
    //The object that creates the sliding animation. 
    private FormAnimator m_Animator;
    //The handle of the window that currently has focus. 
    private IntPtr m_CurrentForegroundWindow;  
    static int static_ToastForm_Activated_activationCount = 0;


    //the property and variable for the filename
    private string _FileNameToHandle;
    public string SetFileName { set { _FileNameToHandle = value; } }


    //the property and variable for the skImage
    private skImage  _skImageToHandle;
    public skImage SetSkImage { set { _skImageToHandle = value; } }

    //the private static reference to the settings object
    private static Skimpt3.Properties.Settings mySettings = new Skimpt3.Properties.Settings();


    //private constructor
    private toastform()
    {
        InitializeComponent();
    }
    
    public toastform(skImage ic) : this() {
            this._skImageToHandle = ic;
        
        //Set the time for which the form should be displayed. 
            this.lifeTimer.Interval = mySettings.ToastFormTimer;
      
        //Attach this form to the Formanimator. 
        //The FormAnimator now has a reference to this toastform.
        //When the load() of this form is invoked, the Form animator intercepts it and displays the form.
        this.m_Animator = new FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 400);
       // this.m_Animator.Dispose();
        }

    public new void Show()
    {
        //Determine the current foreground window so it can be reactivated each time this form tries to get the focus. 
        this.m_CurrentForegroundWindow = Win32.GetForegroundWindow();
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

        //set the initial values for both comobo boxes
        hostingChoicesComboBox.SelectedIndex = 0;
        effectsComboBox.SelectedIndex = 0;

        updatePreview();

        if (_skImageToHandle.ImageOnFile) {
            fileNameLabel.Text = _skImageToHandle.FileLocation;
            saveImageButton.Enabled = false;
        } else {
            fileNameLabel.Text = "Image not yet saved";
            saveImageButton.Enabled = true;            
        }

        //Start counting down the form's liftime. 
        this.lifeTimer.Start();
    }

    private void updatePreview() {
        previewBox.Image = _skImageToHandle.ThumbnailImage;
        previewBox.Refresh();
    }

    private void toastform_Activated(object sender, EventArgs e)
    {
       
        //The number of times the form has been actiavted. 

        //This form will try to take the focus times as it is being displayed. 
        if (static_ToastForm_Activated_activationCount < 5)
        {
            //Activate the window that previously had the focus. 
            Win32.SetForegroundWindow(this.m_CurrentForegroundWindow);
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
        Console.WriteLine("Closed - toastform");
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
        this.m_Animator.Dispose(); //remove the references to the events
    }

    private void lifeTimer_Tick(object sender, EventArgs e)
    { 
        this.Close();
    }


    private void uploadToSiteButton_Click(object sender, EventArgs e) {
        switch (hostingChoicesComboBox.SelectedItem.ToString().ToLower()) {
            case "imgur.com":
                byte[] response;
                using (MemoryStream ms = new MemoryStream()) {
                    
                    _skImageToHandle.CapturedImage.Save(ms, Common.GetFormat(_skImageToHandle.CapturedImage));
                    using (WebClient wb = new WebClient()) {
                        var values = new System.Collections.Specialized.NameValueCollection
                                     {
                                         {"key", mySettings.APIKey},
                                         {"image", Convert.ToBase64String(ms.ToArray())}
                                     };
                        response = wb.UploadValues("http://imgur.com/api/upload.xml", values);
                    }
                }           

                //read the result
                MemoryStream s = new MemoryStream(response);
                StreamReader sr = new StreamReader(s);                
                Console.WriteLine(sr.ReadToEnd());

                break;
            default:
                MessageBox.Show("not supported");
                break;
        }

    }


    private void uploadToFtpButton_Click(object sender, EventArgs e)
    {
        if (this.lifeTimer.Enabled)
            toggleTimer(false);

        uploadToSiteButton.Enabled = false;
        uploadToFtpButton.Enabled = false;
        applyEffectButton.Enabled = false;
        
        try {
            FTP f = new FTP(mySettings.FTPHost, ".", mySettings.FTPUser, mySettings.FTPPass, mySettings.FTPPort);
            f.ChangeDirectory(mySettings.FTPDir);
            f.UploadFile(_FileNameToHandle);
            MessageBox.Show("Done");
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        this.applyEffectButton.Enabled = true;
        this.uploadToSiteButton.Enabled = true;
        this.uploadToFtpButton.Enabled = true;
        
    }

    private void applyEffectButton_Click(object sender, EventArgs e)
    {
        if (this.lifeTimer.Enabled)
            toggleTimer(false);

        uploadToSiteButton.Enabled = false;
        uploadToFtpButton.Enabled = false;
        applyEffectButton.Enabled = false;       
        this.lifeTimer.Enabled = false;
        try {       
            switch (effectsComboBox.SelectedItem.ToString().ToLower()) {
                case "grayscale":
                    if(_skImageToHandle.GrayScale())
                        updatePreview();
                    break;
                case "invert":
                    if(_skImageToHandle.Invert())
                        updatePreview();
                    break;
                case "watermark":
                    MessageBox.Show("Not supported");
                    break;
                case "flip":
                    MessageBox.Show("Not supported");
                    break;
                case "brightness":
                    if(_skImageToHandle.Brightness(40))
                        updatePreview();
                    break;
                default:
                    break;
            }
         
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            MessageBox.Show("Unable to apply effect!");
        }
        this.applyEffectButton.Enabled = true;
        this.uploadToSiteButton.Enabled = true;
        this.uploadToFtpButton.Enabled = true;       
        
    }

    private void glassButton1_Click(object sender, EventArgs e) {
        toggleTimer(!this.lifeTimer.Enabled);
    }

    private void saveImageButton_Click(object sender, EventArgs e) {
        if (_skImageToHandle.Save()) {
            fileNameLabel.Text = _skImageToHandle.FileLocation;
            saveImageButton.Enabled = false;
        }
    }

    private void toggleTimer(bool value) {
        this.lifeTimer.Enabled = value;
        if (this.lifeTimer.Enabled)
            this.timerButton.Text = "pause timer";
        else
            this.timerButton.Text = "start timer";
    }


}

