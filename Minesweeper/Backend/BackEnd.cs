using System;

namespace Minesweeper
{
    // Controls the backend logic of the Minesweeper program
    public class BackEnd
    {
        public Logic logic;
        public readonly int width;
        public readonly int height;

        public BackEnd(int difficulty)
        {
            int bombsCount = 0;
            switch (difficulty)
            {
                case Constants.Easy:
                    width = Constants.WidthEasy;
                    height = Constants.HeightEasy;
                    bombsCount = Constants.BombsCountEasy;
                    break;
                case Constants.Medium:
                    width = Constants.WidthMedium;
                    height = Constants.HeightMedium;
                    bombsCount = Constants.BombsCountMedium;
                    break;
                case Constants.Hard:
                    width = Constants.WidthHard;
                    height = Constants.HeightHard;
                    bombsCount = Constants.BombsCountHard;
                    break;
            }
            logic = new Logic(width, height, bombsCount);
        }
        
        // Returns status of game: In progress, win or lose
        public int GetStatus()
        {
            return logic.GetStatus();
        }

        public Tile[,] GetTileArray()
        {
            return logic.GetTileArray();
        }
    }
}