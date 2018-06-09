using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_O
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.postaviIme(p1.Text, p2.Text);
            this.Close();
        }

        private void p2_KeyPress(object sender, KeyPressEventArgs e) // ako si vo posledniot TextBox za iminja i kliknesh Enter avtomatski kako da si kliknal Играј
        {
            if (e.KeyChar.ToString() == "\r")
                button1.PerformClick();
        }
    }
}
