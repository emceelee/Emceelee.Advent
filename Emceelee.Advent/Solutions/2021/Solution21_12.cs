using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_12 : ISolution
    {
        public void Solve()
        {
            var lines = Utility.ReadLines("DataSet\\2021\\12_data.txt");
            Console.WriteLine("Day 12 Solution: " + Solve(lines));
        }

        public int Solve(IEnumerable<string> lines)
        {
            //order alphabetically
            var names = lines.OrderBy(name => name)
                .Select(name => name.ToUpper().Replace(" ", string.Empty));

            //first name = index 1
            var index = 1;
            var sum = 0;

            //get ASCII value for all characters * ordered index # and sum across all names
            foreach (var name in names)
            {
                sum += (index++ * name.Select(k => (int)k).Sum());
            }

            return sum;
        }
    }
}
