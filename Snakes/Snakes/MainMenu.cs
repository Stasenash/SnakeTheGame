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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void playBut_MouseMove(object sender, MouseEventArgs e)
        {
            playBut.BackColor = Color.LightGreen;
        }

        private void playBut_MouseLeave(object sender, EventArgs e)
        {
            playBut.BackColor = Color.Snow;
        }

        private void playBut_MouseClick(object sender, MouseEventArgs e)
        {
            Game gf = new Game(32,32);
            this.Hide();
            gf.Show();
        }
    }
}
