using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Dyscord
{
    public partial class HangmanForm : Form
    {
        //answer 
        public string answerString;

        //string that changes as the user gets a letter right 
        public string currentString;

        //lives that -1 when user gets a letter wrong
        public int lives;

        //used to see if guesser won and got all letters
        public int score;
        public HangmanForm(Form startGameForm)
        {
            InitializeComponent();

            this.Owner = startGameForm;
            this.answerString = startGameForm.answer.ToLower();
            this.lives = 6;

            //display placement of letters w/ underscores
            String startingString = "";
            for (int i = 0; i < answerString.Length; i++)
            {
                if (answerString[i] == ' ')
                {
                    startingString += " ";
                }
                else
                {
                    startingString += "_";
                }
            }
            this.archiveRichTextBox.Text = startingString;
            currentString = startingString;

            this.aButton.Click += new EventHandler(aButton__Click);
            this.bButton.Click += new EventHandler(bButton__Click);
            this.cButton.Click += new EventHandler(cButton__Click);
            this.dButton.Click += new EventHandler(dButton__Click);
            this.eButton.Click += new EventHandler(eButton__Click);
            this.fButton.Click += new EventHandler(fButton__Click);
            this.gButton.Click += new EventHandler(gButton__Click);
            this.hButton.Click += new EventHandler(hButton__Click);
            this.iButton.Click += new EventHandler(iButton__Click);
            this.jButton.Click += new EventHandler(jButton__Click);
            this.kButton.Click += new EventHandler(kButton__Click);
            this.lButton.Click += new EventHandler(lButton__Click);
            this.mButton.Click += new EventHandler(mButton__Click);
            this.nButton.Click += new EventHandler(nButton__Click);
            this.oButton.Click += new EventHandler(oButton__Click);
            this.pButton.Click += new EventHandler(pButton__Click);
            this.qButton.Click += new EventHandler(qButton__Click);
            this.rButton.Click += new EventHandler(rButton__Click);
            this.sButton.Click += new EventHandler(sButton__Click);
            this.tButton.Click += new EventHandler(tButton__Click);
            this.uButton.Click += new EventHandler(uButton__Click);
            this.vButton.Click += new EventHandler(vButton__Click);
            this.wButton.Click += new EventHandler(wButton__Click);
            this.xButton.Click += new EventHandler(xButton__Click);
            this.yButton.Click += new EventHandler(yButton__Click);
            this.zButton.Click += new EventHandler(zButton__Click);

        }

        private void aButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('a'))
            {
             currentString = replaceUnderscore('a', currentString);
              aButton.Enabled = false;
            } 
            else
            {
              loseLife();
              aButton.Enabled = false;
            }
        }

        private void bButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('b'))
            {
                currentString = replaceUnderscore('b', currentString);
                bButton.Enabled = false;
            }
            else
            {
                loseLife();
                bButton.Enabled = false;
            }
        }

        private void cButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('c'))
            {
                currentString = replaceUnderscore('c', currentString);
                cButton.Enabled = false;
            }
            else
            {
                loseLife();
                cButton.Enabled = false;
            }

        }

        private void dButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('d'))
            {
                currentString = replaceUnderscore('d', currentString);
                dButton.Enabled = false;
            }
            else
            {
                loseLife();
                dButton.Enabled = false;
            }
        }

        private void eButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('e'))
            {
                currentString = replaceUnderscore('e', currentString);
                eButton.Enabled = false;
            }
            else
            {
                loseLife();
                eButton.Enabled = false;
            }
        }

        private void fButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('f'))
            {
                currentString = replaceUnderscore('f', currentString);
                fButton.Enabled = false;
            }
            else
            {
                loseLife();
                fButton.Enabled = false;
            }
        }

        private void gButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('g'))
            {
                currentString = replaceUnderscore('g', currentString);
                gButton.Enabled = false;
            }
            else
            {
                loseLife();
                gButton.Enabled = false;
            }
        }

        private void hButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('h'))
            {
                currentString = replaceUnderscore('h', currentString);
                hButton.Enabled = false;
            }
            else
            {
                loseLife();
                hButton.Enabled = false;
            }
        }

        private void iButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('i'))
            {
                currentString = replaceUnderscore('i', currentString);
                iButton.Enabled = false;
            }
            else
            {
                loseLife();
                iButton.Enabled = false;
            }
        }

        private void jButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('j'))
            {
                currentString = replaceUnderscore('j', currentString);
                jButton.Enabled = false;
            }
            else
            {
                loseLife();
                jButton.Enabled = false;
            }
        }

        private void kButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('k'))
            {
                currentString = replaceUnderscore('k', currentString);
                kButton.Enabled = false;
            }
            else
            {
                loseLife();
                kButton.Enabled = false;
            }
        }

        private void lButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('l'))
            {
                currentString = replaceUnderscore('l', currentString);
                lButton.Enabled = false;
            }
            else
            {
                loseLife();
                lButton.Enabled = false;
            }
        }

        private void mButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('m'))
            {
                currentString = replaceUnderscore('m', currentString);
                mButton.Enabled = false;
            }
            else
            {
                loseLife();
                mButton.Enabled = false;
            }
        }

        private void nButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('n'))
            {
                currentString = replaceUnderscore('n', currentString);
                nButton.Enabled = false;
            }
            else
            {
                loseLife();
                nButton.Enabled = false;
            }
        }

        private void oButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('o'))
            {
                currentString = replaceUnderscore('o', currentString);
                oButton.Enabled = false;
            }
            else
            {
                loseLife();
                oButton.Enabled = false;
            }
        }

        private void pButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('p'))
            {
                currentString = replaceUnderscore('p', currentString);
                pButton.Enabled = false;
            }
            else
            {
                loseLife();
                pButton.Enabled = false;
            }
        }

        private void qButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('q'))
            {
                currentString = replaceUnderscore('q', currentString);
                qButton.Enabled = false;
            }
            else
            {
                loseLife();
                qButton.Enabled = false;
            }
        }

        private void rButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('r'))
            {
                currentString = replaceUnderscore('r', currentString);
                rButton.Enabled = false;
            }
            else
            {
                loseLife();
                rButton.Enabled = false;
            }
        }

        private void sButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('s'))
            {
                currentString = replaceUnderscore('s', currentString);
                sButton.Enabled = false;
            }
            else
            {
                loseLife();
                sButton.Enabled = false;
            }
        }

        private void tButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('t'))
            {
                currentString = replaceUnderscore('t', currentString);
                tButton.Enabled = false;
            }
            else
            {
                loseLife();
                tButton.Enabled = false;
            }
        }

        private void uButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('u'))
            {
                currentString = replaceUnderscore('u', currentString);
                uButton.Enabled = false;
            }
            else
            {
                loseLife();
                uButton.Enabled = false;
            }
        }

        private void vButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('v'))
            {
                currentString = replaceUnderscore('v', currentString);
                vButton.Enabled = false;
            }
            else
            {
                loseLife();
                vButton.Enabled = false;
            }
        }

        private void wButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('w'))
            {
                currentString = replaceUnderscore('w', currentString);
                wButton.Enabled = false;
            }
            else
            {
                loseLife();
                wButton.Enabled = false;
            }
        }

        private void xButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('x'))
            {
                currentString = replaceUnderscore('x', currentString);
                xButton.Enabled = false;
            }
            else
            {
                loseLife();
                xButton.Enabled = false;
            }
        }

        private void yButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('y'))
            {
                currentString = replaceUnderscore('y', currentString);
                yButton.Enabled = false;
            }
            else
            {
                loseLife();
                yButton.Enabled = false;
            }
        }

        private void zButton__Click(object sender, EventArgs e)
        {
            if (answerString.Contains('z'))
            {
                currentString = replaceUnderscore('z', currentString);
                zButton.Enabled = false;
            }
            else
            {
                loseLife();
                zButton.Enabled = false;
            }
        }

        private string replaceUnderscore(Char letter, String phrase)
        {
            String newPhrase = "";
            for(int i = 0; i < phrase.Length; i++)
            {
                if(phrase[i] == letter)
                {
                    newPhrase += letter;
                    score++;
                } else
                {
                    newPhrase += phrase[i];
                }
            }
            this.archiveRichTextBox.Text = newPhrase;
            return newPhrase;
        }

        private void loseLife()
        {
            lives--;
            if(lives == 6)
            {
                pictureBox1.Load("https://people.rit.edu/~jrt5717/hangman/2.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if(lives == 5)
            {
                pictureBox1.Load("https://people.rit.edu/~jrt5717/hangman/3.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (lives == 4)
            {
                pictureBox1.Load("https://people.rit.edu/~jrt5717/hangman/4.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (lives == 3)
            {
                pictureBox1.Load("https://people.rit.edu/~jrt5717/hangman/5.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (lives == 2)
            {
                pictureBox1.Load("https://people.rit.edu/~jrt5717/hangman/6.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (lives == 1)
            {
                pictureBox1.Load("https://people.rit.edu/~jrt5717/hangman/7.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                endGame();
            }

        }

        private void endGame()
        {
            pictureBox1.Load("https://people.rit.edu/~jrt5717/hangman/1.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            IPAddress iPAddress = IPAddress.Parse(Owner.targetIp);
            IPEndPoint remoteEndPoint = new IPEndPoint(iPAddress, Owner.targetPort);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(remoteEndPoint);
            Stream netStream = new NetworkStream(server);
            StreamWriter writer = new StreamWriter(netStream);

            if (score == answerString.Length)
            {
                this.archiveRichTextBox.Text = answerString + "/n You won!";
                writer.Write("You lost!");
            }
            else
            {
                this.archiveRichTextBox.Text = answerString + "/n You lost";
                writer.Write("You won!");
            }

            

            writer.Close();
            netStream.Close();
            server.Close();
        }
    }
}
