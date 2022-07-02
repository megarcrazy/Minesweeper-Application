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
            ClientSize = new Size(Constants.ScreenWidth, Constants.ScreenHeight + 50); // Set window size
            frontEnd = new FrontEnd(this); // Set scene manager
        }

        // Windows application essentials functions
        private void FormLoad(object sender, EventArgs e) {}
    }
}
