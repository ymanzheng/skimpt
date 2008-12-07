using System;
using System.Collections.Generic;
using System.Drawing;


public class ImageEventArgs : EventArgs 
{

    private Image _capturedImage;
    private Image _thumbnailImage;
    private string _saveFullLocation;
    private string _saveThumbLocation;
    private string _FullName;
    private string _thumbNailName;
    private string _extension;
    private DateTime _timeSaved;
    private bool _needThumbNail;


    public ImageEventArgs(Image captured, Image thumb, 
                          string FullsaveLoc, string ThumbSaveLoc, 
                          string fullname, string thumbName, string exten, 
                          DateTime datetimeSaved, bool needthumb)
    {
        _capturedImage = captured;
        _thumbnailImage = thumb;
        _saveFullLocation = FullsaveLoc;
        _saveThumbLocation = ThumbSaveLoc;
        _FullName = fullname;
        _thumbNailName = thumbName;
        _extension = exten;
        _timeSaved = datetimeSaved;
        _needThumbNail = needthumb;
    }

    public Image CapturedImage
    {
        get { return _capturedImage; }
        set { _capturedImage = value; }
    }

    public Image ThumbnailImage
    {
        get { return _thumbnailImage; }        
    }

    public string FullSaveLocation
    {
        get { return _saveFullLocation; }
    }

    public string ThumbnailSaveLocation
    {
        get { return _saveThumbLocation;  }
    }

    public string FullFileName
    {
        get { return _FullName; }
    }

    public string ThumbnailFileName
    {
        get { return _thumbNailName; }
    }

    public string Extension
    {
        get { return _extension; }
    }

    public DateTime TimeSaved
    {
        get { return _timeSaved; }
    }

    public bool NeedThumbNail
    {
        get { return _needThumbNail; }
    }

}
