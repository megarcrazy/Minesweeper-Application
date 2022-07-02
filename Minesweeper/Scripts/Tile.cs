namespace Minesweeper
{
    public class Tile
    {
        private readonly int x, y;
        private int adjacentBombsCount = 0;
        private bool revealed = false;
        private bool bomb = false;
        private bool flagged = false;

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Public Functions

        // Get Functions
        public int GetX() { return x; }
        public int GetY() { return y; }
        public int GetAdjacentBombsCount() { return adjacentBombsCount; }
        public bool IsRevealed() { return revealed; }
        public bool IsBomb() { return bomb; }
        public bool IsFlagged() { return flagged; }

        // Logic Functions
        public void AddBomb() { bomb = true; }
        public void Reveal() { revealed = true; }
        public void IncreaseAdjacentBombsCount() { adjacentBombsCount++; }
        public bool Flag() {
            flagged = !flagged;

            // Returns true for flagging and false for unflagging
            return flagged;
        }
    }
}
