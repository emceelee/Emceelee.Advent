using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_07 : ISolution
    {
        public void Solve()
        {
            var names = Utility.ReadLines(@"DataSet\2022\07_names.txt");
            Console.WriteLine("Day 07 Solution: " + Solve(names));
        }

        public int Solve(IEnumerable<string> names)
        {
            var resolver = new MartianResolver();
            var result = resolver.ResolveMartians(names);
            return result.Count();
        }
    }
}
