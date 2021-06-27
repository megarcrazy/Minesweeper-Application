using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public class FrontEnd
    {
        public WindowsApplication windowsApplication;
        private Scene currentScene;

        public FrontEnd(WindowsApplication windowsApplication)
        {
            this.windowsApplication = windowsApplication;
            windowsApplication.KeyDown += new KeyEventHandler(FormKeyDown);
            currentScene = new MainMenuScene(this);
        }

        public void StartGame(int difficulty)
        {
            windowsApplication.Controls.Clear();
            currentScene = new GameScene(this, difficulty);
        }

        public void BackToMenu()
        {
            windowsApplication.Controls.Clear();
            currentScene = new MainMenuScene(this);
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            // Restarts program if "r" is pressed on the keyboard
            if (e.KeyCode == Keys.R)
            {
                Console.WriteLine("Restart");
                BackToMenu();
            }
        }
    }
}
