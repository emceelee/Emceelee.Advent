using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_10 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 10 Solution: " + Solve(67, 686).ToString("yyyy-MM"));
        }
        
        public DateTime Solve(int years, int daysPerYear)
        {
            var today = new DateTime(2022, 12, 10);

            var days = years * daysPerYear;

            var previousDate = today.AddDays(-1 * days);

            return previousDate;
        }
    }
}
