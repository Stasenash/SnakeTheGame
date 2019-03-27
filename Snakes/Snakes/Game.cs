using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Snakes
{
    enum Directions
    {
        Right,
        Left,
        Up,
        Down
    }
    public partial class Game : Form
    {
        private Directions direction = Directions.Right;
        private readonly int speed = 32;
        private readonly Point[,] coords;

        public Game(int width, int height)
        {
            InitializeComponent();
            gameTimer.Start();
            coords = new Point[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    coords[i, j] = new Point(32 * i, 32 * j);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            switch (direction)
            {
                case Directions.Up: head.Location = new Point(head.Location.X, head.Location.Y - speed); break;
                case Directions.Down: head.Location = new Point(head.Location.X, head.Location.Y + speed); break;
                case Directions.Left: head.Location = new Point(head.Location.X - speed, head.Location.Y); break;
                case Directions.Right: head.Location = new Point(head.Location.X + speed, head.Location.Y); break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (System.Drawing.Pen myPen = new System.Drawing.Pen(Color.Aqua))
            {
                // Draw an aqua rectangle in the rectangle represented by the control.  
                e.Graphics.DrawRectangle(myPen, new Rectangle(this.Location,
                   this.Size));
            }
        }

        private void head_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: direction = Directions.Up; break;
                case Keys.S: direction = Directions.Down; break;
                case Keys.A: direction = Directions.Left; break;
                case Keys.D: direction = Directions.Right; break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left: direction = Directions.Left; break;
                case Keys.Right: direction = Directions.Right; break;
                case Keys.Up: direction = Directions.Up; break;
                case Keys.Down: direction = Directions.Down; break;
                default: return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
    }
}
