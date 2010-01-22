using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skimpt3.classes;

namespace Skimpt3.GUI {
    public partial class test : Form {
             skKeyboardHook KeyboardHookInstance;

             GlobalHotkeys hotkey;
             public test() {
                 InitializeComponent();
                 //The following sets up a hook as soon as the program is launched.
                 KeyboardHookInstance = new skKeyboardHook();
                 KeyboardHookInstance.KeyIntercepted += new KeyboardEventHandler(KeyboardHookInstance_KeyIntercepted);
             }

             void KeyboardHookInstance_KeyIntercepted(KeyboardHookEventArgs keyboardEvents) {

                 Console.WriteLine(keyboardEvents.PressedKey);
               
             }

        private void test_Load(object sender, EventArgs e) {
                


                 hotkey = new GlobalHotkeys();
                 hotkey.RegisterGlobalHotKey((int)Keys.F11, GlobalHotkeys.MOD_CONTROL);
                // hotkey.UnregisterGlobalHotKey();
        }
        protected override void WndProc(ref Message m) {
            const int WM_HOTKEY = 0x0312;

            switch (m.Msg) {
                case WM_HOTKEY:
                    if ((short)m.WParam == hotkey.HotkeyID) {
                        Console.WriteLine("fuck yea");
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            WindowLayer mc = new WindowLayer();
            mc.Show();
        }
    }
}
