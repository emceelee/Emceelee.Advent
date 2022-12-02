using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class EvensResolver
    {
        public HashSet<int> ResolveEvens(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Number must be > 0");
            }

            var result = new HashSet<int>();
            var possibleEvens = Enumerable.Range(1, n);

            foreach (var possibleEven in possibleEvens)
            {
                if (IsEven(possibleEven))
                {
                    if (!result.Contains(possibleEven))
                    {
                        result.Add(possibleEven);
                    }
                }
            }

            return result;
        }

        private bool IsEven(int n)
        {
            return n % 2 == 0;
        }
    }
}
