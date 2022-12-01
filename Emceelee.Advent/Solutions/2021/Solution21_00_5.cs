using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_00_5 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 0.5 Solution: " + Solve(1000000));
        }

        public double Solve(int n, int decimals = 3)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("Number of iterations must be >= 0");
            }
            if (decimals < 0)
            {
                throw new ArgumentOutOfRangeException("Number of decimals must be >= 0");
            }

            var result = 0.0;
            var sign = 1;

            var range = Enumerable.Range(0, n+1).Select(i => 2*i + 1);
            
            foreach(var value in range)
            {
                if(value == 0)
                {
                    throw new InvalidOperationException("Denominator can't be zero");
                }

                var term = ((double)sign) / value;
                result += term;
                sign *= -1;
            }

            result *= 4;
            return Math.Round(result, decimals, MidpointRounding.AwayFromZero);
        }
    }
}
