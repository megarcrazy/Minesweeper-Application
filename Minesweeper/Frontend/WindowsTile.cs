using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    public class WindowsTile : Button
    {
        BackEnd backEnd;
        private readonly int x, y;

        public WindowsTile(BackEnd backEnd, int x, int y)
        {
            this.backEnd = backEnd;
            this.x = x;
            this.y = y;

            SetStyle(ControlStyles.Selectable, false);
            TextAlign = ContentAlignment.MiddleCenter;
            BackColor = Color.LightGray;

            int visualTileWidth = Constants.ScreenWidth / backEnd.width;
            int visualTileHeight = Constants.ScreenHeight / backEnd.height;
            SetTileDimensions(visualTileWidth, visualTileHeight);
            SetLocation(visualTileWidth, visualTileHeight);
        }

        private void SetTileDimensions(int visualTileWidth, int visualTileHeight)
        {
            Size = new Size(visualTileWidth, visualTileHeight);
            Font = new Font(Font.FontFamily, visualTileWidth / 2 - Constants.ButtonBorderThickness);
        }

        private void SetLocation(int visualTileWidth, int visualTileHeight)
        {
            // Centres the grid towards the centre of the application if gap exists between tile and border
            int offsetX = Constants.ScreenWidth % backEnd.width / 2;
            int offSetY = Constants.ScreenHeight % backEnd.height / 2;
            Location = new Point(x * visualTileWidth + offsetX, y * visualTileHeight + offSetY);
        }

        public int GetX() { return x; }
        public int GetY() { return y; }

        // If tile is revealed, show user what is in the tile and tell user which tiles are flagged
        public void UpdateTile()
        {
            Tile tile = backEnd.logic.GetTileArray()[x][y];
            ChangeText("");
            if (tile.IsRevealed())
            {
                BackColor = Color.White;
                if (tile.IsBomb())
                {
                    ChangeText("X");
                }
                else if (tile.GetAdjacentBombsCount() != 0)
                {
                    ChangeText(tile.GetAdjacentBombsCount().ToString());
                }
            }
            else if (tile.IsFlagged())
            {
                ChangeText("F");
            }
        }
        
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
