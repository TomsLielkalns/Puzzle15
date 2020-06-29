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
            InitializeBlock();
        }

        private void InitializePuzzleArea()
        {
            this.BackColor = Color.SkyBlue;
            this.Text = "Puzzle 15";
            this.ClientSize = new Size(500, 500);
        }

        private void InitializeBlock()
        {
            int blockCount = 1;
            PuzzleBlock block;
            for(int row = 1; row < 5; row++)
            {
                for(int col = 1; col < 5; col++)
                {
                    block = new PuzzleBlock();
                    block.Top = row * 84;
                    block.Left = col * 84;
                    block.Text = blockCount.ToString();
                    if(blockCount == 16)
                    {
                        block.Text = string.Empty;
                        block.BackColor = Color.LightGray;
                        block.FlatStyle = FlatStyle.Flat;
                        block.FlatAppearance.BorderSize = 0;
                    }
                    blockCount++;
                    this.Controls.Add(block);
                }
            }
        }
    }
}
