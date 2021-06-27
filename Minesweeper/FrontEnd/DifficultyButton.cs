using System;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    class DifficultyButton : Button
    {
        public readonly FrontEnd frontEnd;
        public readonly int difficulty;

        public DifficultyButton(FrontEnd frontEnd, int difficulty)
        {
            this.frontEnd = frontEnd;
            this.difficulty = difficulty;

            AutoSize = false;
            Size = new Size(100, 50);
            TabStop = false;
            TextAlign = ContentAlignment.MiddleCenter;

            SetTextBox();
            Click += new EventHandler(ClickHandler);
        }

        private void SetTextBox()
        {
            switch (difficulty)
            {
                case Constants.Easy:
                    Text = "Easy";
                    SetLocation(Constants.ScreenWidth / 4, Constants.ScreenHeight / 2);
                    break;
                case Constants.Medium:
                    Text = "Medium";
                    SetLocation(Constants.ScreenWidth / 2, Constants.ScreenHeight / 2);
                    break;
                case Constants.Hard:
                    Text = "Hard";
                    SetLocation(3 * Constants.ScreenWidth / 4, Constants.ScreenHeight / 2);
                    break;
            }
        }

        private void SetLocation(int locationX, int locationY)
        {
            Location = new Point(locationX - Size.Width / 2, locationY - Size.Height / 2);
        }

        private void ClickHandler(object sender, EventArgs e)
        {
            frontEnd.StartGame(difficulty);
        }
    }
}
