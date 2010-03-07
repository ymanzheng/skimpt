using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Skimpt3.GUI {
    public partial class FirstTime : Form {
        private static Skimpt3.Properties.Settings mySettings = new Skimpt3.Properties.Settings();

        public FirstTime() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {         
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                defaultImageTextbox.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(defaultImageTextbox.Text) || !System.IO.Directory.Exists(defaultImageTextbox.Text)) {
                MessageBox.Show("I need a filepath", "error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                if (string.IsNullOrWhiteSpace(apiTextBox.Text))
                    MessageBox.Show("no API key given, you wont be able to upload!");
                mySettings.FirstTime = false;
                mySettings.APIKey = apiTextBox.Text;
                mySettings.ImageFileLocation = defaultImageTextbox.Text;
                mySettings.Save();
                this.Close();
            }   
         
        }
    }

}
