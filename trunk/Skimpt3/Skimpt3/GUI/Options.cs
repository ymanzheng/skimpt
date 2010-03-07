using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
    using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Skimpt3.GUI {
    public partial class Options : Form {
        private static Skimpt3.Properties.Settings mySettings = new Skimpt3.Properties.Settings();
        public Options() {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e) {
            apiTextBox.Text = mySettings.APIKey;
            defaultImageText.Text = mySettings.ImageFileLocation;
            maskedTextBox1.Text = (mySettings.ToastFormTimer / 1000).ToString();
            optimizeImageCheckBox.Checked = mySettings.OptimizeImage;
            errorMessagecheckBox.Checked = mySettings.ShowErrorMessageBox;
            versionLabel.Text = "Running: " + Application.ProductName + " : " + Application.ProductVersion + " " ;
        }

        private void button3_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                defaultImageText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            //submit button pressed
            if (string.IsNullOrWhiteSpace(defaultImageText.Text) || !System.IO.Directory.Exists(defaultImageText.Text)) {
                MessageBox.Show("I need a filepath", "error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                if (string.IsNullOrWhiteSpace(apiTextBox.Text))
                    MessageBox.Show("no API key given, you wont be able to upload!");             
                mySettings.APIKey = apiTextBox.Text;
                mySettings.ImageFileLocation = defaultImageText.Text;
                mySettings.ShowErrorMessageBox = errorMessagecheckBox.Checked;

                int timer = Convert.ToInt32(maskedTextBox1.Text);
                if ((timer * 1000) != mySettings.ToastFormTimer) {
                    if (timer > 60 || timer < 0) {
                        timer = 10000;
                    } else {
                        if ((timer % 5) != 0)
                            timer += (5 - (timer % 5)); 
                    }
                }               
                mySettings.ToastFormTimer = timer * 1000;             
                mySettings.Save();
                this.Close();
            }   
        }

        private void button4_Click(object sender, EventArgs e) {
            classes.skContextHandler ch = new classes.skContextHandler();
            if (removeContext.Checked) {
                if (!ch.Add()) {
                    MessageBox.Show("Unable to add to windows", "failed");
                }
            } else {
                if (!classes.skContextHandler.Remove()) {
                    MessageBox.Show("Unable to remove context handler");
                } else {
                    MessageBox.Show("context handler removed successfully!");
                }
            }
         

        }
    }
}
