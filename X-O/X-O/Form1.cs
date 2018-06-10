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
        Boolean vsComputer = false;
        public Form1()
        {
            InitializeComponent();
        }

        public void postaviIme(string s1, string s2)
        {
            igrach1 = s1;
            igrach2 = s2;
            p1.Text = igrach1.ToString();
            p2.Text = igrach2.ToString();
            if (igrach2.ToString().ToLower() == "computer")
            {
                vsComputer = true;
            }
            else
            {
                vsComputer = false;
            }
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
                {
                    if (vsComputer)
                    {
                        computer_make_move();
                    }else                    
                        b.Text = "O";
                }
                    
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

        private void Form1_Load(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.ShowDialog();
            postaviIme(f2.Player1, f2.Player2);
            
            
        }

        private void computer_make_move()
        {
            //priority 1:  win
            //priority 2:  block x from wining
            //priority 3:  go for center space
            //priority 4:  pick first open space

            Button move = null;

            move = look_for_win_or_block("O"); //look for win
            if (move == null)
            {
                move = look_for_win_or_block("X"); //look for block
                if (move == null)
                {
                    move = look_for_center(); //if the method is to look for free corner the computer will not be on level: hard
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }
                }
            }

            move.PerformClick();
        }
        
        private Button look_for_open_space()
        {
            Button b = null;
            foreach (Control control in Controls)
            {
                b = control as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }
            }

            return null;
        }

        private Button look_for_center()
        {
            if(B2.Text == "")
            {
                return B2;
            }

            return null;
        }

        private Button look_for_win_or_block(string mark)
        {
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }

    }
}
