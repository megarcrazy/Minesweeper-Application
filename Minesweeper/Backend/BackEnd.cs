using System;

namespace Minesweeper
{
    // Controls the backend logic of the Minesweeper program
    public class BackEnd
    {
        public Logic logic;
        public BackEnd(int x, int y, int bombsCount)
        {
           logic = new Logic(x, y, bombsCount);
        }
    }
}