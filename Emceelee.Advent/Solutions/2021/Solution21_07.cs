using System;
using System.Collections.Generic;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_07 : ISolution
    {
        public void Solve()
        {
            var text = Utility.ReadAllText("DataSet\\2021\\07_data.txt");
            var resolver = new SetCountResolver();

            var result = resolver.ResolveSetCounts(text, 3);

            Console.WriteLine("Day 07 Solution: " + result);
        }
    }
}
