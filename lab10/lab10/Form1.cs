using lab10.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
namespace lab10
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer ballTimer;
        private List<PictureBox> balls;
        private PictureBox Unicorn;
        private int collectedPoints = 0;
        private int ballSpeed = 10;
        private string playerName = "";
        private int score = 0;
        private Random random = new Random();
        private bool handleCreated = false;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
        Thread thread1;

        private void InitializeGame()
        {
            ballTimer = new System.Windows.Forms.Timer();
            ballTimer.Interval = 50;
            ballTimer.Tick += BallTimer_Tick;

            balls = new List<PictureBox>();
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(() =>
                {
                    Color ballColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    CreateBall(ballColor);
                });
                thread.Start();
            }
            unicorn = new PictureBox();
            unicorn.Image = Resources.unicorn;
            unicorn.Top = ClientSize.Height - unicorn.Height;
            unicorn.Left = (ClientSize.Width - unicorn.Width) / 2;
            this.Controls.Add(unicorn);

            collectedPoints = 0;
            ballTimer.Start();

        }
        private void CreateBall(Color color)
        {
            PictureBox ball = new PictureBox();
            ball.BackColor = color;
            ball.Height = 20;
            ball.Width = 20;
            ball.Top = -ball.Height;
            ball.Left = random.Next(ClientSize.Width - ball.Width);
            balls.Add(ball);

            if (InvokeRequired) // Check if invoke is required
            {
                Invoke((MethodInvoker)delegate
                {
                    Controls.Add(ball);
                });
            }
            else
            {
                Controls.Add(ball);
            }
        }
        private void BallTimer_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox ball in balls)
            {
                ball.Top += ballSpeed;

                if (ball.Bounds.IntersectsWith(unicorn.Bounds))
                {
                    collectedPoints++;
                    ball.Top = -ball.Height;
                }

                if (ball.Top > ClientSize.Height)
                {
                    ball.Top = -ball.Height;
                    ball.Left = random.Next(ClientSize.Width - ball.Width);
                }
            }

            if (collectedPoints == 5)
            {
                ballTimer.Stop();
            }

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    Invalidate();
                });
            }
            else
            {
                Invalidate();
            }

        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int head_x = unicorn.Location.X;
            int head_y = unicorn.Location.Y;

            if (e.KeyCode == Keys.Left && unicorn.Left > 0)
            {
                unicorn.Left -= 20;
            }
            else if (e.KeyCode == Keys.Right && unicorn.Right < ClientSize.Width)
            {
                unicorn.Left += 20;
            }

            Point pp = new Point(head_x, head_y);
            unicorn.Location = pp;
        }
    }
}