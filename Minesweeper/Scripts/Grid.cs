using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Grid
    {
        Random rand = new Random();
        public int width, height;
        private readonly int bombsCount;
        private int tilesLeft;
        private Tile[,] tileArray;
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

        // Makes an array of tiles
        private void AddTiles()
        {
            tileArray = new Tile[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    tileArray[i, j] = new Tile(i, j);
            
        }

        private void AddBombs(Tile selectedTile)
        {
            int i = 0;
            while (i < bombsCount)
            {
                if (InsertRandomBomb(selectedTile))
                {
                    i++;
                }
            }
                
        }

        // Generates random numbers and inserts a bomb at that location.
        // Returns true if successful
        private bool InsertRandomBomb(Tile selectedTile)
        {
            int x = rand.Next(width);
            int y = rand.Next(height);
            // Inserts successfully when tile has no bomb already and is not adjacent
            // to and in the starting tile and returns true if successful else false
            Tile newBombTile = tileArray[x, y];
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
            int x = tile.GetX();
            int y = tile.GetY();
            // Iterate through adjacent tiles
            int[,] adjacentTilesIndices = GetAdjacentTilesIndices();
            int i, j;
            for (int m = 0; m < adjacentTilesIndices.GetLength(0); m++)
            {
                i = adjacentTilesIndices[m, 0];
                j = adjacentTilesIndices[m, 1];
                if (i + x >= 0 && i + x < width && j + y >= 0 && j + y < height)
                    yield return tileArray[x + i, y + j];
            }
        }

        private void SweepTile(Tile tile)
        {
            // Function will not called if tile is flagged
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
                    {
                        SweepAlgorithm(adjacentTile);
                    } 
                }    
            }
                
        }

        // DFS sweep tiles
        public void UserTileInteract(int x, int y, bool command)
        {
            Tile tile = tileArray[x, y];

            // Add bombs after the first tile has been clicked to prevent clicking on bomb instantly
            if (!addedBombs)
            {
                AddBombs(tile);
                addedBombs = true;
            }

            // Interacting with already revealed tile does nothing
            if (!tile.IsRevealed())
            {
                if (command)
                {
                    // Prevent sweeping tile if flagged
                    if (!tile.IsFlagged())
                        SweepTile(tile);
                }
                else 
                {
                    tile.Flag();
                }
            }
        }

        // Get adjacent tile list
        private static int[,] GetAdjacentTilesIndices()
        {
            // 5 1 4
            // 2 _ 0
            // 6 3 7
            return new int[,]
            {
                {1, 0}, {0, 1}, {-1, 0}, {0, -1},
                {1, 1}, {-1, 1}, {-1, -1}, {1, -1}
            };
        }

        // Get methods
        public Tile[,] GetTileArray() { return tileArray; }
        public int GetTilesLeft() { return tilesLeft; }
        public int GetBombsCount() { return bombsCount; }
        public bool GetHitBomb() { return hitBomb; }  
    }
}
