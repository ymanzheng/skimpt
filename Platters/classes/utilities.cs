using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Util
{

    public static class utilities
    {
        /// <summary>
        /// This delegate+method changes the textbox value to the specified text
        /// If it is invoked from a seperate thread it uses a delegate.
        /// </summary>
        /// <param name="text">The specified text to set on object</param>
        /// <param name="ctrlToChange">Object that has a Text property (textbox, label)</param>
        private delegate void SetProgramTextInvoker(string text, object ctrlToChange);
        public static void SetProgramMessage(string text, object ctrlToChange)
        {
            TextBox tempBox;
            Label tempLabel;

            if (ctrlToChange != null)
            {
                if (ctrlToChange is TextBox)
                {
                    tempBox = (TextBox)ctrlToChange;
                    if (tempBox.InvokeRequired)
                        tempBox.Invoke(new SetProgramTextInvoker(SetProgramMessage), text, ctrlToChange);
                    else
                        tempBox.Text = text;

                }
                else if (ctrlToChange is Label)
                {
                    tempLabel = (Label)ctrlToChange;
                    if (tempLabel.InvokeRequired)
                        tempLabel.Invoke(new SetProgramTextInvoker(SetProgramMessage), text, ctrlToChange);
                    else
                        tempLabel.Text = text;

                }
            }
        }
        /// <summary>
        /// The following function gets the filename as a string containing the current date and time
        /// if random file names option is selected.
        /// </summary>
        /// <param name="GetRandomFileName"></param>
        public static string GetRandomFileName(string name){
            



            DateTime systemtime = DateTime.Now; //creates variable as the current date and time

            DateTime temp1; //temprary variable for date

            TimeSpan temp2; //temprary variable for time

            string filename_random, filename_random2; //string for output of date

            string [] display_date, display_time; //string for output of time

            temp1 = systemtime.Date; //get the date part

            temp2 = systemtime.TimeOfDay; //get the time part

            filename_random = temp1.ToString();  //convert date to string and store

            filename_random2 = temp2.ToString(); //covnert time to string and store

            display_date = filename_random.Split(' '); //split is required here as the date here is dd-mm-yyyy 00:00:00, we remove the extra 0's

            display_time = filename_random2.Split('.'); //split is required here as the time here is HH:MM:SS.(MILI)SSSS, we remove the miliseconds

           

            /*

             * DEBUG: the following messagebox verifies that the time and

             * date are read as required, and also correctly. This should

             * be done before we give the string file_name a value so that

             * the correct value is given.

             * MessageBox.Show(display_date[0] + "\n" + display_time[0]);

            */

 

            //since we have the required date and time as strings, we join them to get the filename

            name = display_date[0]+ "-" + display_time[0];
            return name;
        }

    }



}
