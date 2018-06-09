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
    public partial class Form1 : Form
    {
        bool turn = true;  // koga e true - X e na red ; inaku koga e false - O e na red
        int potezi = 0;
        static string igrach1, igrach2;
        public Form1()
        {
            InitializeComponent();
        }

        public static void postaviIme(string s1, string s2)
        {
            igrach1 = s1;
            igrach2 = s2;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(turn == true)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            potezi++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool winner = false;
            // horizontalno
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;

            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;



            // vertikalno
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;



            // dijagonalno
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;





            if (winner)
            {
                disableButtons();
                string pobednik = "";
                if (turn)
                {
                    pobednik = p2.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                    
                }
                    
                else
                {
                    pobednik = p1.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                   
                }

                MessageBox.Show(pobednik + " победи!", "Победник");
                новаИграToolStripMenuItem.PerformClick();


            }
            else
            {
                if (potezi == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Играта заврши нерешено!", "Нема победник");
                    новаИграToolStripMenuItem.PerformClick();
                }
                    
            }

        }

        private void disableButtons()
        {
            
                foreach (Control c in Controls)
                {
                    try
                    {

                        Button b = (Button)c;
                        b.Enabled = false;

                    }
                    catch { }
            }
            
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }            
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
                
            }
        }

        private void ресетирајПобедиToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void новаИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            potezi = 0;


            foreach (Control c in Controls)
            {
                try
                {

                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
        }

        private void p1_TextChanged(object sender, EventArgs e)
        {
            postaviIme(p1.Text, p2.Text);
        }

        private void p2_TextChanged(object sender, EventArgs e)
        {
            postaviIme(p1.Text, p2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            Form2 f2 = new Form2();
            f2.ShowDialog();
            p1.Text = igrach1;
            p2.Text = igrach2;
            */
        }
    }
}
