using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    public class WindowsTile : Button
    {
        const int SCREENWIDTH = Constants.ScreenWidth;
        const int SCREENHEIGHT = Constants.ScreenHeight;
        private readonly int x, y;

        public WindowsTile(int x, int y, int gridX, int GridY)
        {
            this.x = x;
            this.y = y;
            int visualTileWidth = SCREENWIDTH/gridX;
            int visualTileHeight = SCREENHEIGHT/GridY;
            Initialise(x, y, visualTileWidth, visualTileHeight);
        }

        private void Initialise(int x, int y, int visualTileWidth, int visualTileHeight)
        {
            SetStyle(ControlStyles.Selectable, false);
            Size = new Size(visualTileWidth, visualTileHeight);
            Font = new Font(Font.FontFamily, visualTileWidth / 2);
            Location = new Point(x * visualTileWidth, y * visualTileHeight);
            TextAlign = ContentAlignment.MiddleCenter;
        }

        public int GetX() { return x; }
        public int GetY() { return y; }
        
        // Different tile texts have different colours
        public void ChangeText(string text)
        {
            Text = text;
            switch (text)
            {
                case "1":
                    ForeColor = Color.Blue;
                    break;
                case "2":
                    ForeColor = Color.Green;
                    break;
                case "3":
                    ForeColor = Color.Red;
                    break;
                case "4":
                    ForeColor = Color.DarkBlue;
                    break;
                default:
                    ForeColor = Color.DarkRed;
                    break;
            }
        }
    }
}
