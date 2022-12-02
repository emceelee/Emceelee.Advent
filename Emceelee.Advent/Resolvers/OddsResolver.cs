using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class OddsResolver
    {
        public HashSet<int> ResolveOdds(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Number must be > 0");
            }

            var result = new HashSet<int>();
            var possibleOdds = Enumerable.Range(1, n);

            foreach (var possibleOdd in possibleOdds)
            {
                if (IsOdd(possibleOdd))
                {
                    if (!result.Contains(possibleOdd))
                    {
                        result.Add(possibleOdd);
                    }
                }
            }

            return result;
        }

        private bool IsOdd(int n)
        {
            return n % 2 == 1;
        }
    }
}
