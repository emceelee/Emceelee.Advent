using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution_03 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 03 Solution: " + Solve(50000));
        }

        //sum palindrome primes from 1...n
        public int Solve(int n)
        {
            var primeResolver = new PrimeResolver();
            var primes = primeResolver.ResolvePrimes(n);
            var palindromeResolver = new PalindromeResolver();
            var palindromePrimes = palindromeResolver.ResolvePalindromes(primes);

            var sum = 0;

            if (palindromePrimes.Any())
            {
                sum = palindromePrimes.Sum();
            }

            return sum;
        }
    }
}
