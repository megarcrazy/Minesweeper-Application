namespace Minesweeper
{
    // Controls the backend logic of the Minesweeper program
    public class BackEnd
    {
        public Logic logic;
        private readonly int width;
        private readonly int height;

        public BackEnd(int difficulty)
        {
            int bombsCount = 0;
            switch (difficulty)
            {
                case 0:
                    width = Settings.WidthEasy;
                    height = Settings.HeightEasy;
                    bombsCount = Settings.BombsCountEasy;
                    break;
                case 1:
                    width = Settings.WidthMedium;
                    height = Settings.HeightMedium;
                    bombsCount = Settings.BombsCountMedium;
                    break;
                case 2:
                    width = Settings.WidthHard;
                    height = Settings.HeightHard;
                    bombsCount = Settings.BombsCountHard;
                    break;
            }
            logic = new Logic(width, height, bombsCount);
        }
        
        // Checks if game is still in progress
        public bool GetStatus()
        {
            return logic.GetStatus();
        }

        public bool GetGameResult()
        {
            return logic.GetGameResult();
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }
    }
}