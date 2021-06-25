using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class WindowsApplication : Form
    {
        private WindowsTile[][] windowsTileArray;
        private BackEnd backEnd = new BackEnd();

        public WindowsApplication() { InitializeComponent(); }

        // When switching between scenes, the application clears the currently unused variables
        private void ClearMemory()
        {
            Controls.Clear();
            if (windowsTileArray != null && windowsTileArray.Length == 0) {
                Array.Clear(windowsTileArray, 0, windowsTileArray.Length);
            }
            backEnd = new BackEnd();
        }

        private void Restart()
        {
            ClearMemory();
            Console.WriteLine("Restart");
            InitializeComponent();
        }

        // Difficulty Selection Buttons
        private void EasyButton(object sender, EventArgs e) { ChooseDifficulty(sender, Constants.Easy); }
        private void MediumButton(object sender, EventArgs e) { ChooseDifficulty(sender, Constants.Medium); }
        private void HardButton(object sender, EventArgs e) { ChooseDifficulty(sender, Constants.Hard); }

        private void ChooseDifficulty(object sender, int difficulty)
        {
            ClearMemory();
            switch (difficulty)
            {
                case Constants.Easy:
                    StartGame(Constants.WidthEasy, Constants.HeightEasy, Constants.BombsCountEasy);
                    break;
                case Constants.Medium:
                    StartGame(Constants.WidthMedium, Constants.HeightMedium, Constants.BombsCountMedium);
                    break;
                case Constants.Hard:
                    StartGame(Constants.WidthHard, Constants.HeightHard, Constants.BombsCountHard);
                    break;
            }
        }

        // Game
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            // Restarts program if "r" is pressed on the keyboard
            if (e.KeyCode == Keys.R)
            {
                Restart();
            }
        }

        public void StartGame(int width, int height, int bombsCount)
        {
            backEnd.SetBackEnd(width, height, bombsCount);
            AddGrids(width, height, bombsCount);
            KeyDown += new KeyEventHandler(FormKeyDown);
        }

        private void TileClickHandler(object sender, MouseEventArgs e)
        {
            WindowsTile ClickedButton = (WindowsTile)sender;
            int x = ClickedButton.GetX();
            int y = ClickedButton.GetY();

            // Left click to sweep tile. Right click to flag tile.
            int command = Constants.CommandSweepTile;
            if (e.Button == MouseButtons.Right) { command = Constants.CommandFlagTile; }

            UpdateBackEnd(new UserCommand(x, y, command));
            UpdateVisual();
        }

        private void AddGrids(int width, int height, int bombsCount)
        {
            windowsTileArray = new WindowsTile[width][];
            WindowsTile windowstile;
            for (int i = 0; i < width; i++)
            {
                windowsTileArray[i] = new WindowsTile[height];
                for (int j = 0; j < height; j++)
                {
                    windowstile = new WindowsTile(i, j, width, height);
                    windowstile.MouseUp += TileClickHandler;
                    windowsTileArray[i][j] = windowstile;
                    Controls.Add(windowstile);
                }
            }
        }

        private void UpdateBackEnd(UserCommand UserCommand)
        {
            backEnd.logic.Update(UserCommand);
        }

        private void UpdateVisual()
        {
            UpdateBoard();
            CheckGameEnd();
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
                    windowsTile = windowsTileArray[m][n];
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

        // Adds pop up if game has won or lost
        private void CheckGameEnd()
        {
            int gameStatus = backEnd.GetStatus();
            string message;
            string returnToMenuMessage = "Press 'OK' to return back to the menu";
            if (gameStatus == Constants.Win)
            {
                message = "Wow! You Won! " + returnToMenuMessage;
                System.Windows.Forms.MessageBox.Show(message);
                Restart();
            }
            else if (gameStatus == Constants.Lose)
            {
                message = "Boo! You Lost! " + returnToMenuMessage;
                System.Windows.Forms.MessageBox.Show(message);
                Restart();
            }
        }

        // Windows application essentials functions
        private void FormLoad(object sender, EventArgs e) {}
        private void TextBoxTextChanged(object sender, EventArgs e) {}
    }
}
