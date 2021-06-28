using System.Windows.Forms;

namespace Minesweeper
{
    class WindowsGrid
    {
        private FrontEnd frontEnd;
        private BackEnd backEnd;

        private WindowsTile[,] windowsTileArray;

        public WindowsGrid(FrontEnd frontEnd, BackEnd backEnd)
        {
            this.frontEnd = frontEnd;
            this.backEnd = backEnd;
            AddGrids();
        }

        private void AddGrids()
        {
            windowsTileArray = new WindowsTile[backEnd.width, backEnd.height];
            for (int i = 0; i < backEnd.width; i++)
                for (int j = 0; j < backEnd.height; j++)
                {
                    windowsTileArray[i, j] = new WindowsTile(frontEnd, backEnd, i, j);
                    frontEnd.windowsApplication.Controls.Add(windowsTileArray[i, j]);
                }
        }

        public void UpdateVisual()
        {
            UpdateBoard();
            CheckGameEnd();
        }

        // Go through each tile in double array and update
        private void UpdateBoard()
        {
            foreach (WindowsTile windowsTile in windowsTileArray)
            {
                windowsTile.UpdateTile();
            }
        }

        // Adds pop up if game has won or lost and returns back to the menu
        private void CheckGameEnd()
        {
            int gameStatus = backEnd.GetStatus();
            if (gameStatus != Constants.InProgress)
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
