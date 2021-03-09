using System;

namespace Minesweeper
{
    public class Tile
    {
        private int x;
        private int y;

        private bool Revealed = false;
        private bool Bomb = false;
        private int AdjacentBombsCount = 0;
        private bool Flagged = false;

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void Reveal()
        {
            Revealed = true;
        }

        public void AddBomb()
        {
            Bomb = true;
        }

        public int GetAdjacentBombsCount()
        {
            return AdjacentBombsCount;
        }

        public bool IsRevealed()
        {
            return Revealed;
        }

        public bool IsBomb()
        {
            return Bomb;
        }

        public void IncreaseAdjacentBombsCount()
        {
            AdjacentBombsCount++;
        }

        public void Flag()
        {
            Flagged = true;
        }

        public bool IsFlagged()
        {
            return Flagged;
        }
    }
}
