using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_03 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 03 Solution: " + Solve(1000003));
        }

        public int Solve(int n)
        {
            var resolver = new PrimeResolver();
            var primes = resolver.ResolvePrimes(n);

            return primes.Count();
        }
    }
}
