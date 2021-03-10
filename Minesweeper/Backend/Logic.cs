using System;

namespace Minesweeper
{
    public class Logic
    {
        private bool win = false;
        private bool lose = false;
        private int round = 0;

        public Grid grid;
        private bool endGame = false;

        public Logic(int width, int height, int bombsCount)
        {
            Start(width, height, bombsCount);
        }

        private void Start(int width, int height, int bombsCount)
        {
            AddGrid(width, height, bombsCount);
            Print(grid);
        }

        private void AddGrid(int width, int height, int bombsCount)
        {
            grid = new Grid(width, height, bombsCount);
        }

        public void Run(int[] UserInput)
        {
            if (!endGame)
            {
                round++;
                InsertUserInput(UserInput);
                Print(grid);
                CheckWinCondition();
            }

            // Debugging win/lose condition
            if (win) { Console.WriteLine("You win"); }
            else if (lose) { Console.WriteLine("You lose"); }
        }

        private void InsertUserInput(int[] Coords)
        {
            grid.Sweep(Coords, round);
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

        // Debugging functions
        private void Print(Grid grid)
        {
            //PrintGame.PlayerView(grid);
        }
    }
}