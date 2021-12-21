using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class PermutationResolver
    {
        public IEnumerable<string> ResolvePermutations(string input)
        {
            if(input.Length == 0)
            {
                return Enumerable.Empty<string>();
            }
            else if (input.Length == 1)
            {
                return new List<string>() { input };
            }

            var result = new List<string>();

            for(int i=0; i<input.Length; ++i)
            {
                var k = input[i];
                var remainder = input.Remove(i, 1);

                var innerResult = ResolvePermutations(remainder);
                var permutations = innerResult.Select(permutation => k + permutation);
                result.AddRange(permutations);
            }
            return result.Distinct().OrderBy(x => x);
        }
    }
}
