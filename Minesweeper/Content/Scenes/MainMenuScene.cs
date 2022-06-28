using System.Windows.Forms;

namespace Minesweeper
{
    class MainMenuScene : Scene
    {
        public FrontEnd frontEnd;
        
        public MainMenuScene(FrontEnd frontEnd)
        {
            this.frontEnd = frontEnd;
            InitialiseTextBoxes();
            InitialiseButtons();
        }

        private void InitialiseTextBoxes()
        {
            Label instructionsText = new CustomTextBox("Choose a difficulty from below", Settings.ScreenWidth / 2, 100);
            Label authorText = new CustomTextBox("Made by Vincent Tang", Settings.ScreenWidth / 2, 400);

            frontEnd.windowsApplication.Controls.Add(instructionsText);
            frontEnd.windowsApplication.Controls.Add(authorText);
        }

        private void InitialiseButtons()
        {
            // Easy: 0, Medium: 1, Hard: 2
            DifficultyButton easyButton = new DifficultyButton(frontEnd, 0);
            DifficultyButton mediumButton = new DifficultyButton(frontEnd, 1);
            DifficultyButton hardButton = new DifficultyButton(frontEnd, 2);

            frontEnd.windowsApplication.Controls.Add(easyButton);
            frontEnd.windowsApplication.Controls.Add(mediumButton);
            frontEnd.windowsApplication.Controls.Add(hardButton);
        }
    }
}
