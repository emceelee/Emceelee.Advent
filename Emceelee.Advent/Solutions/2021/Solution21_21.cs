using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_21 : ISolution
    {
        public void Solve()
        {
            var resolver = new PermutationResolver();
            var permutations = resolver.ResolvePermutations("264091").ToList();
            Console.WriteLine("Day 17 Solution: " + permutations[233-1]);
        }
    }
}
