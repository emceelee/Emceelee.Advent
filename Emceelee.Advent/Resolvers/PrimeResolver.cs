using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class PrimeResolver
    {
        //populate with primes as we increment up to n
        private HashSet<int> Primes { get; } = new HashSet<int>();

        public HashSet<int> ResolvePrimes(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Number must be > 0");
            }

            var result = new HashSet<int>();
            var possiblePrimes = Enumerable.Range(1, n);

            foreach (var possiblePrime in possiblePrimes)
            {
                if (IsPrime(possiblePrime))
                {
                    if (!Primes.Contains(possiblePrime))
                    {
                        Primes.Add(possiblePrime);
                    }
                    if (!result.Contains(possiblePrime))
                    {
                        result.Add(possiblePrime);
                    }
                }
            }

            return result;
        }

        //must execute numbers less than n before n
        private bool IsPrime(int n)
        {
            if (n == 0 || n == 1)
            {
                return false;
            }

            foreach (var prime in Primes.Where(i => i <= Math.Ceiling(Math.Sqrt(n))))
            {
                if(prime >= n)
                {
                    break;
                }
                if (n % prime == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
