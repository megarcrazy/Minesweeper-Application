namespace Minesweeper
{
    public class Logic
    {
        private bool running = true;
        private bool win;
        private readonly Grid grid;
        private int bombsCount = 0;

        public Logic(int width, int height, int bombsCount)
        {
            this.bombsCount = bombsCount;
            grid = new Grid(width, height, bombsCount);
        }

        // Private 
        private void CheckWinLoseCondition()
        {
            if (grid.GetHitBomb())
            {
                running = false;
                win = false;
            }
            else if (grid.GetTilesLeft() == 0)
            {
                running = false;
                win = true;
            }   
        }

        // Left click: sweep, Right click: Flag
        public void Update(int x, int y, bool command)
        {
            if (running)
            {  
                grid.UserTileInteract(x, y, command);
                CheckWinLoseCondition(); // Check if all tiles have been swept or bomb hit
            }
        }

        public bool GetStatus() { return running; }
        public bool GetGameResult() { return win; }
        public Tile[,] GetTileArray() { return grid.GetTileArray(); }
        public int GetTotalFlagged() { return grid.GetTotalFlagged(); }
        public int GetBombsCount() { return bombsCount; }
    }
}