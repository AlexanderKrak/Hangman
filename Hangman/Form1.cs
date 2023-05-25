using NUnit.Framework;
using System;
using System.Collections.Generic;
//using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hangman
{
    public partial class frmHangman : Form
    {
        string secretWord;
        byte lives = 6;
        byte secretWordLength = 0;
        byte misses = 0;
        PictureBox[] pb = new PictureBox[6];

        List<Button> buttons = new List<Button>();

        public void RoundHead()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pBoxHead.Width - 3, pBoxHead.Height - 3);
            Region rg = new Region(gp);
            pBoxHead.Region = rg;
        }

        public void Restart()
        {
            lives = 6;
            misses = 0;

            foreach (var item in buttons)
            {
                item.Visible = true;
            }

            for (int i = 0; i < pb.Length; i++)
            {
                pb[i].Visible = false; 
            }
            lbl1.Visible= false;
            lbl2.Visible= false;
            lbl3.Visible= false;
            lbl4.Visible= false;
            lbl5.Visible= false;
            lbl6.Visible= false;
            lbl7.Visible= false;
             
        }
        
        public void SetUp()
        {
            
            secretWord = GetWord.WordGetter().ToLower();
            //secretWordLength = 0;
            txtSecretWord.Text = secretWord;
            txtChars.Text = lives.ToString();

            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl1.Text = secretWord[1].ToString();
                lbl2.Text = secretWord[2].ToString();
                lbl3.Text = secretWord[3].ToString();
                lbl4.Text = secretWord[4].ToString();
                lbl5.Text = secretWord[5].ToString();
                lbl6.Text = secretWord[6].ToString();
                lbl7.Text = secretWord[7].ToString();
                lbl.Visible = false;
            }


        }
        public frmHangman()
        {
            InitializeComponent();
            SetUp();
            RoundHead();

            pb[0] = pBoxHead;
            pb[1] = pBoxBody;
            pb[2] = pBoxLeftArm;
            pb[3] = pBoxRightArm;
            pb[4] = pBoxBody;
            pb[5] = pBoxBody;
            
        }

        private void btnLetter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            txtTest.Text = /*txtTest.Text + */ button.Text;
            button.Visible = false;
            

            if (secretWord.Contains(button.Text))
            {
                foreach (Label lbl in this.Controls.OfType<Label>())
                {
                    if(lbl.Text == button.Text)
                    {
                        lbl.Visible = true;
                        lbl.Parent = pBoxBackground;
                        lbl.BackColor = Color.Transparent;
                        //lbl1.ForeColor = Color.Black;
                    }
                }

                MessageBox.Show("contains");
            }
            else
            {
                
                MessageBox.Show("Doesnt contain");
                lives--;
                txtChars.Text = lives.ToString();
                misses++;
                pb[misses - 1].Visible = true;
                if(lives == 0)
                {
                    MessageBox.Show("You re sucks.");
                    pnlRetryExit.Visible = true;
                }
            }
            buttons.Add(button);

        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            Restart();
            pnlRetryExit.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}