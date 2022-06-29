using System;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    class DifficultyButton : Button
    {

        public DifficultyButton(FrontEnd frontEnd, int difficulty)
        {
            AutoSize = false;
            Size = new Size(100, 50);
            TabStop = false;
            TextAlign = ContentAlignment.MiddleCenter;

            SetTextBox(difficulty);
            Click += (sender, e) => frontEnd.StartGame(difficulty);
        }

        private void SetTextBox(int difficulty)
        {
            switch (difficulty)
            {
                case 0:
                    Text = "Easy";
                    SetLocation(Constants.ScreenWidth / 4, Constants.ScreenHeight / 2);
                    break;
                case 1:
                    Text = "Medium";
                    SetLocation(Constants.ScreenWidth / 2, Constants.ScreenHeight / 2);
                    break;
                case 2:
                    Text = "Hard";
                    SetLocation(3 * Constants.ScreenWidth / 4, Constants.ScreenHeight / 2);
                    break;
            }
        }

        private void SetLocation(int locationX, int locationY)
        {
            Location = new Point(locationX - Size.Width / 2, locationY - Size.Height / 2);
        }
    }
}
