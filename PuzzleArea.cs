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
        Random rand = new Random();
        List<Point> initialLocations = new List<Point>();

        public PuzzleArea()
        {
            InitializeComponent();
            InitializePuzzleArea();
            InitializeBlock();
            ShuffleBlocks();
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
                for (int col = 1; col < 5; col++)
                {
                    block = new PuzzleBlock()
                    {
                        Top = row * 84,
                        Left = col * 84,
                        Text = blockCount.ToString(),
                        Name = "Block" + blockCount.ToString()
                    };

                    //block.Click += new EventHandler(Block_Click);
                    block.Click += Block_Click;
                    initialLocations.Add(block.Location);

                    if (blockCount == 16)
                    {
                        block.Name = "EmptyBlock";
                        block.Text = string.Empty;
                        block.BackColor = Color.SkyBlue;
                        block.FlatStyle = FlatStyle.Flat;
                        block.FlatAppearance.BorderSize = 0;
                    }
                    blockCount++;
                    this.Controls.Add(block);
                }
            }
        }

        private void Block_Click(object sender, EventArgs e)
        {
            Button block = (Button)sender;
            if (CheckIfAdjacent(block))
            {
                SwapBlock(block);
                CheckForWin();
            }
        }

        private void SwapBlock(Button block)
        {
            Button emptyBlock = (Button)this.Controls["EmptyBlock"];
            Point oldLocation = block.Location;
            block.Location = emptyBlock.Location;
            emptyBlock.Location = oldLocation;
        }

        private bool CheckIfAdjacent(Button block)
        {
            double a;
            double b;
            double c;
            Button emptyBlock = (Button)this.Controls["EmptyBlock"];

            a = Math.Abs(emptyBlock.Top - block.Top);
            b = Math.Abs(emptyBlock.Left - block.Left);
            c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            if(c < 85)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ShuffleBlocks()
        {
            int randNumber;
            string blockName;
            Button block;

            for(int i = 0; i < 100; i++)
            {
                randNumber = rand.Next(1, 16);
                blockName = "Block" + randNumber.ToString();
                block = (Button)this.Controls[blockName];
                SwapBlock(block);
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShuffleBlocks();
        }

        private void CheckForWin()
        {
            string blockName;
            Button block;

            for(int i = 1; i < 16; i++)
            {
                blockName = "Block" + i.ToString();
                block = (Button)this.Controls[blockName];
                if(block.Location != initialLocations[i - 1])
                {
                    return;
                }
            }
            PuzzleSolved();
        }

        private void PuzzleSolved()
        {
            MessageBox.Show("You solved the puzzle!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
