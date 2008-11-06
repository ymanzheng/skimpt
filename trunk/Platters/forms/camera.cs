using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#region ResizeRegion enum

internal enum ResizeRegion
{
    None,
    N,
    NE,
    E,
    SE,
    S,
    SW,
    W,
    NW
}

#endregion

/// <summary>
/// Represents a form for marking off the cropped area of the desktop.
/// </summary>
public class MainCropForm : LayeredForm
{
    #region Constants

    private const int ResizeBorderWidth = 15;
    private const int TransparentMargin = 40;
    private const int TabHeight = 15;
    private const int TabTopWidth = 60;
    private const int TabBottomWidth = 60;

    // Form measurments and sizes
    private const int MinimumDialogWidth = 230;
    private const int MinimumDialogHeight = 180;
    private const int DefaultSizingInterval = 1;
    private const int AlternateSizingInterval = 10;
    private const int MinimumThumbnailSize = 20;
    private const int MinimumSizeForCrosshairDraw = 30;
    private const int CrosshairLengthFromCenter = 10;
    private const int FormatDescriptionOffset = 5;
    private const int MinimumPadForFormatDescriptionDraw = 5;
    private const int DefaultMaxThumbnailSize = 80;
    private const int DefaultVisibleHeightWidth = 180;
    private const int DefaultPositionLeft = 100;
    private const int DefaultPositionTop = 100;
    private const double DefaultLayerOpacity = 0.4;

    #endregion

    #region Member Variables

    private bool showAbout;
    private bool showHelp;
    private bool isThumbnailed;
    private bool isDisposed;
    private bool highlight;
    private int colorIndex = 0;

    private main mainFormReference;

    private double maxThumbSize = DefaultMaxThumbnailSize;
    // String displayed on form describing the current output format. 
    private string outputDescription;

    private Point middle = new Point();
    private Point offset;
    private Point mouseDownPoint;

    // Point locations for drawing the tabs.
    private readonly Point[] points = new Point[]
			{
				new Point(TransparentMargin - TabHeight,
				          TransparentMargin - TabHeight),
				new Point(TransparentMargin + TabTopWidth,
				          TransparentMargin - TabHeight),
				new Point(TransparentMargin + TabBottomWidth,
				          TransparentMargin),
				new Point(TransparentMargin,
				          TransparentMargin),
				new Point(TransparentMargin,
				          TransparentMargin + TabBottomWidth),
				new Point(TransparentMargin - TabHeight,
				          TransparentMargin + TabTopWidth)
			};

    private Rectangle mouseDownRect;
    private Rectangle dialogCloseRectangle;
    private Rectangle thumbnailRectangle;
    private Rectangle visibleFormArea;
    private Size userFormSize;

    private Size thumbnailSize = new Size(DefaultMaxThumbnailSize,
                                          DefaultMaxThumbnailSize);

    private readonly Font feedbackFont = new Font("Verdana", 8f);

    // Brushes
    // TODO: [Performance] Use one brush and set colors as needed.
    // Brush for the tab background.
    private readonly SolidBrush tabBrush = new SolidBrush(Color.SteelBlue);
    private readonly SolidBrush tabTextBrush = new SolidBrush(Color.Black);
    // Brush for the visible form background.
    private readonly SolidBrush areaBrush = new SolidBrush(Color.White);
    // Brush for the visible form background.
    private readonly Pen outlinePen = new Pen(Color.Black);
    // Brush for the drawn text and lines.
    private readonly SolidBrush formTextBrush = new SolidBrush(Color.Black);


    private ColorListForForm currentColorTable = new ColorListForForm();
    private readonly ContextMenu menu = new ContextMenu();


    private ResizeRegion resizeRegion = ResizeRegion.None;
    private ResizeRegion thumbResizeRegion;


    #endregion

    #region Property Accessors

    /// <summary>
    /// Gets the visible client rectangle.
    /// </summary>
    /// <value></value>
    public Rectangle VisibleClientRectangle
    {
        get
        {
            if (isDisposed)
                throw new ObjectDisposedException(ToString());

            Rectangle visibleClient = new Rectangle(VisibleLeft,
                                                    VisibleTop,
                                                    VisibleWidth,
                                                    VisibleHeight);
            return visibleClient;
        }
    }

    #endregion

    #region Private Property Accessors

    private int VisibleWidth
    {
        get { return Width - (TransparentMargin * 2); }
        set { Width = value + (TransparentMargin * 2); }
    }

    private int VisibleHeight
    {
        get { return Height - (TransparentMargin * 2); }
        set { Height = value + (TransparentMargin * 2); }
    }

    private int VisibleLeft
    {
        get { return Left + (TransparentMargin); }
        set { Left = value - (TransparentMargin); }
    }

    private int VisibleTop
    {
        get { return Top + (TransparentMargin); }
        set { Top = value - (TransparentMargin); }
    }

    private Size VisibleClientSize
    {
        get
        {
            return new Size(VisibleWidth, VisibleHeight);
        }
        set
        {
            VisibleWidth = value.Width;
            VisibleHeight = value.Height;
        }
    }

    #endregion

    #region .ctor

    public MainCropForm(main mainRef)
    {

        mainFormReference = mainRef;


        mainFormReference.Hide();

        SetColors();
        //SetUpForm();
        Text = "Cropper";
        TopMost = true;
        // SetUpMenu();
        Process.GetCurrentProcess().MaxWorkingSet = (IntPtr)5000000;

    }

    #endregion

  

    #region Event Overrides

    #region Mouse Overrides

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
        HandleMouseDown(e);
        base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        CheckForDialogClosing();
        HandleMouseUp();
        base.OnMouseUp(e);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);
        if (e.Delta > 0)
            CenterSize(AlternateSizingInterval);
        else
            CenterSize(-AlternateSizingInterval);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.DoubleClick"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnDoubleClick(EventArgs e)
    {
        
        this.Close();
        //TakeScreenShot(ScreenShotBounds.Rectangle);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        HandleMouseMove(e);
    }

    #endregion

    /// <summary>
    /// Raises the <see cref="Form.KeyDown"/> event.
    /// </summary>
    /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
    protected override void OnKeyDown(KeyEventArgs e)
    {

        base.OnKeyDown(e);
    }


    /// <summary>
    /// Raises the <see cref="Form.Closing"/> event.
    /// </summary>
    /// <param name="e">A <see cref="CancelEventArgs"/> that contains the event data.</param>
    protected override void OnClosing(CancelEventArgs e)
    {
        if (isDisposed)
            throw new ObjectDisposedException((this).ToString());
        isDisposed = true;

        base.OnClosing(e);
    }



    protected override void OnResize(EventArgs e)
    {
        middle.X = (VisibleWidth / 2) + TransparentMargin;
        middle.Y = (VisibleHeight / 2) + TransparentMargin;

        if (VisibleWidth <= 1)
            VisibleWidth = 1;
        if (VisibleHeight <= 1)
            VisibleHeight = 1;

        visibleFormArea = new Rectangle(TransparentMargin,
                                        TransparentMargin,
                                        VisibleWidth - 1,
                                        VisibleHeight - 1);

        if (showAbout || showHelp)
        {
            showAbout = false;
            showHelp = false;
        }

        //send the x, y, and width, height to main program
        mainFormReference.CameraCoords = visibleFormArea;
        base.OnResize(e);
       
    }

    protected override void OnPaintLayer(PaintLayerEventArgs e)
    {
        PaintUI(e.Graphics);
        base.OnPaintLayer(e);
    }

    protected override void OnLoad(EventArgs e)
    {
        NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_BIG, Icon.Handle);
        // NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_SMALL, notifyIcon.Icon.Handle);
        NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETTEXT, 0, Text);
        base.OnLoad(e);
    }

    protected override void OnClosed(EventArgs e)
    {

        NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_BIG, IntPtr.Zero);
        NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_SMALL, IntPtr.Zero);
        NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETTEXT, 0, null);
        base.OnClosed(e);
        mainFormReference.Show();
    }

    #endregion

    #region Form Manipulation

    private void HandleMouseUp()
    {
        resizeRegion = ResizeRegion.None;
        thumbResizeRegion = ResizeRegion.None;
        Cursor = Cursors.Default;
    }

    private void HandleMouseDown(MouseEventArgs e)
    {
        offset = new Point(e.X, e.Y);
        mouseDownRect = ClientRectangle;
        mouseDownPoint = MousePosition;

        if (IsInResizeArea())
            resizeRegion = GetResizeRegion();
        else if (IsInThumbnailResizeArea())
            thumbResizeRegion = ResizeRegion.SE;
    }



    private void HandleMouseMove(MouseEventArgs e)
    {
        bool mouseIsInResizeArea = resizeRegion != ResizeRegion.None;
        bool mouseIsInThumbResizeArea = thumbResizeRegion != ResizeRegion.None;

        if (mouseIsInResizeArea)
        {
            HandleResize();
        }
        else if (mouseIsInThumbResizeArea)
        {
            HandleThumbResize();
        }
        else
        {
            bool mouseOnFormShouldMove = e.Button == MouseButtons.Left;
            bool mouseInResizeAreaCanResize = IsInResizeArea() && e.Button != MouseButtons.Left;
            bool mouseInThumbResizeAreaCanResize = IsInThumbnailResizeArea() && e.Button != MouseButtons.Left;
            bool mouseNotInResizeArea = resizeRegion == ResizeRegion.None;
            bool mouseNotInThumbResizeArea = thumbResizeRegion == ResizeRegion.None;

            if (mouseOnFormShouldMove)
                Location = CalculateNewFormLocation();

            if (mouseInResizeAreaCanResize)
                SetResizeCursor(GetResizeRegion());
            else if (mouseInThumbResizeAreaCanResize)
                SetResizeCursor(ResizeRegion.SE);
            else if (mouseNotInResizeArea && mouseNotInThumbResizeArea && !mouseOnFormShouldMove)
                Cursor = Cursors.Default;
        }
    }

    private void ResizeThumbnail(int interval)
    {
        maxThumbSize = maxThumbSize + interval;
        if (maxThumbSize < MinimumThumbnailSize)
            maxThumbSize = MinimumThumbnailSize;
        PaintLayeredWindow();
    }

    private ResizeRegion GetResizeRegion()
    {
        Point clientCursorPos = PointToClient(MousePosition);
        if (
            (clientCursorPos.X >= (Width - (TransparentMargin + ResizeBorderWidth))) &
            (clientCursorPos.Y >= (Height - (TransparentMargin + ResizeBorderWidth))))
            return ResizeRegion.SE;
        else if (clientCursorPos.X >= (Width - (TransparentMargin + ResizeBorderWidth)))
            return ResizeRegion.E;
        else if (clientCursorPos.Y >= (Height - (TransparentMargin + ResizeBorderWidth)))
            return ResizeRegion.S;
        else
            return ResizeRegion.None;
    }

    private void HandleResize()
    {
        int diffX = MousePosition.X - mouseDownPoint.X;
        int diffY = MousePosition.Y - mouseDownPoint.Y;

        FreezePainting = true;
        switch (resizeRegion)
        {
            case ResizeRegion.E:
                Width = mouseDownRect.Width + diffX;
                break;
            case ResizeRegion.S:
                Height = mouseDownRect.Height + diffY;
                break;
            case ResizeRegion.SE:
                Width = mouseDownRect.Width + diffX;
                Height = mouseDownRect.Height + diffY;
                break;
        }
        FreezePainting = false;
    }

    private void HandleThumbResize()
    {
        int diffX = MousePosition.X - mouseDownPoint.X;
        int diffY = MousePosition.Y - mouseDownPoint.Y;

        mouseDownPoint.X = MousePosition.X;
        mouseDownPoint.Y = MousePosition.Y;

        ResizeThumbnail(diffX + diffY);
        PaintLayeredWindow();
    }

    private void AdjustPosition(int interval, Keys keys)
    {
        switch (keys)
        {
            case Keys.Left:
                Left = Left - interval;
                break;
            case Keys.Right:
                Left = Left + interval;
                break;
            case Keys.Up:
                Top = Top - interval;
                break;
            case Keys.Down:
                Top = Top + interval;
                break;
        }
    }

    private void AdjustSize(int interval, Keys keys)
    {
        switch (keys)
        {
            case Keys.Left:
                Width = Width - interval;
                break;
            case Keys.Right:
                Width = Width + interval;
                break;
            case Keys.Up:
                Height = Height - interval;
                break;
            case Keys.Down:
                Height = Height + interval;
                break;
        }
    }

    private void CenterSize(int interval)
    {
        if (interval < -AlternateSizingInterval || interval > AlternateSizingInterval)
            throw new ArgumentOutOfRangeException("interval");

        if (VisibleWidth > interval & VisibleHeight > interval)
        {
            int interval2 = interval * 2;
            Width = Width - interval2;
            Left = Left + interval;
            Height = Height - interval2;
            Top = Top + interval;
        }
    }

    private void CycleColors()
    {
        SetColors();
    }

    private void CycleSizes()
    {
        //Size size = Configuration.Current.NextFormSize();
        //if (size != Size.Empty)
        //    VisibleClientSize = size;
    }

    private void SetColors()
    {

        int areaAlpha = 105;

        LayerOpacity = 1.0;
        currentColorTable.MainAlphaChannel = areaAlpha;


        tabBrush.Color = currentColorTable.TabColor;
        areaBrush.Color = currentColorTable.FormColor;
        formTextBrush.Color = currentColorTable.FormTextColor;
        tabTextBrush.Color = currentColorTable.TabTextColor;
        outlinePen.Color = currentColorTable.LineColor;
        PaintLayeredWindow();
    }

    private bool IsInResizeArea()
    {
        Point clientCursorPos = PointToClient(MousePosition);

        Rectangle clientVisibleRect = ClientRectangle;
        clientVisibleRect.Inflate(-TransparentMargin, -TransparentMargin);

        Rectangle resizeInnerRect = clientVisibleRect;
        resizeInnerRect.Inflate(-ResizeBorderWidth, -ResizeBorderWidth);

        return (clientVisibleRect.Contains(clientCursorPos) && !resizeInnerRect.Contains(clientCursorPos));
    }

    private bool IsInThumbnailResizeArea()
    {
        Point clientCursorPos = PointToClient(MousePosition);

        Rectangle resizeInnerRect = new Rectangle(thumbnailRectangle.Right - 15,
                                                  thumbnailRectangle.Bottom - 15,
                                                  15, 15);

        return (resizeInnerRect.Contains(clientCursorPos));
    }

    private void SetResizeCursor(ResizeRegion region)
    {
        switch (region)
        {
            case ResizeRegion.S:
                Cursor = Cursors.SizeNS;
                break;
            case ResizeRegion.E:
                Cursor = Cursors.SizeWE;
                break;
            case ResizeRegion.SE:
                Cursor = Cursors.SizeNWSE;
                break;
            default:
                Cursor = Cursors.Default;
                break;
        }
    }

    private bool IsMouseInRectangle(Rectangle rectangle)
    {

        if (!isDisposed)
        {

            Point clientCursorPos = PointToClient(MousePosition);
            return (rectangle.Contains(clientCursorPos));
        }
        else
        { return false; }


    }

    private Point CalculateNewFormLocation()
    {
        return new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y);
    }

    #endregion


    #region Helper Methods

    private void CheckForDialogClosing()
    {
        if (IsMouseInRectangle(dialogCloseRectangle))
        {
            VisibleClientSize = userFormSize;
            dialogCloseRectangle.Inflate(-dialogCloseRectangle.Size.Width, -dialogCloseRectangle.Size.Height);
            showAbout = false;
            showHelp = false;
            PaintLayeredWindow();
        }
    }



    private void SetUpForm()
    {


        Show();
    }

    private static void ShowError(string text, string caption)
    {
        ShowMessage(text, caption, MessageBoxIcon.Error);
    }

    private static void ShowMessage(string text, string caption, MessageBoxIcon icon)
    {
        MessageBox.Show(text, caption, MessageBoxButtons.OK, icon);
    }

    #endregion

    #region Painting

    private void PaintUI(Graphics graphics)
    {
        if (currentColorTable != null)
        {
            PaintMainFormArea(graphics, visibleFormArea);
            PaintSizeTabs(graphics, points);
            if (showHelp)
                DrawHelp(graphics);
            else if (showAbout)
                DrawAbout(graphics);
            else
            {
                PaintThumbnailIndicator(graphics, VisibleWidth, VisibleHeight);
                PaintCrosshairs(graphics, VisibleWidth, VisibleHeight);
            }
            Point grabberCorner = new Point(Width - TransparentMargin, Height - TransparentMargin);
            PaintGrabber(graphics, grabberCorner);
            PaintOutputFormat(graphics, VisibleWidth, VisibleHeight);
            PaintWidthString(graphics, VisibleWidth);
            PaintHeightString(graphics, VisibleHeight);
        }
    }


    private void PaintGrabber(Graphics graphics, Point grabberStart)
    {
        int yOffset = grabberStart.Y - 4;
        int xOffset = grabberStart.X - 4;
        graphics.DrawLine(outlinePen, grabberStart.X - 5, yOffset, xOffset, grabberStart.Y - 5);
        graphics.DrawLine(outlinePen, grabberStart.X - 10, yOffset, xOffset, grabberStart.Y - 10);
        graphics.DrawLine(outlinePen, grabberStart.X - 15, yOffset, xOffset, grabberStart.Y - 15);
    }

    private void PaintSizeTabs(Graphics graphics, Point[] tabPoints)
    {
        graphics.FillPolygon(tabBrush, tabPoints);
    }

    private void PaintMainFormArea(Graphics graphics, Rectangle cropArea)
    {
        if (highlight)
            outlinePen.Color = currentColorTable.LineHighlightColor;
        else
            outlinePen.Color = currentColorTable.LineColor;
        graphics.FillRectangle(areaBrush, cropArea);
        graphics.DrawRectangle(outlinePen, cropArea);
    }

    private void PaintThumbnailIndicator(Graphics graphics, int paintWidth, int paintHeight)
    {
        if (isThumbnailed)
        {
            double thumbRatio;
            if (paintHeight > paintWidth)
                thumbRatio = paintHeight / maxThumbSize;
            else
                thumbRatio = paintWidth / maxThumbSize;
            thumbnailSize.Width = Convert.ToInt32(paintWidth / thumbRatio);
            thumbnailSize.Height = Convert.ToInt32(paintHeight / thumbRatio);

            if (paintWidth > (thumbnailSize.Width + 50) && paintHeight > (thumbnailSize.Height + 30))
            {
                string size = thumbnailSize.Width + "x" + thumbnailSize.Height;
                string max = maxThumbSize + " px max";
                SizeF dimensionSize = graphics.MeasureString(size, feedbackFont);
                SizeF maxSize = graphics.MeasureString(max, feedbackFont);

                graphics.DrawString(
                    max,
                    feedbackFont,
                    formTextBrush,
                    middle.X - (maxSize.Width / 2),
                    middle.Y - (thumbnailSize.Height / 2) - maxSize.Height);

                graphics.DrawString(
                    size,
                    feedbackFont,
                    formTextBrush,
                    middle.X - (dimensionSize.Width / 2),
                    middle.Y + (thumbnailSize.Height / 2));

                thumbnailRectangle = new Rectangle(
                    middle.X - (thumbnailSize.Width / 2),
                    middle.Y - (thumbnailSize.Height / 2),
                    thumbnailSize.Width,
                    thumbnailSize.Height);

                graphics.DrawRectangle(
                    outlinePen, thumbnailRectangle);

                if (thumbnailRectangle.Height > 22)
                {
                    Point grabberCorner = new Point(thumbnailRectangle.Right, thumbnailRectangle.Bottom);
                    PaintGrabber(graphics, grabberCorner);
                }
            }
        }
    }

    private void PaintHeightString(Graphics graphics, int paintHeight)
    {
        graphics.RotateTransform(90);
        graphics.DrawString(
            paintHeight + " px",
            feedbackFont,
            tabTextBrush,
            TransparentMargin,
            -TransparentMargin);
    }

    private void PaintWidthString(Graphics graphics, int paintWidth)
    {
        graphics.DrawString(
            paintWidth + " px",
            feedbackFont,
            tabTextBrush,
            TransparentMargin,
            TransparentMargin - 15);
    }

    private void PaintOutputFormat(Graphics graphics, int paintWidth, int paintHeight)
    {
        SizeF formatSize = graphics.MeasureString(outputDescription, feedbackFont);
        if (formatSize.Width + MinimumPadForFormatDescriptionDraw < paintWidth &&
            formatSize.Height + MinimumPadForFormatDescriptionDraw < paintHeight)
        {
            graphics.DrawString(
                outputDescription,
                feedbackFont,
                formTextBrush,
                TransparentMargin + FormatDescriptionOffset,
                TransparentMargin + FormatDescriptionOffset);
        }
    }

    private void PaintCrosshairs(Graphics graphics, int paintWidth, int paintHeight)
    {
        if (paintWidth > MinimumSizeForCrosshairDraw & paintHeight > MinimumSizeForCrosshairDraw)
        {
            graphics.DrawLine(
                outlinePen,
                middle.X,
                (middle.Y) + CrosshairLengthFromCenter,
                middle.X,
                (middle.Y) - CrosshairLengthFromCenter);

            graphics.DrawLine(
                outlinePen,
                (middle.X) + CrosshairLengthFromCenter,
                middle.Y,
                (middle.X) - CrosshairLengthFromCenter,
                middle.Y);
        }
    }

    private void DrawAbout(Graphics g)
    {
        //DrawDialog(g, "About Cropper v" + Application.ProductVersion, SR.MessageAbout);
    }

    private void DrawHelp(Graphics g)
    {
        // DrawDialog(g, "Help", SR.MessageHelp);
    }

    private void DrawDialog(Graphics g, string title, string text)
    {
        StringFormat format = new StringFormat(StringFormatFlags.NoClip);
        format.Alignment = StringAlignment.Near;
        format.LineAlignment = StringAlignment.Center;

        Rectangle aboutRectangle = new Rectangle((Width / 2) - 90, (Height / 2) - 60, MinimumDialogHeight, 120);

        // Box
        //
        g.FillRectangle(Brushes.SteelBlue, aboutRectangle);
        g.DrawRectangle(Pens.Black, aboutRectangle);

        //Contents
        //
        aboutRectangle.Inflate(-5, -5);
        aboutRectangle.Y = aboutRectangle.Y + 5;

        Font textFont = new Font("Arial", 8f);
        //Draw text
        //
        g.DrawString(text, textFont, Brushes.White, aboutRectangle, format);

        //Title
        //
        aboutRectangle.Inflate(5, -47);
        aboutRectangle.Y = (Height / 2) - 60;
        g.FillRectangle(Brushes.Black, aboutRectangle);
        g.DrawRectangle(Pens.Black, aboutRectangle);

        aboutRectangle.Inflate(-5, 0);
        g.DrawString(title, textFont, Brushes.White, aboutRectangle, format);

        //Close
        //
        aboutRectangle.Inflate(-78, 0);
        aboutRectangle.X = (Width / 2) + 76;
        g.FillRectangle(Brushes.Red, aboutRectangle);
        g.DrawRectangle(Pens.Black, aboutRectangle);

        StringFormat closeFormat = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.DirectionVertical);
        format.Alignment = StringAlignment.Near;
        format.LineAlignment = StringAlignment.Center;

        Font closeFont = new Font("Verdana", 10.5f, FontStyle.Bold);
        aboutRectangle.Inflate(3, -1);
        g.DrawString("X",
                     closeFont,
                     Brushes.White,
                     aboutRectangle,
                     closeFormat);

        dialogCloseRectangle = aboutRectangle;
        format.Dispose();
        closeFormat.Dispose();
        textFont.Dispose();
        closeFont.Dispose();
    }

    #endregion

    #region Other Event Handling



    ///// <summary>
    ///// Handles the MouseUp event of the NotifyIcon control.
    ///// </summary>
    ///// <param name="sender">The source of the event.</param>
    ///// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    //private void HandleNotifyIconMouseUp(object sender, MouseEventArgs e)
    //{
    //    if (e.Button == MouseButtons.Left)
    //        CycleFormVisibility(false);
    //}

    #endregion

    #region IDisposable Implementation

    protected override void Dispose(bool disposing)
    {
        isDisposed = true;
        if (disposing)
        {
            if (null != feedbackFont)
                feedbackFont.Dispose();
            if (null != menu)
                menu.Dispose();
            if (null != tabBrush)
                tabBrush.Dispose();
            if (null != areaBrush)
                areaBrush.Dispose();
            if (null != formTextBrush)
                formTextBrush.Dispose();
            if (null != outlinePen)
                outlinePen.Dispose();
        }
        base.Dispose(disposing);
    }

    #endregion
}
