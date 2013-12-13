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

        int score = 0;
        int speed = 1;

        //public snake_game.MyPipeline pp;

        public void config(bool _left, bool _right, bool _up, bool _down)
        {
            left = _left;
            right = _right;
            up = _up;
            down = _down;
        }

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
            snakeScoreLabel.Text = Convert.ToString(score);
            snakeSpeed.Text = Convert.ToString(speed);
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
                    score += speed;
                    snakes.growSnake();
                    food.foodlocation(randFood);
                }
            }         
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
                if (snakes.SnakeRec[0].IntersectsWith(snakes.SnakeRec[i]))
                {
                    restart();
                }                
            }

            if (snakes.SnakeRec[0].X > 290)
            {
                snakes.SnakeRec[0].X = 0;
            }
            if (snakes.SnakeRec[0].X < 0)
            {
                snakes.SnakeRec[0].X = 290;
            }
            if (snakes.SnakeRec[0].Y > 290)
            {
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
            snakeSpeed.Text = "0";
            speed = 0;
            spaceBarLabel.Text = "press SPACE to begin";
            snakes = new Snake();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public bool getLeft()
        {
            return left;
        }

        public bool getRight()
        {
            return right;
        }

        public bool getUp()
        {
            return up;
        }
        public bool getDown()
        {
            return down;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void spaceBarLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void snakeScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void currLevel_Click(object sender, EventArgs e)
        {

        }
    
    }
}
