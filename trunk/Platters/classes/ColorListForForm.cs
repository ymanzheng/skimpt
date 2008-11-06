using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


class ColorListForForm
{
    private int tabAlphaChannel = 200;
    private int mainAlphaChannel;

    public int MainAlphaChannel
    {
        get { return mainAlphaChannel; }
        set { mainAlphaChannel = value; }
    }

    public int TabAlphaChannel
    {
        get { return tabAlphaChannel; }
        set { tabAlphaChannel = value; }
    }


    public Color TabColor
    {
        get { return Color.FromArgb(tabAlphaChannel, SystemColors.Highlight); }
    }

    public Color TabHighlightColor
    {
        get { return Color.FromArgb(tabAlphaChannel, SystemColors.Highlight); }
    }
    public Color TabTextColor
    {
        get { return SystemColors.HighlightText; }
    }

    public Color TabTextHighlightColor
    {
        get { return SystemColors.HighlightText; }
    }

    public Color FormColor
    {
        get { return Color.FromArgb(mainAlphaChannel, 194, 207, 229); }
    }

    public Color FormHighlightColor
    {
        get { return Color.FromArgb(mainAlphaChannel, 194, 207, 229); }
    }

    public Color FormTextColor
    {
        get { return SystemColors.Highlight; }
    }

    public Color FormTextHighlightColor
    {
        get { return SystemColors.Highlight; }
    }

    public Color LineColor
    {
        get { return SystemColors.Highlight; }
    }

    public Color LineHighlightColor
    {
        get { return Color.Firebrick; }
    }

}

