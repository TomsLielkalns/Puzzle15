using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle15
{
    public partial class PuzzleArea : Form
    {
        public PuzzleArea()
        {
            InitializeComponent();
            InitializePuzzleArea();
        }

        private void InitializePuzzleArea()
        {
            this.BackColor = Color.Purple;
            this.Text = "Puzzle 15";
        }

        private void InitializeButtons()
        {
            Button button;
            for(int i = 1; i < 16; i++)
            {
                button = new Button();
                this.Controls.Add(button);
            }
        }
    }
}
