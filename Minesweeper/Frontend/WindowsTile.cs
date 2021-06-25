using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    public class WindowsTile : Button
    {
        private readonly int x, y;

        public WindowsTile(int x, int y, int gridX, int GridY)
        {
            this.x = x;
            this.y = y;
            int visualTileWidth = Constants.ScreenWidth/ gridX;
            int visualTileHeight = Constants.ScreenHeight/ GridY;
            Initialise(x, y, visualTileWidth, visualTileHeight);
        }

        private void Initialise(int x, int y, int visualTileWidth, int visualTileHeight)
        {
            SetStyle(ControlStyles.Selectable, false);
            Size = new Size(visualTileWidth, visualTileHeight); 
            Location = new Point(x * visualTileWidth, y * visualTileHeight);

            // Tile button style
            Font = new Font(Font.FontFamily, visualTileWidth / 2 - Constants.ButtonBorderThickness);
            TextAlign = ContentAlignment.MiddleCenter;
            BackColor = Color.LightGray;
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
