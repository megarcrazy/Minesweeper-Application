using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Grid
    {
        Random rand = new Random();
        public int width, height;
        private int bombsCount, tilesLeft;
        private Tile[][] tileArray;
        private bool hitBomb = false;
        private bool addedBombs = false;

        public Grid(int width, int height, int bombsCount)
        {
            this.width = width;
            this.height = height;
            this.bombsCount = bombsCount;
            tilesLeft = width * height - bombsCount;
            AddTiles();
        }

        //Makes an array of tiles
        private void AddTiles()
        {
            tileArray = new Tile[width][];
            for (int i = 0; i < width; i++)
            {
                tileArray[i] = new Tile[height];
                for (int j = 0; j < height; j++)
                    tileArray[i][j] = new Tile(i, j);
            }
        }

        // Private

        private void AddBombs(Tile selectedTile)
        {
            int i = 0;
            while (i < bombsCount)
            {
                if (InsertRandomBomb(selectedTile))
                    i++;
            }
        }

        // Generattes random numbers and inserts a bomb at that location.
        private bool InsertRandomBomb(Tile selectedTile)
        {
            int x = rand.Next(width);
            int y = rand.Next(height);
            // Inserts successfully when tile has no bomb already and is not adjacent
            // to and in the starting tile and returns true if successful else false
            Tile newBombTile = tileArray[x][y];
            // Boolean to see if the new bomb tile is adjacent to the selected tile
            bool adjacentToSelectedTile = GetAdjacentTiles(selectedTile).ToList().Contains(newBombTile);
            if (!newBombTile.IsBomb() && selectedTile != newBombTile && !adjacentToSelectedTile)
            {
                newBombTile.AddBomb();
                AddBombCountToSurroundingTiles(newBombTile);
                return true;
            }
            return false;
        }

        private void AddBombCountToSurroundingTiles(Tile tile)
        {
            foreach (Tile adjacentTile in GetAdjacentTiles(tile))
                adjacentTile.IncreaseAdjacentBombsCount();
        }

        // Iterator returns adjacent tiles surrounding the given tile coordinates
        private IEnumerable<Tile> GetAdjacentTiles(Tile tile)
        {
            int i = tile.GetX();
            int j = tile.GetY();
            int x, y;
            foreach (int[] adjacentIndex in AdjacentIndexList.Get())
            {
                x = adjacentIndex[0];
                y = adjacentIndex[1];
                if (i + x >= 0 && i + x < width && j + y >= 0 && j + y < height)
                {
                    yield return tileArray[i + x][j + y];
                }
            }
        }

        private void SweepTile(Tile tile)
        {
            // Cannot Sweep if tile is flagged
            if (tile.IsBomb())
            {
                tile.Reveal();
                hitBomb = true;
            }
            else
            {
                SweepAlgorithm(tile);
            }
        }

        private void SweepAlgorithm(Tile tile)
        {
            tile.Reveal();
            tilesLeft--;
            if (tile.GetAdjacentBombsCount() == 0)
            {
                foreach (Tile adjacentTile in GetAdjacentTiles(tile))
                {
                    if (!adjacentTile.IsRevealed())
                        SweepAlgorithm(adjacentTile);
                }
            }
        }

        // Public

        // DFS sweep tiles
        public void UserTileInteract(UserInput userInput)
        {
            int x = userInput.x;
            int y = userInput.y;
            int command = userInput.command;
            Tile tile = tileArray[x][y];

            if (!addedBombs)
            {
                AddBombs(tile);
                addedBombs = true;
            }

            // Interacting with already revealed tile does nothing
            if (!tile.IsRevealed())
            {
                if (command == Constants.CommandSweepTile)
                {
                    // Prevent sweeping tile if flagged
                    if (!tile.IsFlagged())
                        SweepTile(tile);
                }
                else if (command == Constants.CommandFlagTile)
                {
                    tile.Flag();
                }
            }
        }

        // Get methods
        public Tile[][] GetTileArray() { return tileArray; }
        public int GetTilesLeft() { return tilesLeft; }
        public int GetBombsCount() { return bombsCount; }
        public bool GetHitBomb() { return hitBomb; }  
    }
}
