using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public static class Constants
    {
        public const int ScreenWidth = 500;
        public const int ScreenHeight = 500;
        public const int CommandSweepTile = 0;
        public const int CommandFlagTile = 1;

        public const int Easy = 0;
        public const int Medium = 1;
        public const int Hard = 2;

        public const int WidthEasy = 9;
        public const int HeightEasy = 9;
        public const int BombsCountEasy = 10;
        public const int WidthMedium = 16;
        public const int HeightMedium = 16;
        public const int BombsCountMedium = 40;
        public const int WidthHard = 25;
        public const int HeightHard = 25;
        public const int BombsCountHard = 80;

        public const int ButtonBorderThickness = 2;

        public const int InProgress = 0;
        public const int Win = 1;
        public const int Lose = 2;
    }
}
