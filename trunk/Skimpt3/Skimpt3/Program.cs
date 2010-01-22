using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Skimpt3.classes;
using System.Threading;
using System.Net;
using System.Text;
using System.IO;
using System.Web;



namespace Skimpt3 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
         //("C:\\Users\\Affan\\Pictures\\4popped.jpg");        



            if (args.Length > 0) {
                //we have a context menu item... 
                string filename = args[0].ToLower();
                //check for valid item
                if (System.IO.File.Exists(filename)) {

                    //check if its a valid picture format. 
                    if (Common.IsValidImage(filename)) {
                        skImage ski = new skImage(Image.FromFile(filename), filename, true);
                        //ski.Invert();
                        //ski.Save();
                        Common.ShowToastForm(ski);
                    } else if (System.IO.Path.GetExtension(filename) == ".psd") {
                        //its a PSD file.
                        //save a local copy of the PSD as jpeg
                        //double check location
                        Photoshop.PsdFile psd = new Photoshop.PsdFile();
                        //load the file
                        psd.Load(filename);
                        //decode the image
                        Image myPsdImage = Photoshop.ImageDecoder.DecodeImage(psd);
                        skImage ski = new skImage(myPsdImage, string.Empty, false);
                        Common.ShowToastForm(ski);
                    }
                    //exit silently
                }
            } else {
                bool firstInstance;
                Mutex mutex = new Mutex(false, "Local\\" + "SkimptProgramRunning", out firstInstance);

                if (firstInstance) {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new GUI.test());

                    Console.WriteLine("reach?");
                }
            }
        
            //wait till all toast forms are closed
            while (Application.OpenForms.Count > 0)
                Application.DoEvents();

        }
    }
}
