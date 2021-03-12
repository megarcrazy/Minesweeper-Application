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

            UpdateBackEnd(new UserInput(x, y, command));
            UpdateVisual();
        }

        private void StartGame(int width, int height, int bombsCount)
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

        private void UpdateBackEnd(UserInput userInput) {
            backEnd.logic.Update(userInput);
        }

        private void UpdateVisual()
        {
            UpdateBoard();
            PopUp();
        }

        private void UpdateBoard()
        {
            Tile[][] tileArray = backEnd.logic.GetTileArray();
            WindowsTile windowsTile;
            Tile tile;
            for (int m = 0; m < tileArray.Length; m++)
            {
                for (int n = 0; n < tileArray[0].Length; n++)
                {
                    tile = tileArray[m][n];
                    windowsTile = WindowsTileArray[m][n];
                    windowsTile.ChangeText("");
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
                        windowsTile.ChangeText("F");
                    }
                }
            }
        }

        // Adds pop ups for winning or losing
        private void PopUp()
        {
            int gameStatus = backEnd.GetStatus();
            string message;
            string returnToMenuMessage = "Press r to return back to the menu.";
            if (gameStatus == Constants.Win)
            {
                message = "Wow! You Won! " + returnToMenuMessage;
                System.Windows.Forms.MessageBox.Show(message);
            }
            else if (gameStatus == Constants.Lose)
            {
                message = "Boo! You Lost! " + returnToMenuMessage;
                System.Windows.Forms.MessageBox.Show(message);
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

        // Difficulty Selection Buttons. Buttons are removed form the window when a diffulty is selected

        private void EasyButton(object sender, EventArgs e)
        {
            Controls.Clear();
            StartGame(Constants.WidthEasy, Constants.HeightEasy, Constants.BombsCountEasy);
            Button buttonToRemove = (Button)sender;
            Controls.Remove(buttonToRemove);
        }

        private void MediumButton(object sender, EventArgs e)
        {
            Controls.Clear();
            StartGame(Constants.WidthMedium, Constants.HeightMedium, Constants.BombsCountMedium);
            Button buttonToRemove = (Button)sender;
            Controls.Remove(buttonToRemove);
        }

        private void HardButton(object sender, EventArgs e)
        {
            Controls.Clear();
            StartGame(Constants.WidthHard, Constants.HeightHard, Constants.BombsCountHard);
            Button buttonToRemove = (Button)sender;
            Controls.Remove(buttonToRemove);
        }

        // Windows application essentials functions
        private void FormLoad(object sender, EventArgs e) {}
        private void TextBoxTextChanged(object sender, EventArgs e) {}
    }
}
