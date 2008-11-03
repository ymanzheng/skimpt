using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections ;


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

    private string _FileNameToHandle;

    public string SetFileName { set { _FileNameToHandle = value; } }

    //private constructor
    private toastform()
    {
        InitializeComponent();
    }

    public toastform(string filename) : this()
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
        foreach (toastform openForm in toastform.openForms) { 
            openForm.Top -= this.Height + 5; 
        } 
        
        //Add this form from the open form list. 
        toastform.openForms.Add(this);

        if (!string.IsNullOrEmpty(_FileNameToHandle))
            fileNameLabel.Text = _FileNameToHandle;

        //Start counting down the form's liftime. 
        //this.lifeTimer.Start(); 
    }

    private void uploadingStartBtn_Click(object sender, EventArgs e)
    {
        pictureBox1.Visible = true;

        try
        {
            FTP f = new FTP("mynatoronto.com", ".", "mynatoronto.com", "963852", 21);
            string[] infos = f.GetFileList("*");
            f.ChangeDirectory("wwwroot");
            f.UploadFile("c:\\users\\affan\\desktop\\ss.jpg");
            MessageBox.Show("Done");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);

        }

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
    


    

}




    
    
 
    
