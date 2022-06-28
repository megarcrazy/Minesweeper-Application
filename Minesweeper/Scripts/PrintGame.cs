using System;
using System.Collections.Generic;

namespace Minesweeper
{
    /* Static class containing methods of printing various views of the Minesweeper grid in the console
     * for debugging purposes
     * 
     * Easy Example:
     *    0 1 2 3 4 5 6 7 8
     *    _ _ _ _ _ _ _ _ _
     * 0| ¦ ¦ ¦ ¦ ¦ ¦ ¦ ¦ ¦
     * 1| ¦ 1 1 1 2 1 2 ¦ ¦
     * 2| ¦ 1         1 1 1
     * 3| ¦ 2 1 1
     * 4| ¦ ¦ ¦ 2 1 1
     * 5| ¦ ¦ ¦ ¦ ¦ 2 1 1
     * 6| ¦ ¦ ¦ ¦ ¦ ¦ ¦ 2 1
     * 7| ¦ ¦ ¦ ¦ ¦ ¦ ¦ ¦ ¦
     * 8| ¦ ¦ ¦ ¦ ¦ ¦ ¦ ¦ ¦
    */
    static class PrintGame
    {
        // Enumerator to go through each tile in array
        private static IEnumerable<Tile> SearchGrid(Grid grid)
        {
            Console.Write('\n');
            Console.Write($"Bombs: {grid.GetBombsCount()}\n");
            PrintXCoords(grid); // Print Row
            for (int j = 0; j < grid.height; j++)
            {
                Console.Write($"{j}| "); // Print column
                for (int i = 0; i < grid.width; i++)
                {
                    yield return grid.GetTileArray()[i, j];
                    Console.Write(' ');
                }
                Console.Write('\n');
            }
            Console.Write('\n');
        }

        // Print the x-coordinates row below the printed grid
        private static void PrintXCoords(Grid grid)
        {
            Console.Write("   ");
            for (int i = 0; i < grid.width; i++)
                Console.Write($"{i} ");
            Console.Write("\n   ");
            for (int i = 0; i < grid.width; i++)
                Console.Write("_ ");
            Console.Write('\n');
        }

        // Views a text console version of the windows application visualisation
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

        // Print check what tiles are revealed
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

        // Print check what tiles have a bomb
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

        // Print check how many bombs surround each tile
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