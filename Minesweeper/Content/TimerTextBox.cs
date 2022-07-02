using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class TimerTextBox : CustomTextBox
    {
        private Timer tm;
        private DateTime startTime;

        public TimerTextBox(string text, int locationX, int locationY) : base(text, locationX, locationY)
        {
            startTime = DateTime.Now;
            tm = new Timer();
            tm.Tick += new EventHandler(UpdateTime);
            tm.Interval = 10;
            tm.Enabled = true;
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            if (tm.Enabled)
            {
                int timePassed = (int)(DateTime.Now - startTime).TotalSeconds;
                Text = timePassed.ToString();
            }
        }

        public void Stop()
        {
            tm.Enabled = false;
        }
    }
}
