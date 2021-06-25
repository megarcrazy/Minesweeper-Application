using System;

namespace Minesweeper
{
    public class Logic
    {
        private bool win = false;
        private bool lose = false;
        private bool endGame = false;
        private int round = 1;
        private Grid grid;

        public Logic(int width, int height, int bombsCount)
        {
            grid = new Grid(width, height, bombsCount);
        }

        // Private 

        private void InsertUserCommand(UserCommand UserCommand)
        {
            grid.UserTileInteract(UserCommand);
        }

        private void CheckWinCondition()
        {
            if (grid.GetHitBomb())
            {
                endGame = true;
                lose = true;
            }
            else if (grid.GetTilesLeft() == 0)
            {
                endGame = true;
                win = true;
            }
        }

        // Public 

        public void Update(UserCommand UserCommand)
        {
            if (!endGame)
            {  
                InsertUserCommand(UserCommand);

                // Check if all tiles have been swept
                CheckWinCondition();
                round++;

                Print(grid);
            }

            // Debugging win/lose condition
            if (win) { Console.WriteLine("You win"); }
            else if (lose) { Console.WriteLine("You lose"); }
        }

        public int GetStatus()
        {
            if (win)
                return Constants.Win;
            else if (lose)
                return Constants.Lose;
            return Constants.InProgress;
        }

        public Tile[][] GetTileArray() {
            return grid.GetTileArray();
        }


        // Debugging functions

        private void Print(Grid grid)
        {
            PrintGame.PlayerView(grid);
        }
    }
}