using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_12 : ISolution
    {
        public void Solve()
        {
            var instructions = Utility.ReadLines(@"DataSet\2022\12_instr.txt");
            Console.WriteLine("Day 12 Solution: ");
            Solve(40, 6, instructions);
        }
        
        public void Solve(int x, int y, IEnumerable<string> instructions)
        {
            var resolver = new KeypadCodeResolver();
            var result = resolver.ResolveKeypadCode(x, y, instructions);

            OutputResult(result);
        }

        private void OutputResult(bool[,] matrix)
        {
            for(int y = 0; y < matrix.GetLength(1); ++y)
            {
                var sb = new StringBuilder();
                for (int x = 0; x < matrix.GetLength(0); ++x)
                {
                    var isOn = matrix[x, y];
                    sb.Append(isOn ? "#" : ".");
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
