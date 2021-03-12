using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class UserInput
    {
        public int x, y, command;
        public UserInput(int x, int y, int command)
        {
            this.x = x;
            this.y = y;
            this.command = command;
        }
    }
}
