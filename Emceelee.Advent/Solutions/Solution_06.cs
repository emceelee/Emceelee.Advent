using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution_06 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 06 Solution: " + Solve(1000000000));
        }

        public long Solve(long n)
        {
            var resolver = new PascalsTriangleResolver();
            var triangle = new List<long[]>();
            long result = 0;

            while (result <= n)
            {
                resolver.ResolveNextRow(triangle);
                result = triangle.LastOrDefault().Max();
            }

            return result;
        }
    }
}
