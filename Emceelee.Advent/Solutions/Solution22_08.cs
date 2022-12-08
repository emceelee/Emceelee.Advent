using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_08 : ISolution
    {
        public void Solve()
        {
            var phrases = Utility.ReadLines(@"DataSet\2022\08_phrases.txt");
            Console.WriteLine("Day 08 Solution: " + Solve(phrases));
        }

        public int Solve(IEnumerable<string> phrases)
        {
            var resolver = new PassphraseResolver();
            var result = resolver.ResolveValidPassphrases(phrases);
            return result.Count();
        }
    }
}
