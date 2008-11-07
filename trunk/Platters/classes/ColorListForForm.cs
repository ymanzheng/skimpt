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

