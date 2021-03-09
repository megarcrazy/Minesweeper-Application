using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class WindowApplication : Form
    {
        private WindowsTile[][] WindowsTileArray; 
        private BackEnd backEnd;

        private int width = 10;
        private int height = 10;


        public WindowApplication()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Initiate(int size)
        {
            width = size;
            height = size;
            backEnd = new BackEnd(width, height);
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
            AddGrids();
        }

        private void AddGrids()
        {
            WindowsTileArray = new WindowsTile[width][];
            WindowsTile windowstile;
            for (int i = 0; i < width; i++)
            {
                WindowsTileArray[i] = new WindowsTile[width];
                for (int j = 0; j < height; j++)
                {
                    windowstile = new WindowsTile(i, j, width, height);
                    windowstile.MouseUp += MyButtonClickHandler;
                    WindowsTileArray[i][j] = windowstile;
                    this.Controls.Add(windowstile);
                }
            }
        }

        private void MyButtonClickHandler(object sender, MouseEventArgs e)
        {
            int command = 0;
            WindowsTile ClickedButton = (WindowsTile)sender;
            int x = ClickedButton.GetX();
            int y = ClickedButton.GetY();
            if (e.Button == MouseButtons.Right)
            {
                command = 1;
            }
            UpdateBackEnd(new int[] { x, y, command});
            UpdateVisual();
        }

        private void UpdateBackEnd(int[] UserInput)
        {
            backEnd.logic.Run(UserInput);
        }

        private void UpdateVisual()
        {
            Tile[][] tileArray = backEnd.logic.grid.GetTileArray();
            int i = tileArray.Length;
            int j = tileArray[0].Length;

            Tile tile;
            for (int m = 0; m < i; m++)
            {
                for (int n = 0; n < j; n++)
                {
                    tile = tileArray[m][n];
                    if (tile.IsRevealed() == true)
                    {
                        WindowsTileArray[m][n].BackColor = Color.SlateGray;
                        if (tile.IsBomb() == true)
                        {
                            WindowsTileArray[m][n].ChangeText("X");
                        }
                        else if (tile.GetAdjacentBombsCount() != 0)
                        {
                            WindowsTileArray[m][n].ChangeText($"{tile.GetAdjacentBombsCount()}");
                        }
                    }
                    if (tile.IsFlagged() == true)
                    {
                        WindowsTileArray[m][n].ChangeText("F");
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                Application.Restart();
                Environment.Exit(0);
                Console.WriteLine("Restart");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Initiate(10);
            Button buttonToRemove = (Button)sender;
            this.Controls.Remove(buttonToRemove);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Initiate(20);
            Button buttonToRemove = (Button)sender;
            this.Controls.Remove(buttonToRemove);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Initiate(30);
            Button buttonToRemove = (Button)sender;
            this.Controls.Remove(buttonToRemove);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
