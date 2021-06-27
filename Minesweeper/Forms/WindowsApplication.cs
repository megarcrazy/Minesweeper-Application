using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class WindowsApplication : Form
    {
        //private WindowsTile[][] windowsTileArray;
        // private BackEnd backEnd = new BackEnd();

        private FrontEnd frontEnd;

        public WindowsApplication() {
            InitializeComponent();
            ClientSize = new Size(Constants.ScreenWidth, Constants.ScreenHeight); // Set window size
            frontEnd = new FrontEnd(this); // Set scene manager
        }
        

        /*

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
            string returnToMenuMessage = "Press 'OK' to return back to the menu";
            if (gameStatus == Constants.Win || gameStatus == Constants.Lose)
            {
                string message = "";
                switch (gameStatus)
                {
                    case Constants.Win:
                        message = "Wow! You Won! " + returnToMenuMessage;
                        break;
                    case Constants.Lose:
                        message = "Boo! You Lost! " + returnToMenuMessage;
                        break;
                }
                System.Windows.Forms.MessageBox.Show(message);
                Restart();
            }
        }
        */
        // Windows application essentials functions
        private void FormLoad(object sender, EventArgs e) {}
        private void TextBoxTextChanged(object sender, EventArgs e) {}
    }
}
