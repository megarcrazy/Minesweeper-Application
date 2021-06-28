using System;

namespace Minesweeper
{
    public class Logic
    {
        private int gameStatus = Constants.InProgress;
        private int round = 1;
        private Grid grid;

        public Logic(int width, int height, int bombsCount)
        {
            grid = new Grid(width, height, bombsCount);
        }

        // Private 
        private void CheckWinCondition()
        {
            if (grid.GetHitBomb())
                gameStatus = Constants.Lose;
            else if (grid.GetTilesLeft() == 0)
                gameStatus = Constants.Win;
        }

        // Public 

        public void Update(int x, int y, int command)
        {
            if (gameStatus == Constants.InProgress)
            {  
                grid.UserTileInteract(x, y, command);
                // Check if all tiles have been swept
                CheckWinCondition();
                round++;
            }
        }

        public int GetStatus()
        {
            return gameStatus;
        }

        public Tile[,] GetTileArray() {
            return grid.GetTileArray();
        }

        // Debugging functions

        private void Print(Grid grid)
        {
            PrintGame.PlayerView(grid);
        }
    }
}