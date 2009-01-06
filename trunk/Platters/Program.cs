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
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;
using System.ComponentModel;
using System.Drawing;


namespace Platters
{
    static class Program 
    {

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            if(args.Length > 0)
            {
                //we have a context menu item... 
                string filename = args[0].ToLower();
          
                //check for valid item
                if(System.IO.File.Exists(filename))
                {

                    //check if its a valid picture format. 
                    if(System.IO.Path.GetExtension(filename) == ".jpg") {
                        Util.utilities.ShowToastForm(filename);
                    } else if(System.IO.Path.GetExtension(filename) == ".psd") {
                        //its a PSD file.
                        
                        //save a local copy of the PSD as jpeg
                        //double check location
                        if(System.IO.File.Exists(filename)) {
                            Photoshop.PsdFile psd = new Photoshop.PsdFile();
                            //load the file
                            psd.Load(filename);
                            //decode the image
                            Image myPsdImage = Photoshop.ImageDecoder.DecodeImage(psd);
                            //create new filename string
                            string newfilename = System.IO.Path.GetFileNameWithoutExtension(filename) + "-skimpt" + ".jpg";
                            myPsdImage.Save(newfilename);
                            Util.utilities.ShowToastForm(newfilename);                            
                        }
                    } else {
                        Util.utilities.ShowMessage("Not a valid file", "failed");
                    }
                }
            }
            else
            {
                bool firstInstance;
                Mutex mutex = new Mutex(false, "Local\\" + "SkimptProgramRunning", out firstInstance);

                if(firstInstance)
                {                    
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new main());
                }
            }
            
            //wait till all toast forms are closed
            while(Application.OpenForms.Count > 0)
                Application.DoEvents();
        
                
             //   Logger logger = new Logger(3, "test.txt");


             //   for (int x = 0; x < 100; x++)
             //   {
             //       for (int i = 0; i < 100; i++)
             //       {
             //           logger.log(i % 6, "TEST", "message " + i);
             //       }
             //       //Thread.Sleep(500);
             //   }
             //MessageBox.Show ((DateTime.Now.ToFileTime() / 10000).ToString());
             //   //			logger.log(0, "TEST", "message 1");
             //   //			logger.log(1, "TEST", "message 2");
             //   //			logger.log(2, "TEST", "message 3");
             //   //System.Console.ReadLine();
             //   logger.shutdown();                   
        }   
    }
}
