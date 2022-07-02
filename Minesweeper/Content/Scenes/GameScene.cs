namespace Minesweeper
{
    class GameScene : Scene
    {
        public readonly int difficulty;

        private WindowsGrid windowsGrid;
        private BombCountTextBox bombCountTextBox;
        private TimerTextBox timerTextBox;
        private readonly BackEnd backEnd;

        public GameScene(FrontEnd frontEnd, int difficulty) : base(frontEnd)
        {
            this.difficulty = difficulty;
            this.frontEnd = frontEnd;

            BombCountTextBox bombCountTextBox = new BombCountTextBox("Bomb Count", Constants.ScreenWidth / 4, 35);
            TimerTextBox timerTextBox = new TimerTextBox("Timer", 3 * Constants.ScreenWidth / 4, 35);
            InitialiseTextBoxes();

            backEnd = new BackEnd(difficulty);
            windowsGrid = new WindowsGrid(frontEnd, backEnd);
        }

        public override void UpdateVisual()
        {
            UpdateBombCountTextBox();
            UpdateTimerTextBox();
            windowsGrid.UpdateVisual();
        }

        private void InitialiseTextBoxes()
        {
            bombCountTextBox = new BombCountTextBox("Click anywhere to start", Constants.ScreenWidth / 4, 35);
            timerTextBox = new TimerTextBox("Timer", 3 * Constants.ScreenWidth / 4, 35);

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
