using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class PalindromeResolver
    {
        public IEnumerable<object> ResolvePalindromes(IEnumerable<object> possiblePalindromes)
        {
            return possiblePalindromes.Where(x => IsPalindrome(x));
        }

        public bool IsPalindrome(object obj)
        {
            var strObj = obj.ToString();
            var length = strObj.Length;
            var midPoint = (int)Math.Ceiling(length / 2.0);

            for(int i = 0; i < midPoint; ++i)
            {
                var k = strObj[i];
                var kReverse = strObj[length - 1 - i];

                if(k != kReverse)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
