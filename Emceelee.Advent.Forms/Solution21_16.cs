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
    public partial class Solution21_16 : Form
    {
        private enum RGB
        {
            R,
            G,
            B
        }

        private HashSet<int> Primes { get; set; }

        public Solution21_16()
        {
            InitializeComponent();

            Primes = new PrimeResolver().ResolvePrimes(255);
        }

        private void Solution_16_Paint(object sender, PaintEventArgs e)
        {
            Bitmap image = new Bitmap("16_coded.png");
            var resolver = new PrimeResolver();

            e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    var color = image.GetPixel(x, y);
                    //Set pixel to black if one of RGB is prime
                    color = IsColorPrime(color, RGB.G) ? Color.Black : Color.White;

                    image.SetPixel(x, y, color);
                }
            }

            e.Graphics.DrawImage(image, 0, image.Height+1, image.Width, image.Height);
        }

        private bool IsPrime(int n)
        {
            return Primes.Contains(n);
        }

        private bool IsColorPrime(Color c, RGB rgb)
        {
            bool result = false;
            switch(rgb)
            {
                case RGB.R:
                    result = IsPrime(c.R);
                    break;
                case RGB.G:
                    result = IsPrime(c.G);
                    break;
                case RGB.B:
                    result = IsPrime(c.B);
                    break;
            }
            return  result;
        }
    }
}
