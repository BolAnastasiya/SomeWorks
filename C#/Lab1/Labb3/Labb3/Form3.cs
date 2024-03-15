using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labb3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        bool k = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (TB.Text == "1234567890")
            {
                k = true;
                Form3.ActiveForm.Close();
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(k == false)
            {
                Environment.Exit(0);
            }
            
        }
    }
}
