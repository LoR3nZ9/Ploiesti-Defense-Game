using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RobotDefense
{
    public partial class Form1 : Form
    {

        Int16 x = 256, y = 450, scorPlayer = 0, scorInamic = 0, nivel = 0;
        Point pozitiePlayer, pozitieInamic, pozitieLaser;
        Random rnd = new Random();

        private void timerSpatiu_Tick(object sender, EventArgs e)
        {
            if (nivel == 0)

                pozitieLaser.Y -= 10;
            pozitieInamic.Y += 5;


            if (scorPlayer > 5 && scorPlayer <= 10)
            {
                nivel = 1;
                label2.Text = "Nivel dificultate: MEDIUM";
                pozitieLaser.Y -= 10;
                pozitieInamic.Y += 2;
            }
            if (scorPlayer > 10 && scorPlayer <= 15)
            {
                nivel = 1;
                label2.Text = "Nivel dificultate: HIGH";
                pozitieLaser.Y -= 10;
                pozitieInamic.Y += 2;
            }
            
            if (pozitieInamic.Y >= 594)
            {
                pozitieInamic.Y = 1;
                pozitieInamic.X = rnd.Next(1, 594);
                scorInamic++;
                label1.Text = "Player=" + scorPlayer + "  Inamic=" + scorInamic;
            }
            if (pictureBox2.Bounds.IntersectsWith(pictureBox1.Bounds) || scorPlayer == 15)
            {
                timerSpatiu.Stop();
                label2.Text = "GAME WIN";
            }
            if (pictureBox2.Bounds.IntersectsWith(pictureBox1.Bounds) || scorInamic == 2)
            {
                timerSpatiu.Stop();
                label2.Text = "GAME OVER";
            }
           
            if (pictureBox3.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                pozitieInamic.Y = 1;
                pozitieInamic.X = rnd.Next(1, 594);
                scorPlayer++;
                label1.Text = "Player=" + scorPlayer + "  Inamic=" + scorInamic;
            }           
            pictureBox2.Invalidate();
            pictureBox2.Location = pozitieInamic;
            pictureBox3.Invalidate();
            pictureBox3.Location = pozitieLaser;
        }
       
        public Form1()
        {
            InitializeComponent();
            pozitieInamic.X = 190;
            pozitiePlayer.Y = 594;
            DoubleBuffered = true;
        }
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Space)
            {
                pozitieLaser.X = pozitiePlayer.X + 30;
                pozitieLaser.Y = 512;

            }
            if (e.KeyData == Keys.Left)
                x -= 20;
            if (x <= 1)
                x = 1;
            if (x >= 762)
                x = 762;
            if (e.KeyData == Keys.Right)
                x += 20;
            pozitiePlayer.X = x;
            pictureBox1.Invalidate();
            pictureBox1.Location = pozitiePlayer;
            
        }
        
    }
}
