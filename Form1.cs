using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 6;
        int gravity = 5;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            pipebottom.Left -= pipeSpeed;
            pipetop.Left -= pipeSpeed;
            scoreText.Text = score.ToString();

            if(pipebottom.Left < -50)
            {
                pipebottom.Left = 150;
                score++;
            }
            if(pipetop.Left < -90)
            {
                pipetop.Left = 100;
                score++;
            }
            if(flappybird.Bounds.IntersectsWith(pipebottom.Bounds)||
               flappybird.Bounds.IntersectsWith(pipebottom.Bounds)||
               flappybird.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endGame();
            }
            if(score>5)
            {
                pipeSpeed = 8;
            }
            if(flappybird.Top < -20)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "Game Over!!!";
        }
    }
}
