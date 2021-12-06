using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Behavior_Experiment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Button button = new Button();

            button.Enabled = false;

            button.Location = new Point(1, 1);

            button.Height = 10;

            button.Width = button.Height;

        }

        public void GameLoop() {
        


        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            GameLoop();
        }
    }
}
