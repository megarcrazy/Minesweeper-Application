namespace Minesweeper
{
    class GameScene : Scene
    {
        public readonly int difficulty;

        private readonly WindowsGrid windowsGrid;
        private readonly BackEnd backEnd;

        public GameScene(FrontEnd frontEnd, int difficulty) : base(frontEnd)
        {
            this.difficulty = difficulty;
            this.frontEnd = frontEnd;
            backEnd = new BackEnd(difficulty);
            windowsGrid = new WindowsGrid(frontEnd, backEnd);
        }

        public override void UpdateVisual()
        {
            windowsGrid.UpdateVisual();
        }
    }
}
