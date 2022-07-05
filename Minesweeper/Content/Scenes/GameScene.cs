namespace Minesweeper
{
    class GameScene : Scene
    {
        public readonly int difficulty;
        public int screenWidth, screenHeight;

        private WindowsGrid windowsGrid;
        private BombCountTextBox bombCountTextBox;
        private TimerTextBox timerTextBox;
        private BackEnd backEnd;
        

        public GameScene(FrontEnd frontEnd, int difficulty) : base(frontEnd)
        {
            this.difficulty = difficulty;
            this.frontEnd = frontEnd;

            SetWindowSize();
            InitialiseTextBoxes();

            backEnd = new BackEnd(difficulty);
            windowsGrid = new WindowsGrid(frontEnd, backEnd);
        }

        private void SetWindowSize()
        {
            screenWidth = 0;
            screenHeight = Constants.ToolBarHeight + Constants.ToolBarSeparationHeight;
            switch (difficulty)
            {
                case 0:
                    screenWidth += Constants.TileSize * Constants.WidthEasy;
                    screenHeight += Constants.TileSize * Constants.HeightEasy;
                    break;
                case 1:
                    screenWidth = Constants.TileSize * Constants.WidthMedium;
                    screenHeight += Constants.TileSize * Constants.HeightMedium;
                    break;
                case 2:
                    screenWidth = Constants.TileSize * Constants.WidthHard;
                    screenHeight += Constants.TileSize * Constants.HeightHard;
                    break;
            }
            frontEnd.windowsApplication.SetWindowSize(screenWidth, screenHeight);
        }

        public override void UpdateVisual()
        {
            UpdateBombCountTextBox();
            UpdateTimerTextBox();
            windowsGrid.UpdateVisual();
        }

        private void InitialiseTextBoxes()
        {
            int textBoxHeight = Constants.ToolBarHeight + Constants.ToolBarSeparationHeight / 2;
            bombCountTextBox = new BombCountTextBox("Bomb Count", screenWidth / 4, textBoxHeight);
            timerTextBox = new TimerTextBox("Timer", 3 * screenWidth / 4, textBoxHeight);
            frontEnd.windowsApplication.Controls.Add(bombCountTextBox);
            frontEnd.windowsApplication.Controls.Add(timerTextBox);
        }

        private void UpdateBombCountTextBox()
        {
            int totalFlagged = backEnd.logic.GetTotalFlagged();
            int bombsCount = backEnd.logic.GetBombsCount();
            bombCountTextBox.Text = (bombsCount - totalFlagged).ToString();
        }

        private void UpdateTimerTextBox()
        {
            // Stop timer when game is finished
            if (!backEnd.logic.GetStatus())
                timerTextBox.Stop();
        }
    }
}
