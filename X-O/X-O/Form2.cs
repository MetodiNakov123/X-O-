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
        public String Player1;
        public String Player2;

        public Form2()
        {
            InitializeComponent();
            Player1 = "Igrac 1";
            Player2 = "Igrac 2";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!p1.Text.Trim().ToString().Equals(""))
            {
                Player1 = p1.Text.Trim().ToString();
            }
            if (!p2.Text.Trim().ToString().Equals(""))
            {
                Player2 = p2.Text.Trim().ToString();
            }
            this.Close();
        }

        private void p2_KeyPress(object sender, KeyPressEventArgs e) // ako si vo posledniot TextBox za iminja i kliknesh Enter avtomatski kako da si kliknal Играј
        {
           
            if (e.KeyChar.ToString() == "\r")
                button1.PerformClick();
            
        }
    }
}
