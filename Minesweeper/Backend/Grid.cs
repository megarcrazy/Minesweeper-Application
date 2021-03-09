using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Grid
    {
        public int width;
        public int height;

        private readonly int size;
        private readonly float BombFraction = 0.125f;
        private int BombCount;
        private int TilesLeft;
        private Tile[][] tileArray;
        private bool HitBomb = false;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            size = width * height;

            Start();
        }

        public Tile[][] GetTileArray()
        {
            return tileArray;
        }

        public int GetTilesLeft()
        {
            return TilesLeft;
        }

        public int GetBombCount()
        {
            return BombCount;
        }

        public bool GetHitBomb()
        {
            return HitBomb;
        }

        private void Start()
        {
            AddTiles();
            AddBombs();
            CountAdjacentBombs();
        }

        private void CheckInputErrors()
        {
            Debug.Assert(width >= 5);
            Debug.Assert(height >= 5);
            Debug.Assert(BombFraction < 0.4f);
        }

        private void AddTiles()
        {
            //Makes an array of tiles
            tileArray = new Tile[width][];
            for (int i = 0; i < width; i++)
            {
                tileArray[i] = new Tile[height];
                for (int j = 0; j < height; j++)
                {
                    tileArray[i][j] = new Tile(i, j);
                }
            }
        }

        private void AddBombs()
        {
            BombCount = (int)Math.Floor(BombFraction * size);
            TilesLeft = size - BombCount;
            for (int i = 0; i < BombCount; i++)
            {
                if (!InsertRandomBomb())
                {
                    i--;
                }
            }
        }

        //Gets a random number and inserts a bomb at that location
        private bool InsertRandomBomb()
        {
            Random rand = new Random();
            int number = rand.Next(size);
            int x = number / width;
            int y = number % height;
            Tile tile = tileArray[x][y];
            if (!tile.IsBomb())
            {
                tile.AddBomb();
                return true;
            }
            return false;
        }

        //Runs through tileArray and adds the bomb count to each adjacent tile by 1
        private void CountAdjacentBombs()
        {
            Tile tile;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    tile = tileArray[i][j];
                    if (tile.IsBomb())
                    {
                        AddBombCountToSurroundingTiles(i, j);
                    }
                }
            }
        }

        private void AddBombCountToSurroundingTiles(int i, int j)
        {
            foreach (Tile tile in GetAdjacentTiles(i, j))
            {
                tile.IncreaseAdjacentBombsCount();
            }
        }

        private IEnumerable<Tile> GetAdjacentTiles(int i, int j)
        {
            int[][] adjacentIndexList = AdjacentIndexList.Get();
            int x, y;
            foreach (int[] adjacentIndex in adjacentIndexList)
            {
                x = adjacentIndex[0];
                y = adjacentIndex[1];
                if (i + x >= 0 && i + x < width && j + y >= 0 && j + y < height)
                {
                    yield return tileArray[i + x][j + y];
                }
            }
        }

        //Interactions between the user input and the game
        public void Sweep(int[] Coords, int round = 0)
        {
            int i = Coords[0]; int j = Coords[1];
            int command = Coords[2];
            Tile tile = tileArray[i][j];

            if (round == 1)
            {
                FirstRound(tile);
                tile = tileArray[i][j];
            }

            if (!tile.IsRevealed())
            {
                if (command == 1)
                {
                    tile.Flag();
                }
                else if (tile.IsBomb())
                {
                    SetHitBomb(tile);
                }
                else
                {
                    SuccessfulSweep(tile);
                    SweepAlgorithm(tile);
                }
            }
        }

        private void SetHitBomb(Tile tile)
        {
            tile.Reveal();
            HitBomb = true;
        }

        private void SuccessfulSweep(Tile tile)
        {
            tile.Reveal();
            TilesLeft--;
        }

        private void SweepAlgorithm(Tile tile)
        {
            if (tile.GetAdjacentBombsCount() == 0)
            {
                foreach (Tile adjacentTile in GetAdjacentTiles(tile.GetX(), tile.GetY()))
                {
                    if (!adjacentTile.IsRevealed())
                    {
                        Sweep(new int[] { adjacentTile.GetX(), adjacentTile.GetY(), 0 });
                    }
                }
            }
        }

        private void FirstRound(Tile tile)
        {
            if (tile.IsBomb() || tile.GetAdjacentBombsCount() != 0)
            {
                int i = tile.GetX();
                int j = tile.GetY();
                Start();
                Sweep(new int[] { i, j, 0 }, 1);
            }
        }
    }
}
