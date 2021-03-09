namespace Minesweeper
{
    static class AdjacentIndexList
    {
        public static int[][] Get()
        {
            int[][] adjacentIndexList = new int[][]
            {
                new int[] {1, 0}, new int[] {0, 1},
                new int[] {-1, 0}, new int[] {0, -1},
                new int[] {1, 1}, new int[] {-1, 1},
                new int[] {-1, -1}, new int[] {1, -1}
            };
            return adjacentIndexList;
        }
    }
}