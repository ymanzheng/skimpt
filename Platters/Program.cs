using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
