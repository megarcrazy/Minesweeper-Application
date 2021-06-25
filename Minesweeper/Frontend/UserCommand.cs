using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class UserCommand
    {
        public int x, y, command;
        public UserCommand(int x, int y, int command)
        {
            this.x = x;
            this.y = y;
            this.command = command;
        }
    }
}
