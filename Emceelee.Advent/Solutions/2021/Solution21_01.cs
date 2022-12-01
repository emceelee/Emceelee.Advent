using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_01 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 01 Solution: " + Solve(100));
        }

        //sum primes from 1...n
        public int Solve(int n)
        {
            var resolver = new PrimeResolver();
            var primes = resolver.ResolvePrimes(n);

            var sum = 0;

            if(primes.Any())
            {
                sum = primes.Sum();
            }

            return sum;
        }
    }
}
