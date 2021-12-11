using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;
namespace HunterGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (numericUpDownWolves.Value == 0 || numericUpDownHares.Value == 0 || numericUpDownDoes.Value == 0)
            {
                MessageBox.Show("Please, make sure you have chosen quontittes of animals for the game.");
            }
            else {

                Game.Game game = new Game.Game((int)numericUpDownHares.Value, (int)numericUpDownWolves.Value, (int)numericUpDownDoes.Value, this);

                game.Show();

                this.Hide();

            }
        }

        
    }
}
