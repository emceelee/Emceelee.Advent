using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class SquaresResolver
    {
        public HashSet<int> ResolveSquares(int n)
        {
            if(n < 0)
            {
                throw new ArgumentOutOfRangeException("n must be >= 0");
            }
            var result = new HashSet<int>();
            var i = 0;
            var square = 0;

            do
            {
                square = i * i;
                if(square <= n)
                {
                    result.Add(square);
                }
                ++i;
            }
            while (square < n);

            return result;
        }
    }
}
