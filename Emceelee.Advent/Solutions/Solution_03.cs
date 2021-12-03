using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution_03 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 03 Solution: " + Solve(50000));
        }

        //sum primes from 1...n
        public int Solve(int n)
        {
            var primeResolver = new PrimeResolver();
            var primes = primeResolver.ResolvePrimes(n);
            var palindromeResolver = new PalindromeResolver();
            var palindromePrimes = palindromeResolver.ResolvePalindromes(primes.Cast<object>()).Cast<int>();

            var sum = 0;

            if (palindromePrimes.Any())
            {
                sum = palindromePrimes.Sum();
            }

            return sum;
        }
    }
}
