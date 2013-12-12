using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snake_game
{
    public partial class MainForm : Form
    {
        Random randFood = new Random();

        Graphics paper;
        Snake snakes = new Snake();
        Food food;
        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;

        //public snake_game.MyPipeline pp;

        public void config(bool _left, bool _right, bool _up, bool _down)
        {
            left = _left;
            right = _right;
            up = _up;
            down = _down;
        }
        int score = 0;
        static int dem = 0;
        public MainForm()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            snakes.drawSnake(paper);
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                codesmeshlabel.Text= "";
                spaceBarLabel.Text = "";
                down = false;
                up = false;
                left = false;
                right = true;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //left = pp1.getLeft();
            //right = pp1.getRight();
            //up = pp1.getUp();
            //down = pp1.getDown();
            
            snakeScoreLabel.Text = Convert.ToString(score);
            if (down) { snakes.moveDown(); }
            if (up) { snakes.moveUp(); }
            if (right) { snakes.moveRight(); }
            if (left) { snakes.moveLeft(); }
            this.Invalidate();
            collision();
            for (int i = 0; i < snakes.SnakeRec.Length; i++)
            {
                if (snakes.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    score += 1;
                    snakes.growSnake();
                    food.foodlocation(randFood);
                }
            }
           // MyPipeline pp = new MyPipeline();
           //// pp.Init();
           // pp.LoopFrames();
           // //pp.Dispose();


         
        }

        public void collision()
        {
            for (int i = 1; i < snakes.SnakeRec.Length; i++)
            {
                if (snakes.SnakeRec[0].IntersectsWith(snakes.SnakeRec[1]))
                {
                    restart();
                }
            }

            for (int i = 1; i < snakes.SnakeRec.Length; i++)
            {
                //for (int j = 1; j < snakes.SnakeRec.Length; j++)
                //{
                    if (snakes.SnakeRec[0].IntersectsWith(snakes.SnakeRec[i]))
                    {
                        restart();
                    }
                //}
                
            }

            if (snakes.SnakeRec[0].X > 290)
            {
                //restart();
                snakes.SnakeRec[0].X = 0;
            }
            if (snakes.SnakeRec[0].X < 0)
            {
                snakes.SnakeRec[0].X = 290;
            }
            if (snakes.SnakeRec[0].Y > 290)
            {
                //restart();
                snakes.SnakeRec[0].Y = 0;
            }
            if (snakes.SnakeRec[0].Y < 0)
            {
                snakes.SnakeRec[0].Y = 290;
            }

        
            
        }

        public void restart()
        {
            timer1.Enabled = false;
            MessageBox.Show("GAME OVER");
            snakeScoreLabel.Text = "0";
            score = 0;
            spaceBarLabel.Text = "Press SPACECAR to begin";
            codesmeshlabel.Text = "CODESMESH";
            snakes = new Snake();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MyPipeline pp = new MyPipeline(this);
        }
    
    }
}
