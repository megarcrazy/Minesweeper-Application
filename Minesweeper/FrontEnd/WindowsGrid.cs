using System.Windows.Forms;

namespace Minesweeper
{
    class WindowsGrid
    {
        private readonly FrontEnd frontEnd;
        private readonly BackEnd backEnd;

        private WindowsTile[,] windowsTileArray;

        public WindowsGrid(FrontEnd frontEnd, BackEnd backEnd)
        {
            this.frontEnd = frontEnd;
            this.backEnd = backEnd;
            AddGrids();
        }

        private void AddGrids()
        {
            int width = backEnd.GetWidth();
            int height = backEnd.GetHeight();
            windowsTileArray = new WindowsTile[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
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
            bool gameRunning = backEnd.GetStatus();
            if (!gameRunning)
            {
                string returnToMenuMessage = "Press 'OK' to return back to the menu";
                string message;
                if (backEnd.GetGameResult())
                {
                    message = "Wow! You Won! " + returnToMenuMessage;
                }
                else
                {
                    message = "Boo! You Lost! " + returnToMenuMessage;
                }
                MessageBox.Show(message);
                frontEnd.BackToMenu();
            }
        }
    }
}
