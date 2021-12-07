using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class SetCountResolver
    {
        //return # of sets of x identical characters in sequence
        public int ResolveSetCounts(string text, int setLength)
        {
            if(setLength < 1)
            {
                throw new ArgumentOutOfRangeException("setLength must be positive");
            }

            var count = 0;

            for(int i = 0; i < text.Length - (setLength - 1); ++i)
            {
                var substring = text.Substring(i, setLength);
                var firstK = substring[0];
                if(!substring.Any(k => k != firstK))
                {
                    ++count;
                }
            }

            return count;
        }
    }
}
