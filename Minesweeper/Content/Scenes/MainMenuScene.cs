using System;
using System.Windows.Forms;

namespace Minesweeper
{
    class MainMenuScene : Scene
    {
        public MainMenuScene(FrontEnd frontEnd) : base(frontEnd)
        {
            this.frontEnd = frontEnd;
            InitialiseTextBoxes();
            InitialiseButtons();
        }

        private void InitialiseTextBoxes()
        {
            Label instructionsText = new CustomTextBox("Choose a difficulty from below", Constants.ScreenWidth / 2, 100);
            Label authorText = new CustomTextBox("Made by Vincent Tang", Constants.ScreenWidth / 2, 400);

            frontEnd.windowsApplication.Controls.Add(instructionsText);
            frontEnd.windowsApplication.Controls.Add(authorText);
        }

        private void InitialiseButtons()
        {
            DifficultyButton easyButton = new DifficultyButton(frontEnd, Constants.Easy);
            DifficultyButton mediumButton = new DifficultyButton(frontEnd, Constants.Medium);
            DifficultyButton hardButton = new DifficultyButton(frontEnd, Constants.Hard);

            frontEnd.windowsApplication.Controls.Add(easyButton);
            frontEnd.windowsApplication.Controls.Add(mediumButton);
            frontEnd.windowsApplication.Controls.Add(hardButton);
        }
    }
}
