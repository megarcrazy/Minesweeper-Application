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

            SetTileDimensions();
            SetLocation();
            MouseUp += TileClickHandler;
        }

        private void SetTileDimensions()
        {
            Size = new Size(Constants.TileSize, Constants.TileSize);
            int buttonBorderThickness = 2;
            Font = new Font(Font.FontFamily, Constants.TileSize / 2 - buttonBorderThickness);
        }

        private void SetLocation()
        {
            Location = new Point(x * Constants.TileSize + gridOffSetX, y * Constants.TileSize + gridOffSetY);
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
