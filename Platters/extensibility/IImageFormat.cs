using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;


public delegate void ImageCapturedEventHandler(object sender, ImageEventArgs e);
public delegate void StreamHandler(Stream stream, Image image);
public delegate void ImageCaptureInitializedEventHandler(object sender, EventArgs e);
public delegate void ImageCapturingEventHandler(object sender, ImageEventArgs e);

/// <summary>
/// All new imageformats implement this interface to expose the methods
/// </summary>
public interface IImageFormat
{



    /// <summary>
    /// This gets the "class" name through reflection 
    /// to give us the format. 
    /// EX: public class PNG : IImageFormat
    /// Return: PNG
    /// </summary>
    IImageFormat Format { get; }


    /// <summary>
    /// Connects the specified persistable output.
    /// </summary>
    /// <param name="persistableOutput">The persistable output.</param>
    void Connect(IImageOutput persistableOutput);

    /// <summary>
    /// Disconnects this instance.
    /// </summary>
    void Disconnect();

      /// <summary>
    /// Gets the extension.
    /// </summary>
    /// <value>The extension.</value>
    string Extension { get; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>The description.</value>
    string Description { get; }

    /// <summary>
    /// Gets the menu.
    /// </summary>
    /// <value>The menu.</value>
    MenuItem Menu { get; }


    void SaveImage(ImageEventArgs e);
    

}

public interface IImageOutput
{
    /// <summary>
    /// Occurs once a screen capture is complete.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The full size image capture is available at this point as well 
    /// as the thumbnail if enabled.</para>
    /// <para>
    /// Information about the capture as well as the images is available via the 
    /// <see cref="ImageEventArgs"/> object.</para>
    /// </remarks>
    event ImageCapturedEventHandler ImageCaptured;

    /// <summary>
    /// Occurs when a plug-in is loaded but before any screen captures take place.
    /// </summary>
    event ImageCaptureInitializedEventHandler ImageCaptureInitialized;

    /// <summary>
    /// Occurs when a screen capture has started but before the image is available.
    /// </summary>
    event ImageCapturingEventHandler ImageCapturing;
}

