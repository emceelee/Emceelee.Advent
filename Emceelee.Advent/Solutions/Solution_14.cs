using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution_14 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 14 Solution: " + Solve(2021));
        }

        public BigInteger Solve(int n)
        {
            var resolver = new FiboResolver();
            var result = resolver.ResolveFibo(n);
            return result;
        }
    }
}
