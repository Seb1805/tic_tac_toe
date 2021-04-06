using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui_tic_tac_toe
{
    public partial class Form1 : Form
    {
        //string til at fortælle hvilken spiller det er på nuværende tidspunkt
        string currentPlayer = "";
        //Array der bruges til spillets resultat
        /*
         * 1 2 3
         * 4 5 6
         * 7 8 9
         * */
        static char[] board;
        
        //Funktion der bruges til at oprette et nyt spil
        void NewGame()
        {
            int i = 1;
            board = new char[]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Text = "?";
                button.Click += Button_Click;
                button.TabStop = false;
                button.Tag = i;
                i++;
            }
            currentPlayer = "O";
            SetLabelText();
        }

        public Form1()
        {
            InitializeComponent();
            NewGame();
        }

        //Click event når der klikkes på en knap
        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Text = currentPlayer;
            b.Enabled = false;
            board[int.Parse(b.Tag.ToString())] = char.Parse(currentPlayer);

            int win = CheckForWin();

            if(win == 1)
            {
                label1.Text = "Spiller " + currentPlayer + " vandt spillet!";
                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.Enabled = false;
                }
                
            }
            else if(win == -1)
            {
                label1.Text = "Spillet endte uafgjort!";
            }
            else
            {
                ChangePlayer();
            }
        }

        //Metode til at skifte spiller
        private void ChangePlayer()
        {
            if(currentPlayer == "O")
            {
                currentPlayer = "X";
            }
            else
            {
                currentPlayer = "O";
            }
            SetLabelText();
        }

        //Metode til at sætte label tekst
        private void SetLabelText()
        {
            label1.Text = "Det er " + currentPlayer + " tur!";
        }

        //Metode til at tejkke spillets resultat.
        private int CheckForWin()
        {
            #region Rækker
            //Række 1 { 1 , 2 , 3 }
            if (board[1] == board[2] && board[2] == board[3])
            {
                return 1;
            }
            //Række 2 { 4 , 5 , 6 }
            else if (board[4] == board[5] && board[5] == board[6])
            {
                return 1;
            }
            //Række 3 { 7 , 8 , 9 }
            else if (board[7] == board[8] && board[8] == board[9])
            {
                return 1;
            }
            #endregion

            #region kolonner
            //Kolonne 1 { 1 , 4 , 7 }
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            //Kolonne 2 { 2 , 5 , 8 }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }
            //Kolonne 1 { 3 , 6 , 9 }
            else if (board[3] == board[6] && board[6] == board[9])
            {
                return 1;
            }
            #endregion

            #region Diagonaler
            //Diagonal 1 { 1 , 5 , 9 }
            else if (board[1] == board[5] && board[5] == board[9])
            {
                return 1;
            }
            //Diagonal 2 { 3 , 5 , 7 }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }
            #endregion

            #region uafgjort
            else if (board[1] != '1' && board[2] != '2' && board[3] != '3' && board[4] != '4' && board[5] != '5' && board[6] != '6' && board[7] != '7' && board[8] != '8' && board[9] != '9')
            {

                return -1;

            }
            else
            {
                return 0;
            }
            #endregion
        }

    }
}
