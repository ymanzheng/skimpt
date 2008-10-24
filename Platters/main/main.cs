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


    //global private variables
    private bool isBusy = false;
    private bool _cameraMode = false;
    private static Platters.Properties.Settings mySettings = new Platters.Properties.Settings();


    private delegate void ShowToastFormInvoker(string filename);


    public bool ToggleCameraMode { get { return _cameraMode; } set {_cameraMode = value ;} }
    

    public main()
    {
        //constructor.
        //dont delete this line. It creates all the GUI stuff.
        //Check the main.designer.cs to see GUI code.
        InitializeComponent();
    }

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
                        if (mySettings.showErrorMessages)
                            MessageBox.Show("Unable to save file", "Error", MessageBoxButtons.OK);

                        isBusy = false;
                        utilities.SetProgramMessage(ex.Message, mainProgramMessage);
                    }                    
                }
                
                
            }
            else
            {
                //filepath is not valid
                if (mySettings.showErrorMessages)
                    MessageBox.Show("File location not found", "Error", MessageBoxButtons.OK);
                
                isBusy = false;
                utilities.SetProgramMessage("File location not found", mainProgramMessage);

            }

        }

    }

    /// <summary>
    /// This validates the inputbox and checks if we have zero length
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

    private void saveFileSettingBtn_Click(object sender, EventArgs e)
    {
        mySettings.fileLocationSetting = fileLocationTextBox.Text;
        mySettings.Save();
    }

   
    private void ShowToastForm(string filename)
    {

        Random rand = new Random();
        toastform slice = new toastform(rand.Next(500, 5000), "Slice number", System.IO.Path.Combine(mySettings.fileLocationSetting.ToString(), filename) + ".jpg");
        slice.Show();
        isBusy = false;
    }

    //private void button1_Click(object sender, EventArgs e)
    //{
   

    //}

}
