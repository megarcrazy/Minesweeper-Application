using System;

namespace Minesweeper
{
    // Controls the backend logic of the Minesweeper program
    public class BackEnd
    {
        public Logic logic;

        public void SetBackEnd(int x, int y, int bombsCount)
        {
            logic = new Logic(x, y, bombsCount);
        }
        
        // Returns status of game: In progress, win or lose
        public int GetStatus()
        {
            return logic.GetStatus();
        }

        public Tile[][] GetTileArray()
        {
            return logic.GetTileArray();
        }
    }
}