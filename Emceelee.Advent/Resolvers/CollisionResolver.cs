using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class CollisionResolver
    {
        public int ResolveCollisions(IEnumerable<string> linesEnumerable, int right, int down)
        {
            if (linesEnumerable == null)
            {
                throw new ArgumentNullException("lines must not be null");
            }
            if (!linesEnumerable.Any())
            {
                throw new ArgumentException("lines must have at least 1 row");
            }
            if (right < 0)
            {
                throw new ArgumentOutOfRangeException("right must be >= 0");
            }
            if (down < 1)
            {
                throw new ArgumentOutOfRangeException("down must be > 0");
            }

            var lines = linesEnumerable.ToArray();

            var result = 0;
            var firstLine = lines.FirstOrDefault();
            var length = firstLine.Length;

            if(lines.Any(x => x.Length != length))
            {
                throw new ArgumentException("All lines must be of the same length");
            }

            int currIndexX = right;
            int currIndexY = down;
            
            while (currIndexY < lines.Length)
            {
                var k = GetChar(lines, currIndexX, currIndexY);

                if(k == '#')
                {
                    ++result;
                }

                currIndexX += right;
                currIndexY += down;
            }

            return result;
        }

        //map repeats endlessly as you scroll right.  
        private char GetChar(string[] lines, int x, int y)
        {
            if (y < 0 || y >= lines.Length)
            {
                throw new ArgumentOutOfRangeException($"y must be > 0 and < {lines.Length}");
            }

            var firstLine = lines.FirstOrDefault();
            var length = firstLine.Length;

            //since the map repeats endlessly left to right, get the modulus of x
            //for line length 5, index 5 really is really the same as index 0
            x %= length;

            var k = lines[y][x];

            return k;
        }
    }
}
