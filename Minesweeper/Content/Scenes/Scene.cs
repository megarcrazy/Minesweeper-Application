using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class Scene
    {
        public FrontEnd frontEnd;

        public Scene(FrontEnd frontEnd)
        {
            this.frontEnd = frontEnd;
            InitialiseMenuBar();
        }

        public virtual void UpdateVisual()
        {

        }

        // Add new game option and exit
        private void InitialiseMenuBar()
        {
            MenuStrip menuStrip = new MenuStrip();
            menuStrip.Dock = DockStyle.Top;
            frontEnd.windowsApplication.MainMenuStrip = menuStrip;
            frontEnd.windowsApplication.Controls.Add(menuStrip);
            ToolStripMenuItem gameItem = new ToolStripMenuItem();
            gameItem.Text = "Game";

            ToolStripMenuItem newItem = new ToolStripMenuItem();
            newItem.Text = "New...";

            ToolStripMenuItem easyItem = new ToolStripMenuItem();
            easyItem.Text = "Easy";
            easyItem.Click += new EventHandler((sender, e) => DifficultySelector(Constants.Easy));

            ToolStripMenuItem mediumItem = new ToolStripMenuItem();
            mediumItem.Text = "Medium";
            mediumItem.Click += new EventHandler((sender, e) => DifficultySelector(Constants.Medium));

            ToolStripMenuItem hardItem = new ToolStripMenuItem();
            hardItem.Text = "Hard";
            hardItem.Click += new EventHandler((sender, e) => DifficultySelector(Constants.Hard));

            ToolStripMenuItem exitItem = new ToolStripMenuItem();
            exitItem.Text = "Exit";
            exitItem.Click += new EventHandler(ExitGame);

            menuStrip.Items.Add(gameItem);
            gameItem.DropDownItems.Add(newItem);
            newItem.DropDownItems.Add(easyItem);
            newItem.DropDownItems.Add(mediumItem);
            newItem.DropDownItems.Add(hardItem);
            gameItem.DropDownItems.Add(exitItem);
        }

        private void DifficultySelector(int difficulty)
        {
            frontEnd.StartGame(difficulty);
        }

        private void ExitGame(object sender, EventArgs e)
        {
            frontEnd.windowsApplication.Close();
        }
    }
}
