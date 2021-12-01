using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution_01 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 01 Solution: " + Solve(100));
        }

        //sum primes from 1...n
        public int Solve(int n)
        {
            if(n <= 0)
            {
                throw new ArgumentOutOfRangeException("Number must be > 0");
            }

            DeterminePrimes(n);

            var sum = 0;

            if(Primes.Any())
            {
                sum = Primes.Where(i => i <= n).Sum();
            }

            return sum;
        }

        //populate with primes as we increment up to n
        private List<int> Primes { get; } = new List<int>();

        private void DeterminePrimes(int n)
        {
            var possiblePrimes = Enumerable.Range(1, n);

            foreach (var possiblePrime in possiblePrimes)
            {
                if (IsPrime(possiblePrime))
                {
                    if (!Primes.Contains(possiblePrime))
                    {
                        Primes.Add(possiblePrime);
                    }
                }
            }
        }

        //must execute numbers less than n before n
        private bool IsPrime(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Number must be >= 0");
            }

            if(n == 0 || n == 1)
            {
                return false;
            }

            foreach (var prime in Primes.Where(i => i <= Math.Ceiling(Math.Sqrt(n))))
            {
                if (n % prime == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
