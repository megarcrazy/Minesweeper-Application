using System.Windows.Forms;
using System.Drawing;


namespace Minesweeper
{
    class CustomTextBox : Label
    {
        public CustomTextBox(string text, int locationX, int locationY)
        {
            Text = text;
            
            AutoSize = false;
            Size = new Size(200, 20);
            TabStop = false;
            TextAlign = ContentAlignment.MiddleCenter;

            SetLocation(locationX, locationY);
        }

        public void SetLocation(int locationX, int locationY)
        {
            Location = new Point(locationX - Size.Width / 2, locationY - Size.Height / 2);
        }
    }
}
