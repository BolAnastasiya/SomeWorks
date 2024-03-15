using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Labb3
{
    public partial class Form31 : Form
    {
        public Form31()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double rub = double.Parse(textBox1.Text);
            double usd = 0;
            usd = Math.Round(rub / 74.76, 2);
            double eur = 0;
            eur = Math.Round(rub / 79.61, 2);
            if (radioButton1.Checked)
            {
                textBox3.Text = $"{usd}";
                textBox2.Text = $"{eur}";
            }
            if (radioButton2.Checked)
            {
                if (usd > 1000 || eur > 1000)
                {
                    textBox3.Text = $"{usd - ((usd * 5) / 100)}";
                    textBox2.Text = $"{eur - ((eur * 5) / 100)}";
                }
            }
        }
    }
}
