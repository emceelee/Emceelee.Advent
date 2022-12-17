using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emceelee.Advent.Forms
{
    public partial class Solution22_17 : Form
    {
        private readonly List<List<int>> Bitmap;

        public Solution22_17()
        {
            var data = Utility.ReadAllText(@"DataSet\2022\17_IceData.txt");

            Bitmap = new List<List<int>>();
            
            var pixels = data.Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => int.Parse(x));

            var size = (int) Math.Sqrt(pixels.Count());
            var remainder = pixels;

            for(int i = 0; i < size; ++i)
            {
                var currentRow = remainder.Take(size).ToList();
                Bitmap.Add(currentRow);
                remainder = remainder.Skip(size);
            }

            InitializeComponent();
        }

        private void Solution22_17_Paint(object sender, PaintEventArgs e)
        {
            var brush = new SolidBrush(Color.White);
            var graphics = this.CreateGraphics();

            for(int y = 0; y < this.Bitmap.Count; ++y)
            {
                var row = this.Bitmap[y];

                for(int x = 0; x < row.Count; ++x)
                {
                    var grayscale = row[x];
                    var grayIndex = grayscale * 255 / 765;
                    var color = Color.FromArgb(grayIndex, grayIndex, grayIndex);
                    brush.Color = color;

                    graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }
        }
    }
}
