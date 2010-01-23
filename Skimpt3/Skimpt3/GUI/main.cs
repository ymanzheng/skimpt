using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skimpt3.classes;

namespace Skimpt3.GUI
{
    public partial class main : Form
    {
        private enum mode
        {
            FullScreen,
            CameraMode,
            HighlightMode,
        };

        private skKeyboardHook KeyboardHookInstance;
        private mode CurrentMode = mode.FullScreen;

        public main()
        {
            InitializeComponent();
            //The following sets up a hook as soon as the program is launched.
            KeyboardHookInstance = new skKeyboardHook();
            KeyboardHookInstance.KeyIntercepted += new KeyboardEventHandler(KeyboardHookInstance_KeyIntercepted);            
        }

        private void KeyboardHookInstance_KeyIntercepted(KeyboardHookEventArgs keyboardEvents)
        {
            skImage myImage = null;           
            if (keyboardEvents.PressedKey == Keys.PrintScreen)
            {               
                switch (CurrentMode)
                {                    
                    case mode.FullScreen:
                        var i = skImageCapture.GetDesktopWindowCaptureAsBitmap();
                        myImage = new skImage(i, string.Empty, false);
                        break;
                    case mode.CameraMode:
                        break;
                    case mode.HighlightMode:
                        break;
                    default:
                        MessageBox.Show("unable to capture screen");
                        break;
                }

                if (myImage != null)
                {
                    Common.ShowToastForm(myImage);
                }

            }
        }

        
    
    }
}
