using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
        }

        private void txtPath_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                txtPath.Text = Path.GetFullPath(folderBrowserDialog1.SelectedPath.ToString());
            }
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();

            if (res == DialogResult.OK)
            {
                txtPath.Text = Path.GetFullPath(folderBrowserDialog1.SelectedPath.ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string Path = folderBrowserDialog1.SelectedPath.ToString();

            if (Path == "" || Path == String.Empty)
            {
                MessageBox.Show("No valid path selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] AllFiles = Directory.GetFiles(Path);

            foreach (string FilePath in AllFiles)
            {
                if ((File.GetAttributes(FilePath) & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    File.SetAttributes(FilePath, FileAttributes.Normal);
                    lstFiles.Items.Add(FilePath);
                }
            }

            MessageBox.Show("All hidden files unhidden", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
