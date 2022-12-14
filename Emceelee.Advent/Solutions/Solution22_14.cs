using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_14 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 14 Solution: " + Solve(47));
        }
        
        public int Solve(int rounds)
        {
            var resolver = new RobotGameResolver();
            var seconds = resolver.ResolveSeconds(rounds, out string result);

            return seconds;
        }
    }
}
