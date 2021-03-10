using System;
using System.Collections.Generic;

namespace Minesweeper
{
    static class PrintGame
    {
        private static IEnumerable<Tile> SearchGrid(Grid grid)
        {
            Console.Write('\n');
            Console.Write($"Bombs: {grid.GetBombsCount()}\n");
            PrintXCoords(grid);
            for (int j = 0; j < grid.height; j++)
            {
                Console.Write($"{j}| ");
                for (int i = 0; i < grid.width; i++)
                {
                    yield return grid.GetTileArray()[i][j];
                    Console.Write(' ');
                }
                Console.Write('\n');
            }
            Console.Write('\n');
        }

        private static void PrintXCoords(Grid grid)
        {
            Console.Write("   ");
            for (int i = 0; i < grid.width; i++)
            {
                Console.Write($"{i} ");
            }
            Console.Write('\n');

            Console.Write("   ");
            for (int i = 0; i < grid.width; i++)
            {
                Console.Write("_ ");
            }
            Console.Write('\n');
        }

        public static void PlayerView(Grid grid)
        {
            bool revealed;
            foreach (Tile tile in SearchGrid(grid))
            {
                revealed = tile.IsRevealed();
                if (revealed)
                {
                    if (tile.IsBomb())
                        Console.Write('X');
                    else if (tile.GetAdjacentBombsCount() == 0)
                        Console.Write(' ');
                    else
                        Console.Write(tile.GetAdjacentBombsCount());
                }
                else
                {
                    if (tile.IsFlagged())
                        Console.Write('F');
                    else
                        Console.Write((char)9632);
                }
            }
        }

        //Debug check what tiles are revealed
        public static void RevealView(Grid grid)
        {
            bool revealed;
            foreach (Tile tile in SearchGrid(grid))
            {
                revealed = tile.IsRevealed();
                if (revealed)
                    Console.Write('T');
                else
                    Console.Write('F');
            }
        }

        //Debug check what tiles have a bomb
        public static void BombView(Grid grid)
        {
            bool isBomb;
            foreach (Tile tile in SearchGrid(grid))
            {
                isBomb = tile.IsBomb();
                if (isBomb)
                    Console.Write('X');
                else
                    Console.Write((char)9632);
            }
        }

        //Debug check how many bombs surround a tile
        public static void AdjacentBombsCountView(Grid grid)
        {
            foreach (Tile tile in SearchGrid(grid))
            {
                if (tile.IsBomb())
                    Console.Write('X');
                else
                    Console.Write(tile.GetAdjacentBombsCount());
            }
        }
    }
}