using System;

namespace Minesweeper
{
    public class Logic
    {
        private int width;
        private int height;

        private bool win = false;
        private bool lose = false;
        private int round = 0;

        public Grid grid;
        private bool endGame = false;

        public Logic(int x, int y)
        {
            width = x;
            height = y;
            Start();
        }

        private void Start()
        {
            AddGrid();
            Print(grid);
        }

        private void AddGrid()
        {
            grid = new Grid(width, height);
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

            if (win)
            {
                Console.WriteLine("You win");
            }
            else if (lose)
            {
                Console.WriteLine("You lose");
            }
        }

        private void InsertUserInput(int[] Coords)
        {
            grid.Sweep(Coords, round);
        }

        private void Print(Grid grid)
        {
            //PrintGame.PlayerView(grid);
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
    }
}