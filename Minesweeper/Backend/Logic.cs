namespace Minesweeper
{
    public class Logic
    {
        private bool running = true;
        private bool win;
        private readonly Grid grid;

        public Logic(int width, int height, int bombsCount)
        {
            grid = new Grid(width, height, bombsCount);
        }

        // Private 
        private void CheckWinLoseCondition()
        {
            if (grid.GetHitBomb())
            {
                running = false;
                win = true;
            }
            else if (grid.GetTilesLeft() == 0)
            {
                running = false;
                win = false;
            }   
        }

        // Public 

        public void Update(int x, int y, bool command)
        {
            if (running)
            {  
                grid.UserTileInteract(x, y, command);
                CheckWinLoseCondition(); // Check if all tiles have been swept or bomb hit
            }
        }

        public bool GetStatus()
        {
            return running;
        }

        public bool GetGameResult()
        {
            return win;
        }

        public Tile[,] GetTileArray() {
            return grid.GetTileArray();
        }
    }
}