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
    }



}
