using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    public class WindowsTile : Button
    {
        private FrontEnd frontEnd;
        private BackEnd backEnd;
        public readonly int x, y, gridOffSetX, gridOffSetY;

        public WindowsTile(FrontEnd frontEnd, BackEnd backEnd, int x, int y, int gridOffSetX, int gridOffSetY)
        {
            this.frontEnd = frontEnd;
            this.backEnd = backEnd;
            this.x = x;
            this.y = y;
            this.gridOffSetX = gridOffSetX;
            this.gridOffSetY = gridOffSetY;

            SetStyle(ControlStyles.Selectable, false);
            TextAlign = ContentAlignment.MiddleCenter;
            BackColor = Color.LightGray;

            int visualTileWidth = Constants.ScreenWidth / backEnd.GetWidth();
            int visualTileHeight = Constants.ScreenHeight / backEnd.GetHeight();
            SetTileDimensions(visualTileWidth, visualTileHeight);
            SetLocation(visualTileWidth, visualTileHeight);
            MouseUp += TileClickHandler;
        }

        private void SetTileDimensions(int visualTileWidth, int visualTileHeight)
        {
            Size = new Size(visualTileWidth, visualTileHeight);
            int buttonBorderThickness = 2;
            Font = new Font(Font.FontFamily, visualTileWidth / 2 - buttonBorderThickness);
        }

        private void SetLocation(int visualTileWidth, int visualTileHeight)
        {
            // Centres the grid towards the centre of the application if gap exists between tile and border
            int offsetX = Constants.ScreenWidth % backEnd.GetWidth() / 2;
            int offSetY = Constants.ScreenHeight % backEnd.GetHeight() / 2;
            Location = new Point(x * visualTileWidth + offsetX + gridOffSetX, y * visualTileHeight + offSetY + gridOffSetY);
        }

        private void TileClickHandler(object sender, MouseEventArgs e)
        {
            // Left click to sweep tile. Right click to flag tile
            // True for sweep and false for flag
            switch (e.Button)
            {
                case MouseButtons.Left:
                    backEnd.logic.Update(x, y, true);
                    break;
                case MouseButtons.Right:
                    backEnd.logic.Update(x, y, false);
                    break;
            }
            frontEnd.UpdateVisual();
        }

        // If tile is revealed, show user what is in the tile and tell user which tiles are flagged
        public void UpdateTile()
        {
            Tile tile = backEnd.logic.GetTileArray()[x, y];
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
            // Add colouring to the numbers
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
