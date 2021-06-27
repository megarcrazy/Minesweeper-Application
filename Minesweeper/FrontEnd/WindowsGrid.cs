using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class WindowsGrid
    {
        private FrontEnd frontEnd;
        private BackEnd backEnd;

        private WindowsTile[][] windowsTileArray;
        

        public WindowsGrid(FrontEnd frontEnd, BackEnd backEnd)
        {
            this.frontEnd = frontEnd;
            this.backEnd = backEnd;
            AddGrids();
        }

        private void AddGrids()
        {
            windowsTileArray = new WindowsTile[backEnd.width][];
            WindowsTile windowstile;
            for (int i = 0; i < backEnd.width; i++)
            {
                windowsTileArray[i] = new WindowsTile[backEnd.height];
                for (int j = 0; j < backEnd.height; j++)
                {
                    windowstile = new WindowsTile(backEnd, i, j);
                    windowsTileArray[i][j] = windowstile;
                    windowstile.MouseUp += TileClickHandler;
                    frontEnd.windowsApplication.Controls.Add(windowstile);
                }
            }
        }

        private void TileClickHandler(object sender, MouseEventArgs e)
        {
            WindowsTile ClickedButton = (WindowsTile)sender;
            int x = ClickedButton.GetX();
            int y = ClickedButton.GetY();

            // Left click to sweep tile. Right click to flag tile
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                int command;
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        command = Constants.CommandSweepTile;
                        break;
                    case MouseButtons.Right:
                        command = Constants.CommandFlagTile;
                        break;
                    default:
                        command = -1;
                        break;
                }
   
                UpdateBackEnd(new UserCommand(x, y, command));
                UpdateVisual();
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
            for (int m = 0; m < tileArray.Length; m++)
            {
                for (int n = 0; n < tileArray[0].Length; n++)
                {
                    windowsTileArray[m][n].UpdateTile();
                }
            }
        }

        // Adds pop up if game has won or lost
        private void CheckGameEnd()
        {
            int gameStatus = backEnd.GetStatus();
            if (gameStatus == Constants.Win || gameStatus == Constants.Lose)
            {
                string returnToMenuMessage = "Press 'OK' to return back to the menu";
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
                MessageBox.Show(message);
                frontEnd.BackToMenu();
            }
        }
    }
}
