using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class WindowApplication : Form
    {
        private WindowsTile[][] WindowsTileArray; 
        private BackEnd backEnd;

        public WindowApplication() { InitializeComponent(); }

        private void MyButtonClickHandler(object sender, MouseEventArgs e)
        {
            WindowsTile ClickedButton = (WindowsTile)sender;
            int x = ClickedButton.GetX();
            int y = ClickedButton.GetY();

            // Left click to sweep tile. Right click to flag tile.
            int command = Constants.CommandSweepTile;
            if (e.Button == MouseButtons.Right) { command = Constants.CommandFlagTile; }

            UpdateBackEnd(new int[] { x, y, command });
            UpdateVisual();
        }

        private void Initiate(int width, int height, int bombsCount)
        {
            backEnd = new BackEnd(width, height, bombsCount);
            AddGrids(width, height, bombsCount);
            KeyDown += new KeyEventHandler(FormKeyDown);
        }

        private void AddGrids(int width, int height, int bombsCount)
        {
            WindowsTileArray = new WindowsTile[width][];
            WindowsTile windowstile;
            for (int i = 0; i < width; i++)
            {
                WindowsTileArray[i] = new WindowsTile[height];
                for (int j = 0; j < height; j++)
                {
                    windowstile = new WindowsTile(i, j, width, height);
                    windowstile.MouseUp += MyButtonClickHandler;
                    WindowsTileArray[i][j] = windowstile;
                    Controls.Add(windowstile);
                }
            }
        }

        private void UpdateBackEnd(int[] UserInput) { backEnd.logic.Run(UserInput); }

        private void UpdateVisual()
        {
            Tile[][] tileArray = backEnd.logic.grid.GetTileArray();
            WindowsTile windowsTile;
            Tile tile;
            for (int m = 0; m < tileArray.Length; m++)
            {
                for (int n = 0; n < tileArray[0].Length; n++)
                {
                    tile = tileArray[m][n];
                    windowsTile = WindowsTileArray[m][n];
                    if (tile.IsRevealed())
                    {
                        windowsTile.BackColor = Color.White;
                        if (tile.IsBomb())
                        {
                            windowsTile.ChangeText("X");
                        }
                        else if (tile.GetAdjacentBombsCount() != 0)
                        {
                            windowsTile.ChangeText(tile.GetAdjacentBombsCount().ToString());
                        }
                    }
                    else if (tile.IsFlagged())
                    {
                        WindowsTileArray[m][n].ChangeText("F");
                    }
                    else
                    {
                        WindowsTileArray[m][n].ChangeText("");
                    }
                }
            }
        }

        // Detect keys pressed by user
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            // Restarts program if "r" is pressed on the keyboard
            if (e.KeyCode == Keys.R)
            {
                Application.Restart();
                Environment.Exit(0);
                Console.WriteLine("Restart");
            }
        }

        private void EasyButton(object sender, EventArgs e)
        {
            Controls.Clear();
            Initiate(9, 9, 10);
            Button buttonToRemove = (Button)sender;
            Controls.Remove(buttonToRemove);
        }

        private void MediumButton(object sender, EventArgs e)
        {
            Controls.Clear();
            Initiate(16, 16, 40);
            Button buttonToRemove = (Button)sender;
            Controls.Remove(buttonToRemove);
        }

        private void HardButton(object sender, EventArgs e)
        {
            Controls.Clear();
            Initiate(25, 25, 80);
            Button buttonToRemove = (Button)sender;
            Controls.Remove(buttonToRemove);
        }

        private void FormLoad(object sender, EventArgs e) {}
        private void TextBoxTextChanged(object sender, EventArgs e) {}
    }
}
