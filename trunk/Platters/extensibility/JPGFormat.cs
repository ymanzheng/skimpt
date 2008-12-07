using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;



public class JPGFormat : IImageFormat 
{

    private delegate void ShowToastFormInvoker(string filename);

    private long imageQuality = 80L;
    private const string FormatName = "Jpg";
    private const string EncoderType = "image/jpeg";

    private IImageOutput output;

    public IImageFormat Format
    {
        get { return this; }
    }

    public string Extension
    {
        get { return "jpg"; }
    }

    public string Description
    {
        get { return "Saves the image as a jpeg"; }
    }

    public System.Windows.Forms.MenuItem Menu
    {
        get { throw new NotImplementedException(); }
    }

    /// <summary>
    /// This connects the Jpeg class to the output class defined by Skimpt.
    /// How it works:
    /// The skimptImage class defined by Skimpt implments the IImageOuput interface. Therefore
    /// it must provide an event handler for the event ImageCaptured and as such it is
    /// defined in our SkimptImage class. But you have to realize that the imagecaptured means that
    /// we have captured the image into memory but is not yet saved. Therefore
    /// we pass our JPGFormat class a reference of our SkimptImage class. 
    /// We then create an event handler for ImageCaptured in JpgFormat so we can
    /// save it as Jpeg. Note that the SkimptImage upon capturing the image 
    /// will raise this event and so like I said previously the event is defined 
    /// in the SkimptImage class but the event handler will be defined in this class 
    /// because it already has a reference to the SkimptImage class.
    /// </summary>
    /// <param name="persistableOutput">
    /// This parameter is a class defined by skimpt that implements the IImageOutput interface
    /// </param>
    public void Connect(IImageOutput persistableOutput)
    {
        if (persistableOutput == null)
            throw new ArgumentNullException("persistable output");
        output = persistableOutput;
        output.ImageCaptured += new ImageCapturedEventHandler(output_ImageCaptured);      
    }

    /// <summary>
    /// Event handler for imagecaptured. When the image is captured
    /// by SkimptImage, then it raises this event.  
    /// </summary>
    /// <param name="e">
    /// Has all the information about the Image captured by Skimpt
    /// </param>
    void output_ImageCaptured(object sender, ImageEventArgs e)
    {
        SaveImage(e);
    }

    
    public void Disconnect()
    {
        output.ImageCaptured -= output_ImageCaptured;
    }
    
    
    public void SaveImage(ImageEventArgs e)
    {
        ImageCodecInfo myImageCodecInfo;
        Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;

        myImageCodecInfo = GetEncoderInfo(EncoderType);
        myEncoder = Encoder.Quality;
        myEncoderParameters = new EncoderParameters(1);
        myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
        myEncoderParameters.Param[0] = myEncoderParameter;

        try
        {
            string finalFile = System.IO.Path.Combine(e.FullSaveLocation, e.FullFileName) + "." + e.Extension;           
          
            e.CapturedImage.Save(finalFile,
                                myImageCodecInfo, myEncoderParameters);


            //  e.CapturedImage.Save(finalFile);
            // e.CapturedImage.Save("c:\\users\\affan\\desktop\\jjajja.jpeg");
            ShowToastForm(finalFile);
            //this.Invoke(new ShowToastFormInvoker(ShowToastForm), e.FullSaveLocation + ".jpg");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            myEncoderParameters.Dispose();
            myEncoderParameter.Dispose();
        }
    }

    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        int j;
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j < encoders.Length; j++)
        {
            if (encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }

    /// <summary>
    /// This function, when executed, shows the toast form
    /// with animation. 
    /// </summary>
    /// <param name="filename">Full path needed to send to toast form</param>
    private void ShowToastForm(string filename)
    {
        //create a new toastform instance.
        toastform slice = new toastform(filename);
        slice.Show();
    
    }


}
