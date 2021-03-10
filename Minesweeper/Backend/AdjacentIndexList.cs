namespace Minesweeper
{
    static class AdjacentIndexList
    {
        // Get list of list of tuples pointing to adjacent tiles
        //
        //  _   1   _       5   1   4
        //  2   _   0  or   2   _   0
        //  _   3   _       6   3   7
        public static int[][] Get(bool getHalf = false)
        {
            // Get half the adjacent tiles
            if (getHalf)
            {
                return new int[][]
                {
                    new int[] {1, 0}, new int[] {0, 1},
                    new int[] {-1, 0}, new int[] {0, -1},
                    new int[] {1, 1}, new int[] {-1, 1},
                    new int[] {-1, -1}, new int[] {1, -1}
                };
            }

            // Or get the entire list
            return new int[][]
            {
                new int[] {1, 0}, new int[] {0, 1},
                new int[] {-1, 0}, new int[] {0, -1},
                new int[] {1, 1}, new int[] {-1, 1},
                new int[] {-1, -1}, new int[] {1, -1}
            };
        }
    }
}