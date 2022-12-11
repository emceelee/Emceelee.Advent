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
    public partial class Solution22_11 : Form
    {
        private readonly IEnumerable<string> Vectors;
        public Solution22_11()
        {
            Vectors = Utility.ReadLines(@"DataSet\2022\11_vectors.txt");
            InitializeComponent();
        }

        private void Solution22_11_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            var x1 = (float) 50;
            var y1 = (float) this.Size.Height / 4;

            foreach(var vector in this.Vectors)
            {
                ParseVector(vector, out float xVector, out float yVector);
                var x2 = x1 + xVector;
                var y2 = y1 - yVector; //painting y vector is reversed
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);

                //set new starting point
                x1 = x2;
                y1 = y2;
            }
        }

        private void ParseVector(string vector, out float x, out float y)
        {
            var removedParen = new string(vector.Where(k => k != '(' && k != ')').ToArray());
            var xy = removedParen.Split(',').Select(s => s.Trim()).ToArray();

            if(xy.Length != 2)
            {
                throw new Exception("Couldn't parse vector");
            }

            if (!float.TryParse(xy[0], out x))
            {
                throw new Exception("Couldn't parse vector for x component");
            }

            if (!float.TryParse(xy[1], out y))
            {
                throw new Exception("Couldn't parse vector for y component");
            }
        }
    }
}
