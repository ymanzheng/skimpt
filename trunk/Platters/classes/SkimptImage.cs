using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Util;

/// <summary>
/// This is the main class that connects Skimpt to Image Format plugins. 
/// You can create a plugin for any imageformat you would like Skimpt to save to
/// Refer to help to learn how to create plugins. 
/// </summary>
public class SkimptImage : IImageOutput
{


    //Settings object to get location, filename, and other information
    //about the image
    private static Skimpt.Properties.Settings mySettings = new Skimpt.Properties.Settings();

    //Events exposed from IImageOutput interface.
    //Remember the ImageCaptured event is handled by the plugin
    //thats why we give the plugin an instance of this class.
    public event ImageCaptureInitializedEventHandler ImageCaptureInitialized;
    public event ImageCapturingEventHandler ImageCapturing;
    public event ImageCapturedEventHandler ImageCaptured;

    //imageFormat is a class that implements the IImageFormat interface.
    //Therefore all methods, indexes, properties called from this object
    //refers to the class and NOT the interface.
    private IImageFormat _imageFormat;

    //Arguments for the image when captured
    ImageEventArgs IMGARGS = null;

    public IImageFormat ImageFormat
    {
        get { return _imageFormat; }
        set
        {
            if (_imageFormat != null)
                _imageFormat.Disconnect(); //disconnect any connection between SkimptImage and any provider

            _imageFormat = value;
            if (_imageFormat != null)
            {
                _imageFormat.Connect(this);
            }
        }
    }


    public void CaptureRectangle()
    {
        if (_imageFormat == null)
            throw new ArgumentNullException("+imageFormat->Capture()");

    }

    public void CaptureDesktop()
    {
        if (_imageFormat == null)
            throw new ArgumentNullException("+imageFormat->Capture()");        
    
        //Process the image and populate the arguments
        ProcessImage(ScreenCapture.GetDesktopWindowCaptureAsBitmap());

        //Future version of this event will have something to cancel the 
        //call to the providers save method
        //OnImageCapturing(IMGARGS); //execute eventraise method.

        OnImageCaptured(IMGARGS);
    }

    private void OnImageCaptured(ImageEventArgs IMGARGS)
    {    
        ImageCaptured(this, IMGARGS);
    }

    //This method raises the ImageCapturing event
    private void OnImageCapturing(ImageEventArgs IMGARGS)
    {
        ImageCapturing(this, IMGARGS);
      
    }

    private void ProcessImage(Image full)
    {
        string filename = utilities.GetRandomFileName();
        IMGARGS = new ImageEventArgs(
                                     full,
                                     CreateThumbnailImage(full, 100),
                                     mySettings.fileLocationSetting,
                                     mySettings.thumbnailLocationSetting,
                                     filename, filename + "_thumb",
                                     DateTime.Now, mySettings.generateThumbNails);
    }



    /// <summary>
    /// This creates a thumbnail of the specified image
    /// </summary>
    /// <param name="image">Image passed by value</param>
    /// <param name="maxSize">Maximum size of thumbnail</param>
    /// <returns>Image</returns>
    private static Image CreateThumbnailImage(Image image, double maxSize)
    {
        if (maxSize < 0 || maxSize > Int32.MaxValue)
            throw new ArgumentOutOfRangeException(
                    "maxSize",
                    maxSize, "Out of range");
        double ratio;
        if (image.Height > image.Width)
            ratio = image.Height / maxSize;
        else
            ratio = image.Width / maxSize;

        int newWidth = Convert.ToInt32(image.Width / ratio);
        int newHeight = Convert.ToInt32(image.Height / ratio);

        IntPtr ip = new IntPtr();
        Image.GetThumbnailImageAbort imageAbort = delegate() { return false; };
        return image.GetThumbnailImage(newWidth, newHeight, imageAbort, ip);
    }



}

