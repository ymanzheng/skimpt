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

            
             public test() {
                 InitializeComponent();
                 //The following sets up a hook as soon as the program is launched.
                 KeyboardHookInstance = new skKeyboardHook();
                 KeyboardHookInstance.KeyIntercepted += new KeyboardEventHandler(KeyboardHookInstance_KeyIntercepted);
             }

             void KeyboardHookInstance_KeyIntercepted(KeyboardHookEventArgs keyboardEvents) {

                 Console.WriteLine(keyboardEvents.PressedKey);
               
             }               
    

        private void button1_Click(object sender, EventArgs e) {
            WindowLayer mc = new WindowLayer();
            mc.OutputDescription = "Camera Mode Enabled";
            mc.Show();
        }

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
