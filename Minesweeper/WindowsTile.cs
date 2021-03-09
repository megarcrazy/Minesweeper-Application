using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    public class WindowsTile : Button
    {
        const int SCREENWIDTH = 500;
        const int SCREENHEIGHT = 500;
        private readonly int TileWidth, TileHeight;
        private readonly int i, j;

        //Allocate a tile to 
        public WindowsTile(int i, int j, int x, int y)
        {
            this.i = i;
            this.j = j;
            TileWidth = SCREENWIDTH/x;
            TileHeight = SCREENHEIGHT/y;
            Initialise();
        }

        private void Initialise()
        {
            this.SetStyle(ControlStyles.Selectable, false);
            this.Size = new Size(TileWidth, TileHeight);
            this.Font = new Font(this.Font.FontFamily, TileWidth/2-2);
            this.Location = new Point(i * TileWidth, j * TileHeight);
            this.TextAlign = ContentAlignment.MiddleCenter;
        }

        public int GetX()
        {
            return i;
        }

        public int GetY()
        {
            return j;
        }

        public void ChangeText(string Text)
        {
            this.Text = Text;
            if (Text == "1")
            {
                this.ForeColor = Color.Blue;
            }
            else if (Text == "2")
            {
                this.ForeColor = Color.LightGreen;
            }
            else if (Text == "3")
            {
                this.ForeColor = Color.Red;
            }
            else if (Text == "4")
            {
                this.ForeColor = Color.DarkBlue;
            }
            else if (Text == "5")
            {
                this.ForeColor = Color.DarkRed;
            }
        }
    }
}
