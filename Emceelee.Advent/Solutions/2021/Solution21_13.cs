using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_13 : ISolution
    {
        public void Solve()
        {
            var garbledText = Utility.ReadAllText("DataSet\\13_garbled.txt");
            var errorSequence = Utility.ReadLines("DataSet\\13_sequence.txt")
                .Select(line => int.Parse(line.Replace(",", string.Empty)));
            Console.WriteLine("Day 13 Solution: " + Solve(garbledText, errorSequence));
        }

        public string Solve(string garbledText, IEnumerable<int> errorSequence)
        {
            var stringBuilder = new StringBuilder(garbledText);
            foreach(var index in errorSequence.Reverse())
            {
                stringBuilder.Remove(index, 1);
            }
            return stringBuilder.ToString();
        }
    }
}
