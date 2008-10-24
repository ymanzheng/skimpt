using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class main : Form
{
  
    public main()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Random rand = new Random();
        toastform slice = new toastform(rand.Next (500, 5000), "Slice number ");
        if (slice.InvokeRequired)
        {
            MessageBox.Show("Invoke Required");               
        }
        slice.Show();
    
    }

    private void main_Load(object sender, EventArgs e)
    {

    }

}
