using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Skimpt3.classes {
    class skImageCapture {
      
        private Rectangle rec;

        /// Intro to DCs:  
        /// If you are familiar, skip ahead. If not, read on.
        /// Device contexts are just generic ways to represent devices,
        /// or things you can draw on or interact with graphically. 
        /// This is hugely over simplified, and I'm going to get flamed, but for the sake of brevity,
        /// let's just go with that for now. You can get device context's, or dc's as 
        /// they are commonly referred to, from images, windows, monitors, and even printers. 
        /// Every window has them, and you can use them to draw with. Everything you see on your screen is being 
        /// drawn upon a device context. The desktop, every window, your taskbar, and anything you see. 
        /// You can draw upon them, or copy what they have drawn upon them. If you can get a hold of them, 
        /// you can pretty much draw or steal whatever you want graphically speaking. 
        /// Working with device contexts is fast, and both GDI and GDI+ are based on them.
        /// in the case of capturing the screen, we know that somewhere Windows is drawing upon a device context, so that we can see it. 
        /// In fact, there's one for each monitor you have attached to your system, and that desktop that you are seeing on it, 
        /// is being drawn on that monitor's device context. 
        /// All we have to do is grab a hold of that device context, create another one of our own, 
        /// and copy the screen's device context image data to our own, and we've got a screen capture
        /// 
        public static Bitmap GetDesktopWindowCaptureAsBitmap()
    {
        //SEE HOW THIS FUNCTION WORKS AT THE END OF THIS FUNCTION.
        Rectangle rcScreen = Rectangle.Empty;
        Screen[] screens = Screen.AllScreens;


        // Create a rectangle encompassing all screens...
        foreach (Screen screen in Screen.AllScreens)
            rcScreen = Rectangle.Union(rcScreen, screen.Bounds);

        // Create a composite bitmap of the size of all screens...
        Bitmap finalBitmap = new Bitmap(rcScreen.Width, rcScreen.Height);

        // Get a graphics object for the composite bitmap and initialize it...
        Graphics g = Graphics.FromImage(finalBitmap);
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        g.FillRectangle(
           SystemBrushes.Desktop,
           0,
           0,
           rcScreen.Width - rcScreen.X,
           rcScreen.Height - rcScreen.Y);

        // Get an HDC for the composite area...
        IntPtr hdcDestination = g.GetHdc();

        // Now, loop through screens, 
        // Blting each to the composite HDC created above...
        foreach (Screen screen in Screen.AllScreens)
        {
            // Create DC for each source monitor...
            IntPtr hdcSource = Win32.CreateDC(
              IntPtr.Zero,
              screen.DeviceName,
              IntPtr.Zero,
              IntPtr.Zero);

            // Blt the source directly to the composite destination...
            int xDest = screen.Bounds.X - rcScreen.X;
            int yDest = screen.Bounds.Y - rcScreen.Y;

            bool success = Win32.StretchBlt(
              hdcDestination,
              xDest,
              yDest,
              screen.Bounds.Width,
              screen.Bounds.Height,
              hdcSource,
              0,
              0,
              screen.Bounds.Width,
              screen.Bounds.Height,
              (int)Win32.TernaryRasterOperations.SRCCOPY);

            //  System.Diagnostics.Trace.WriteLine(screen.Bounds);

            if (!success)
            {
                System.ComponentModel.Win32Exception win32Exception =
                    new System.ComponentModel.Win32Exception();
                System.Diagnostics.Trace.WriteLine(win32Exception);
            }

            // Cleanup source HDC...
            Win32.DeleteDC(hdcSource);
        }

        // Cleanup destination HDC and Graphics...
        g.ReleaseHdc(hdcDestination);
        g.Dispose();

        // Return composite bitmap which will become our Form's PictureBox's image...
        return finalBitmap;

        ///Looking at the code, the first thing you'll see is that I'm using a mixture of GDI and GDI+. 
        ///This is due largely to the fact that there is a bug present in GDI+ and the BtBlt API.           
        ///This issue only manifests itself on systems with multiple monitors, and if I remember correctly,
        ///the system had to have a NVida display adapter on the non-primary monitor, and of course, our old friend Windows 98 running as the OS.
        ///What happens is the primary monitor captures fine, the secondary (or any non-primary) monitor stands a chance of returning garbage for an image. 
        ///It looks like cable channel with no signal.  

        ///Instead of relying on purely managed code, do copy the images, 
        ///or backing up to the BtBlt API, we instead fall back to it's somewhat slower cousin, StretchBlt.       

        ///first up we just grab all of the monitors using the Screen class' AllScreens property. 
        ///This does two things for us. First it allows us to figure out how big the entire desktop is, 
        ///and create an image just big enough to hold all of the screens inside. 
        ///And secondly, it allows us to figure out just where each monitor is positioned in relation to the other.
        ///Remember, with multiple monitor support you can "arrange" your monitors in different ways,
        ///and with different resolutions, so don't think in terms of a pure rectangle when you think of
        ///how your monitors are positioned.

        ///Once we have those screens, it's a trivial matter to calculate the size of the entire bitmap
        ///by using the Rectangle.Union method to build up the size of the overall image. 
        ///After we've figured out the size of the final image, we'll grab a Graphics object from the image.
        ///The GDI+ Graphics object is just the .NET wrapper around a device context.
        ///Using that graphics context, we can draw on the bitmap with the graphics object.

        ///Next, we'll enumerate through each monitor, and draw what that monitor has on it's device context,
        ///upon the image we just created that will hold the final screen shot. 
        ///Well draw it using it's coordinates so that in case the monitors have different resolutions or positioning
        ///we'll be able to see them as the Display Control Panel applet sees them.
        ///Go check it out if you have multiple monitors, and you didn't know you could move them.
        ///Chances are there if you have multiple monitors, you know this already, but if not so harm no foul.
        ///Open the settings tab and drag one of the monitors around and 
        ///you'll see you can reposition it in relation to the other monitors.

        ///For each monitor, we'll simply use the StretchBlt API to copy that monitor's device context contents,
        ///to the bitmap that will serve as the screen capture of the desktop. 
        ///Notice that I'm creating a device context each time, this gives us access to that monitor's device context so 
        ///that we can copy from it. Keep in mind that if we create it, we must destroy it, 
        ///so we delete the device context when we are finished with it. If you don't, you'll have a memory leak,
        ///so keep a watchful eye on your dc's and make sure to release or destroy them.
        ///A simple rule is, if you "acquire" it, you're required to "release" it. 
        ///And if you "create" it, then you must "destroy" it. 
        ///I quote those because if you look at the GDI APIs, with that in mind you'll find the necessary APIs to do exactly what you want.

        ///Finally, after copying the contents of each device context to that bitmap we created, 
        ///we'll release the Graphics object we acquired from the bitmap, and dispose it.
        ///That's the proper way to clean up a graphics object, if you've acquired a device context from it.


    }

    public static Bitmap CaptureDeskTopRectangle(Rectangle CapRect, int CapRectWidth, int CapRectHeight)
    {

        //This function just calls the GetDesktop, and just crops it.
        Bitmap bmpImage = new Bitmap(GetDesktopWindowCaptureAsBitmap());
        Bitmap bmpCrop = new Bitmap(CapRectWidth, CapRectHeight, bmpImage.PixelFormat);
        Rectangle recCrop = new Rectangle(CapRect.X, CapRect.Y, CapRectWidth, CapRectHeight);
        Graphics gphCrop = Graphics.FromImage(bmpCrop);
        Rectangle recDest = new Rectangle(0, 0, CapRectWidth, CapRectHeight);
        gphCrop.DrawImage(bmpImage, recDest, recCrop.X, recCrop.Y, recCrop.Width, recCrop.Height, GraphicsUnit.Pixel);
        return bmpCrop;
    }



// 
// Credits: Mark (Code6) Belles C# version
//               Me :+)) for the porting code
//               Thanks to EVA for g->ReleaseHDC or you may have a black screen
//               and MSDN http://msdn2.microsoft.com/en-us/library/ms533843(VS.85).aspx
// Enjoy: Feel free to use it....
//
//#include "stdafx.h"
//#include <windows.h>
//#include <gdiplus.h>

//#pragma comment(lib, "gdiplus.lib")

//#define SAFE_DELETE(ptrToDelete) if (ptrToDelete != NULL) { delete ptrToDelete; ptrToDelete = NULL; }

//ULONG_PTR     gdiplusToken;
//int m_nScreenCount;
//RECT m_ScreensRect[8];
//TCHAR m_ScreensName[8][CCHDEVICENAME];

//BOOL CALLBACK MyInfoEnumProcs( HMONITOR hMonitor, HDC hdcMonitor,
//                                                                      LPRECT lprcMonitor, LPARAM dwData )
//{
//     MONITORINFOEX monitorInfo;
//     memcpy(&m_ScreensRect[m_nScreenCount], lprcMonitor, sizeof(RECT));

//     memset(&monitorInfo, 0x0, sizeof(MONITORINFOEX));
//     monitorInfo.cbSize = sizeof(MONITORINFOEX);
//     GetMonitorInfo(hMonitor, &monitorInfo);

//     strcpy_s((char *) &m_ScreensName[m_nScreenCount], CCHDEVICENAME, monitorInfo.szDevice);

//     m_nScreenCount++;
//     return TRUE;
//}

//int GetEncoderClsid(const WCHAR* format, CLSID* pClsid)
//{
//   UINT   num = 0;               // number of image encoders
//   UINT   size = 0;            // size of the image encoder array
//                                       // in bytes

//   Gdiplus::ImageCodecInfo* pImageCodecInfo = NULL;

//   Gdiplus::GetImageEncodersSize(&num, &size);
//   if(size == 0)
//      return -1;

//   pImageCodecInfo = (Gdiplus::ImageCodecInfo*)(malloc(size));
//   if(pImageCodecInfo == NULL)
//      return -1;

//   GetImageEncoders(num, size, pImageCodecInfo);

//   for(UINT j = 0; j < num; ++j)
//   {
//      if( wcscmp(pImageCodecInfo[j].MimeType, format) == 0 )
//      {
//         *pClsid = pImageCodecInfo[j].Clsid;
//         free(pImageCodecInfo);
//         return j;   // Success
//      }
//   }

//   free(pImageCodecInfo);
//   return -1;
//}

//int _tmain(int argc, _TCHAR* argv[])
//{
//     Gdiplus::GdiplusStartupInput gdiplusStartupInput;
//     gdiplusToken = NULL;

//     if (GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, NULL) != Gdiplus::Ok)
//     {
//          gdiplusToken = NULL;
//     }

//     memset(&m_ScreensRect, 0x0, sizeof(m_ScreensRect));
//     memset(&m_ScreensName, 0x0, sizeof(m_ScreensName));
//     EnumDisplayMonitors(NULL, NULL, MyInfoEnumProcs, 0);

//     HDC hdcDestination = NULL;

//     RECT rcScreen;
//     memset(&rcScreen, 0x0, sizeof(rcScreen));

//     for(int screenCount=0; screenCount < m_nScreenCount; screenCount++) 
//     {
//          UnionRect(&rcScreen, &rcScreen, &m_ScreensRect[screenCount]);
//     }

//     // Create a composite bitmap of the size of all screens...
//     Gdiplus::Bitmap* finalBitmap = new Gdiplus::Bitmap(rcScreen.right, rcScreen.bottom);

//     // Get a graphics object for the composite bitmap and initialize it...
//     Gdiplus::Graphics * g = Gdiplus::Graphics::FromImage(finalBitmap);     

//     g->SetCompositingQuality(Gdiplus::CompositingQualityHighSpeed);

//     Gdiplus::SolidBrush solidBrush(Gdiplus::Color(0,0,0));
//     g->FillRectangle(&solidBrush, 0, 0, rcScreen.right, rcScreen.bottom);

//     // Get an HDC for the composite area...
//     hdcDestination = g->GetHDC();

//     // Now, loop through screens, BitBlting each to the composite HDC created above...
//     for(int screenCount=0; screenCount < m_nScreenCount; screenCount++) 
//     {
//          // Create DC for each source monitor...
//          HDC hdcSource = CreateDC(NULL, m_ScreensName[screenCount], NULL, NULL);

//          // Blt the source directly to the composite destination...
//          int xDest = m_ScreensRect[screenCount].left - rcScreen.left;
//          int yDest = m_ScreensRect[screenCount].top - rcScreen.top;

//          StretchBlt(hdcDestination, xDest, yDest, m_ScreensRect[screenCount].right, m_ScreensRect[screenCount].bottom, 
//                        hdcSource, 0, 0, m_ScreensRect[screenCount].right, m_ScreensRect[screenCount].bottom, SRCCOPY | CAPTUREBLT);
          
//          // Cleanup source HDC...
//          DeleteDC(hdcSource);                    
//     }

//     g->ReleaseHDC(hdcDestination);

//     CLSID clsidJPEG;
//     GetEncoderClsid(L"image/jpeg", &clsidJPEG);
//     finalBitmap->Save(L"c:\\screenshot.jpg", &clsidJPEG); 
//     GetEncoderClsid(L"image/gif", &clsidJPEG);
//     finalBitmap->Save(L"c:\\screenshot.gif", &clsidJPEG); 
//     GetEncoderClsid(L"image/bmp", &clsidJPEG);
//     finalBitmap->Save(L"c:\\screenshot.bmp", &clsidJPEG); 

//     // Cleanup destination HDC and Graphics...
//     DeleteDC(hdcDestination);
//     SAFE_DELETE(g);
//     SAFE_DELETE(finalBitmap);

//     return 0;
//}

    }
}
