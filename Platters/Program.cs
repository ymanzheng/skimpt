using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Platters
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());


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
