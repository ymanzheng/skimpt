using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ScreenShot;
using Util;

public partial class main : Form
{


    #region Global public/private Variables
    //global private variables
    private bool isBusy = false;
    private bool _cameraMode = false;
    private static Platters.Properties.Settings mySettings = new Platters.Properties.Settings();
    
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
    } 
    #endregion

    #region ShortCut Keys Press Events
    /// <summary>
    /// This is what happens when the first shift is pressed. It is created on a seprate thread.
    /// </summary>
    /// <param name="sender">the object that invokes this code</param>
    /// <param name="e">arguments for the object</param>
    private void shortcut1_HotkeyPressed(object sender, EventArgs e)
    {

        if (!isBusy)
        {
            isBusy = true;

            if (!String.IsNullOrEmpty(mySettings.fileLocationSetting.ToString()) || System.IO.Directory.Exists(mySettings.fileLocationSetting.ToString()))
            {
                //valid file

                //declare variables only if valid file. 
                ScreenCapture SC = new ScreenCapture();
                string filename;


                //code block to either get random filename
                // OR to have someone input a custom name.
                if (mySettings.randomFileNameSetting)
                {
                    filename = System.IO.Path.GetRandomFileName();
                }
                else
                {
                    InputBoxResult result = InputBox.Show("Enter Filename", "Filename Entry", String.Empty, new InputBoxValidatingHandler(inputBox_Validating));
                    if (result.OK)
                        filename = result.Text;
                    else
                        filename = System.IO.Path.GetRandomFileName();
                }

                //clean the input
                filename = System.IO.Path.GetFileNameWithoutExtension(filename);

                if (_cameraMode)
                {
                    //do camera mode code
                }
                else
                {
                    try
                    {
                        SC.CaptureScreenToFile(System.IO.Path.Combine(mySettings.fileLocationSetting.ToString(), filename) + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        utilities.SetProgramMessage("Picture Saved", mainProgramMessage);
                        this.Invoke(new ShowToastFormInvoker(ShowToastForm), filename);

                    }
                    catch (Exception ex)
                    {
                        if (mySettings.showErrorMessagesSetting)
                            MessageBox.Show("Unable to save file", "Error", MessageBoxButtons.OK);

                        isBusy = false;
                        utilities.SetProgramMessage(ex.Message, mainProgramMessage);
                    }
                }


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

    #endregion

    #region Private Functions
    /// <summary>
    /// This validates the inputbox and checks if we have zero length.
    /// The inputbox is shown when the user chooses to specify a filename
    /// rather then randomly renaming it.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void inputBox_Validating(object sender, InputBoxValidatingArgs argE)
    {
        if (argE.Text.Trim().Length == 0)
        {
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
        Random rand = new Random();
        toastform slice = new toastform(System.IO.Path.Combine(mySettings.fileLocationSetting.ToString(), filename) + ".jpg");
        slice.Show();
        isBusy = false;
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

        this.fileLocationTextBox.Text = mySettings.fileLocationSetting;
        this.ftpHostTxtBox.Text  = mySettings.ftphostSetting;
        this.ftpPassTxtBox.Text = mySettings.ftppasswordSetting;
        this.ftpUserTxtBox.Text = mySettings.ftpusernameSetting;
        this.ftpDirTxtBox.Text = mySettings.ftpdirectorySetting;
        this.ftpPortTxtBox.Text = mySettings.ftpportSetting.ToString();
        
    }
    /// <summary>
    /// The file SaveSettings button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void saveFileSettingBtn_Click(object sender, EventArgs e)
    {
        mySettings.fileLocationSetting = fileLocationTextBox.Text;
        if (radioButton1.Checked)
            mySettings.randomFileNameSetting = true;
        else if (radioButton2.Checked)
            mySettings.randomFileNameSetting = false;
        else
            mySettings.randomFileNameSetting = true;
        mySettings.Save();
    }

    /// <summary>
    /// The FTP SaveSettings button is clicked
    /// </summary>  
    private void ftpSettingsBtn_Click_1(object sender, EventArgs e)
    {
        mySettings.ftphostSetting = ftpHostTxtBox.Text;
        mySettings.ftpusernameSetting = ftpUserTxtBox.Text;
        mySettings.ftppasswordSetting = ftpPassTxtBox.Text;
        mySettings.ftpdirectorySetting = ftpDirTxtBox.Text;
        mySettings.ftpportSetting = Convert.ToInt32(ftpPortTxtBox.Text);
        mySettings.ftpOKsettings = false;
    }

    private void ftptestConnectionbutton_Click(object sender, EventArgs e)
    {
        //test connection here
        //code to be implemented
        mySettings.ftpOKsettings = true;
    }


    #endregion

    #region Form Events
    private void main_Load(object sender, EventArgs e)
    {
        LoadSettings();
    } 
    #endregion

 
  

    //private void button1_Click(object sender, EventArgs e)
    //{
      //try
      //  {
      //      FTP f = new FTP("mynatoronto.com", ".", "mynatoronto.com", "963852", 21);
      //      string [] infos = f.GetFileList("*");
      //      f.ChangeDirectory("wwwroot");
      //      f.UploadFile ("c:\\users\\affan\\desktop\\ss.jpg");
      //      MessageBox.Show ("Done");

      //  }
      //  catch (Exception ex)
      //  {
      //      MessageBox.Show(ex.Message);
         
      //  }

    //}

}
