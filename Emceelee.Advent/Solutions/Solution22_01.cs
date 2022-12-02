using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_01 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 01 Solution: " + Solve(1000));
        }

        public int Solve(int n)
        {
            var resolver = new OddsResolver();
            var odds = resolver.ResolveOdds(n);
            var oddsArray = odds.ToArray();

            //resolve odd numbers and then subtract 1 for corresponding index
            var oddIndexes = resolver.ResolveOdds(oddsArray.Length).Select(x => x-1);

            return oddIndexes.Sum(x => oddsArray[x]);
        }
    }
}
