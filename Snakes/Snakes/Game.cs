using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snakes
{
    public partial class Game : Form
    {
        private char location = 'R';
        private readonly int speed = 15;
        public Game()
        {
            InitializeComponent();
            gameTimer.Interval = 200;
            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            switch (location)
            {
                case 'U': head.Location = new Point(head.Location.X, head.Location.Y - speed); break;
                case 'D': head.Location = new Point(head.Location.X, head.Location.Y + speed); break;
                case 'L': head.Location = new Point(head.Location.X - speed, head.Location.Y); break;
                case 'R': head.Location = new Point(head.Location.X + speed, head.Location.Y); break;
            }
        }

        private void head_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up: location = 'U'; break;
                case Keys.S:
                case Keys.Down: location = 'D'; break;
                case Keys.A:
                case Keys.Left: location = 'L'; break;
                case Keys.D:
                case Keys.Right: location = 'R'; break;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left: location = 'L'; break;
                case Keys.Right: location = 'R'; break;
                case Keys.Up: location = 'U'; break;
                case Keys.Down: location = 'D'; break;
                default: return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
    }
}
