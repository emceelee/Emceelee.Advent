using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_02 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 02 Solution: " + Solve(1000));
        }

        public int Solve(int n)
        {
            var resolver = new EvensResolver();
            var evens = resolver.ResolveEvens(n);

            var evensWith4 = evens.Where(x => x.ToString().Contains('4'));

            return evensWith4.Sum();
        }
    }
}
