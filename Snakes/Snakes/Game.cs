using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snakes
{
    public partial class Game : Form
    {
        Random rnd = new Random();
        int width, height, snakeSize;
        private List<Coords> snake = new List<Coords>();
        private Coords food;
        private int score;
        private Directions direction = Directions.Right;

        public Game(int width, int height, int snakeSize)
        {
            InitializeComponent();
            this.width = width;
            this.height = height;
            this.snakeSize = snakeSize;
            int caption_size = SystemInformation.CaptionHeight; // высота шапки формы
            int frame_size = SystemInformation.FrameBorderSize.Height; // ширина границы формы
            // устанавливаем размер внутренней области формы W * H с учетом высоты шапки и ширины границ
            this.Size = new Size(width * snakeSize + 2 * frame_size, height * snakeSize + caption_size + 2 * frame_size);

            gameTimer.Interval = snakeSize * 10;
            gameTimer.Start(); 

            snake.Add(new Coords(width / 2, height / 2 - 3));
            snake.Add(new Coords(width / 2, height / 2 - 2));
            snake.Add(new Coords(width / 2, height / 2 - 1));

            food = new Coords(rnd.Next(width), rnd.Next(height)); // координаты яблока

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            int x = snake[0].X;
            int y = snake[0].Y;
            switch (direction)
            {
                case Directions.Up:
                        y--;
                        if (y < 0)
                            y = height - 1;
                    break;
                case Directions.Down:
                        y++;
                        if (y >= height)
                            y = 0;
                    break; 
                case Directions.Left:
                        x--;
                        if (x < 0)
                            x = width - 1;
                    break;
                case Directions.Right:
                        x++;
                        if (x >= width)
                            x = 0;
                    break;
            }
            Coords newHead = new Coords(x, y);
            snake.Insert(0, newHead);
            if (snake[0].X == food.X && snake[0].Y == food.Y)
            {
                food = new Coords(rnd.Next(width), rnd.Next(height));
                score++;
                if (score % (snakeSize / 10) == 0 && gameTimer.Interval > 0)
                    gameTimer.Interval -= snakeSize;
            }
            else
                snake.RemoveAt(snake.Count - 1);
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                {
                    gameTimer.Stop();
                    MessageBox.Show($"Game over. Your score is {score}","You shall not pass", MessageBoxButtons.OK);
                    var menuForm = new MainMenu();
                    menuForm.Show();
                    this.Hide();
                }
            }
            Invalidate();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            //var brushesList = new List<Brush> (){ Brushes.Red, Brushes.Green, Brushes.Gold, Brushes.HotPink };
            //rnd.Next(0,brushesList.Count - 1);
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(food.X * snakeSize, food.Y * snakeSize, snakeSize, snakeSize));
            e.Graphics.FillRectangle(Brushes.Blue, new Rectangle(snake[0].X * snakeSize, snake[0].Y * snakeSize, snakeSize, snakeSize));
            for (int i = 1; i < snake.Count; i++)
                e.Graphics.FillRectangle(Brushes.Green, new Rectangle(snake[i].X * snakeSize, snake[i].Y * snakeSize, snakeSize, snakeSize));
            string state = "Score:" + score.ToString();
            e.Graphics.DrawString(state, new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(5, 5));
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: if (direction !=Directions.Down) direction = Directions.Up; break;
                case Keys.S: if (direction != Directions.Up) direction = Directions.Down; break;
                case Keys.A: if (direction != Directions.Right) direction = Directions.Left; break;
                case Keys.D: if (direction != Directions.Left) direction = Directions.Right; break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: if (direction != Directions.Down) direction = Directions.Up; break;
                case Keys.Down: if (direction != Directions.Up) direction = Directions.Down; break;
                case Keys.Left: if (direction != Directions.Right) direction = Directions.Left; break;
                case Keys.Right: if (direction != Directions.Left) direction = Directions.Right; break;
                default: return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
    }
}
