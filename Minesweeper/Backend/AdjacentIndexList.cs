namespace Minesweeper
{
    static class AdjacentIndexList
    {
        /* Get list of list of tuples pointing to adjacent tiles
         *
         *   5   1   4
         *   2   _   0
         *   6   3   7
        */
        public static int[][] Get()
        {
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