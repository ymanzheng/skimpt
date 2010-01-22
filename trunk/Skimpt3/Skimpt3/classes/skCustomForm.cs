using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Skimpt3.classes {
    public  class skCustomForm : Form {

        [Category("Appearance"),
            Description("Occurs when the layered form needs repainting.")]
        protected event EventHandler<PaintLayerEventArgs> PaintLayer;
        private bool freezePainting;
        private double layerOpacity = 1.0;

        public double LayerOpacity {
            get { return layerOpacity; }
            set {
                if (value > 1)
                    layerOpacity = 1.0;
                else if (value < 0)
                    layerOpacity = 0.0;
                else
                    layerOpacity = value;

                PaintLayeredWindow();
            }
        }

        private byte LayerOpacityAsByte {
            get { return ((byte)(layerOpacity * 255)); }
        }

        public bool FreezePainting {
            get { return freezePainting; }
            set {
                if (value == false)
                    PaintLayeredWindow();
                //paint layer
                freezePainting = value;
            }
        }



        protected skCustomForm() {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Console.WriteLine("Base - constructor");
        }

        /// <summary>
        /// Raises the <see cref="PaintLayer"/> event.
        /// </summary>
        /// <param name="e">A <see cref="PaintLayerEventArgs"/> object containing the 
        /// event data.</param>
        protected virtual void OnPaintLayer(PaintLayerEventArgs e) {
            Console.WriteLine("onPaintLayer base");

            EventHandler<PaintLayerEventArgs> handler = PaintLayer;
            if (!DesignMode && (handler != null))
                PaintLayer(this, e);
        }

        protected void PaintLayeredWindow() {
            if (Bounds.Size != Size.Empty) {
                using (Bitmap surface = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format32bppArgb))
                    PaintLayeredWindow(surface, layerOpacity);
            }
          
        }

        protected void PaintLayeredWindow(Bitmap bitmap, double opacity) {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ArgumentException("The bitmap must be 32bpp with an alpha-channel.", "bitmap");

            layerOpacity = opacity;

            using (PaintLayerEventArgs args = new PaintLayerEventArgs(bitmap)) {
                OnPaintLayer(args);
                PaintNative(bitmap, LayerOpacityAsByte);
            }
            Console.WriteLine("PaintLayerdWindow base");
        }

        private void PaintNative(Bitmap bitmap, byte opacity) {
            IntPtr hdcDestination = NativeMethods.GetDC(IntPtr.Zero);
            IntPtr hdcSource = NativeMethods.CreateCompatibleDC(hdcDestination);
            IntPtr hdcBitmap = IntPtr.Zero;
            IntPtr previousBitmap = IntPtr.Zero;
            try {
                hdcBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                previousBitmap = NativeMethods.SelectObject(hdcSource, hdcBitmap);

                NativeMethods.SIZE size = new NativeMethods.SIZE(bitmap.Width, bitmap.Height);
                NativeMethods.POINT source = new NativeMethods.POINT(0, 0);
                NativeMethods.POINT destination = new NativeMethods.POINT(Left, Top);
                NativeMethods.BLENDFUNCTION blend = new NativeMethods.BLENDFUNCTION();

                blend.BlendOp = NativeMethods.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = NativeMethods.AC_SRC_ALPHA;

                NativeMethods.UpdateLayeredWindow(
                    Handle,
                    hdcDestination,
                    ref destination,
                    ref size,
                    hdcSource,
                    ref source,
                    0,
                    ref blend,
                    2);
            } catch (Exception) {
                return;
            } finally {
                NativeMethods.ReleaseDC(IntPtr.Zero, hdcDestination);
                if (hdcBitmap != IntPtr.Zero) {
                    NativeMethods.SelectObject(hdcSource, previousBitmap);
                    NativeMethods.DeleteObject(hdcBitmap);
                }
                NativeMethods.DeleteDC(hdcSource);
            }
        }

        protected override void OnResize(EventArgs e) {
            if (!freezePainting) {
                PaintLayeredWindow();
                base.OnResize(e);
            }
            Console.WriteLine("Onresize - base");
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cParams = base.CreateParams;
                cParams.ExStyle |= NativeMethods.WS_EX_LAYERED;
                return cParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent) {
            // Eat event to prevent rendering error when WM_PAINT message 
            // is sent.
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // skCustomForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "skCustomForm";
            this.Load += new System.EventHandler(this.skCustomForm_Load);
            this.ResumeLayout(false);

        }

        private void skCustomForm_Load(object sender, EventArgs e) {

        }



    }

    public class PaintLayerEventArgs : EventArgs, IDisposable {
        #region Member Fields

        private readonly Graphics graphics;
        private readonly Bitmap surface;
        private readonly Size size;

        #endregion

        #region Property Accessors

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public Rectangle Bounds {
            get { return new Rectangle(Point.Empty, Size); }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size Size {
            get { return size; }
        }

        /// <summary>
        /// Gets the graphics.
        /// </summary>
        /// <value>The graphics.</value>
        public Graphics Graphics {
            get { return graphics; }
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>The image.</value>
        internal Bitmap Image {
            get { return surface; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PaintLayerEventArgs"/> class.
        /// </summary>
        public PaintLayerEventArgs() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaintLayerEventArgs"/> class.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        internal PaintLayerEventArgs(Bitmap bitmap) {
            surface = bitmap;
            graphics = Graphics.FromImage(surface);
            //graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            size = new Size(bitmap.Width, bitmap.Height);
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose() {
            if (graphics != null)
                graphics.Dispose();
            if (surface != null)
                surface.Dispose();
        }
    }

    internal sealed class NativeMethods {
        //============== GDI32 CONSTANTS =============== 
        public const Int32 CAPTUREBLT = 0x40000000;
        public const Int32 BLACKNESS = 0x42;
        public const Int32 DSTINVERT = 0x550009;
        public const Int32 MERGECOPY = 0xc000ca;
        public const Int32 MERGEPAINT = 0xbb0226;
        public const Int32 NOTSRCCOPY = 0x330008;
        public const Int32 NOTSRCERASE = 0x1100a6;
        public const Int32 PATCOPY = 0xf00021;
        public const Int32 PATINVERT = 0x5a0049;
        public const Int32 PATPAINT = 0xfb0a09;
        public const Int32 SRCAND = 0x8800c6;
        public const Int32 SRCCOPY = 0xcc0020;
        public const Int32 SRCERASE = 0x440328;
        public const Int32 SRCINVERT = 0x660046;
        public const Int32 SRCPAINT = 0xee0086;
        public const Int32 WHITENESS = 0xff0062;

        public const Int32 HORZRES = 8;
        public const Int32 VERTRES = 10;
        //=========================================== 

        private NativeMethods() { }

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vic);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern ushort GlobalAddAtom(string lpString);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern ushort GlobalDeleteAtom(ushort nAtom);

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetWindow(IntPtr hwnd, int cmd);

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hdcDest, Int32 nXDest, Int32 nYDest, Int32 nWidth, Int32 nHeight, IntPtr hdcSrc, Int32 nXSrc, Int32 nYSrc, Int32 dwRop);


        internal const Int32 WM_SETICON = 0x80;
        internal const Int32 WM_SETTEXT = 0x000c;
        internal const Int32 GW_OWNER = 4;
        internal const Int32 ICON_SMALL = 0;
        internal const Int32 ICON_BIG = 1;
        internal const Int32 WS_EX_LAYERED = 0x80000;
        internal const Int32 WM_HOTKEY = 0x0312;

        internal const Byte AC_SRC_OVER = 0x00;
        internal const Byte AC_SRC_ALPHA = 0x01;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct BLENDFUNCTION {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT {
            public int X;
            public int Y;

            public POINT(int x, int y) {
                X = x;
                Y = y;
            }

            public static explicit operator POINT(Point pt) {
                return new POINT(pt.X, pt.Y);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SIZE {
            public int Width;
            public int Height;

            public SIZE(int w, int h) {
                Width = w;
                Height = h;
            }
        }

        internal static IntPtr GetTopLevelOwner(IntPtr hWnd) {
            IntPtr hwndOwner = hWnd;
            IntPtr hwndCurrent = hWnd;
            while (hwndCurrent != (IntPtr)0) {
                hwndCurrent = GetWindow(hwndCurrent, GW_OWNER);
                if (hwndCurrent != (IntPtr)0) {
                    hwndOwner = hwndCurrent;
                }
            }
            return hwndOwner;
        }
    }
}
