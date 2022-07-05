using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class WindowsApplication : Form
    {
        private FrontEnd frontEnd;

        public WindowsApplication() {
            InitializeComponent();
            frontEnd = new FrontEnd(this); // Set scene manager
        }

        public void SetWindowSize(int screenWidth, int screenHeight)
        {
            ClientSize = new Size(screenWidth, screenHeight);
        }

        // Windows application essentials functions
        private void FormLoad(object sender, EventArgs e) {}
    }
}
