using System;

namespace Minesweeper
{
    public class BackEnd
    {
        public Logic logic;
        public BackEnd(int x, int y)
        {
           logic = new Logic(x, y);
        }
    }
}