using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class CubesResolver
    {
        public HashSet<int> ResolveCubes(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("n must be >= 0");
            }
            var result = new HashSet<int>();
            var i = 0;
            var cube = 0;

            do
            {
                cube = i * i * i;
                if (cube <= n)
                {
                    result.Add(cube);
                }
                ++i;
            }
            while (cube < n);

            return result;
        }
    }
}
