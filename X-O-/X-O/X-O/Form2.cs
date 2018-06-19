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
        public String X, O;

        public Form2()
        {
            InitializeComponent();
            Player1 = "Igrac 1";
            Player2 = "Igrac 2";
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton2.Checked) {
                X = "X";
                O = "O";
            }
            if (radioButton1.Checked) {
                X = "O";
                O = "X";
            }

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

        private void Form2_Load(object sender, EventArgs e) {
            
            Form3 form = new Form3();

            DialogResult res = form.ShowDialog();

            if (res.Equals(DialogResult.OK)) {

                radioButton1.Visible = true;
                radioButton2.Visible = true;
                p2.Text = "computer";
                p2.Visible = false;
                label2.Visible = false;
            }
            if (res.Equals(DialogResult.Abort)) {
                label3.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                p2.Visible = true;
                label2.Visible = true;
            }

            if (res.Equals(DialogResult.Cancel)) {
               Application.Exit();
            }


            }
    }
}
