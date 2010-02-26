using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Skimpt3.classes {
    public class Common {
        private static Skimpt3.Properties.Settings mySettings = new Skimpt3.Properties.Settings();
      
        public static void ShowMessage(string message, string caption) {
            if (mySettings.ShowErrorMessageBox)
                System.Windows.Forms.MessageBox.Show(message, caption, System.Windows.Forms.MessageBoxButtons.OK);
        }
        

        /// <summary>
        /// This function, when executed, shows the toast form
        /// with animation. 
        /// </summary>
        /// <param name="ski">An skImage instance stored in memory</param>
        public static void ShowToastForm(skImage ski) {
            //create a new toastform instance.
            toastform slice = new toastform(ski);
            slice.Show();
        }

        /// <summary>
        /// This function checks for a valid image file.
        /// </summary>
        /// <remarks>Stolen from stackoverflow.com</remarks>
        /// <param name="filename">Full path needed</param>
        public static bool IsValidImage(string filename) {
            try {
                Image newImage = Image.FromFile(filename);               
                return true;
            } catch (Exception ex) {                
                return false;
            }          
        }

        public static System.Drawing.Imaging.ImageFormat GetFormat(Image im) {
            Console.WriteLine(im.RawFormat.ToString());
            Console.WriteLine(System.Drawing.Imaging.ImageFormat.Jpeg.ToString());
            if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return System.Drawing.Imaging.ImageFormat.Png;
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return System.Drawing.Imaging.ImageFormat.Tiff;
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Wmf))
                return System.Drawing.Imaging.ImageFormat.Wmf;
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return System.Drawing.Imaging.ImageFormat.Bmp;
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return System.Drawing.Imaging.ImageFormat.Gif;
            else
                return System.Drawing.Imaging.ImageFormat.Jpeg; //return jpeg as default
        }

        public static string GetFormatString(Image im) {
            Console.WriteLine(im.RawFormat.ToString());
            Console.WriteLine(System.Drawing.Imaging.ImageFormat.Jpeg.ToString());
            if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return "jpeg";
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return "png";
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return "tiff";
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Wmf))
                return "wmf";
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return "bmp";
            else if (im.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return "gif";
            else
                return "jpg"; //return jpeg as default
        }

        public static string getHash(int charCount) {
            if (charCount <= 0)
                throw new Exception("File hash needs more then 0 characters to build");

            const string legalCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < charCount; i++) {
                ch = legalCharacters[random.Next(0, legalCharacters.Length)];
                builder.Append(ch);
            }
            return builder.ToString(); 
        }
 
    }
}
