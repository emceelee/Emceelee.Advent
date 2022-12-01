using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_11 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 11 Solution: " + Solve(9999));
        }

        public string Solve(int n)
        {
            var dayOfWeekCounts = new int[7];

            var christmasEves = Enumerable.Range(1, n)
                .Where(i => DateTime.IsLeapYear(i))
                .Select(i => new DateTime(i, 12, 24));

            foreach(var christmasEve in christmasEves)
            {
                int index = -1;

                switch(christmasEve.DayOfWeek)
                {
                    case (DayOfWeek.Sunday):
                        index = 0;
                        break;
                    case (DayOfWeek.Monday):
                        index = 1;
                        break;
                    case (DayOfWeek.Tuesday):
                        index = 2;
                        break;
                    case (DayOfWeek.Wednesday):
                        index = 3;
                        break;
                    case (DayOfWeek.Thursday):
                        index = 4;
                        break;
                    case (DayOfWeek.Friday):
                        index = 5;
                        break;
                    case (DayOfWeek.Saturday):
                        index = 6;
                        break;
                }

                ++dayOfWeekCounts[index];
            }

            var result = string.Join(',', dayOfWeekCounts);

            return result;
        }
    }
}
