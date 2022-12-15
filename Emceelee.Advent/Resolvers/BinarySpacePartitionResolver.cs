using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class BinarySpacePartitionResolver
    {
        readonly char LowerHalf;
        readonly char UpperHalf;

        public BinarySpacePartitionResolver(char lower, char upper)
        {
            LowerHalf = lower;
            UpperHalf = upper;
        }

        public int ResolveIndex(string input)
        {
            /*
             * Ex: 7 chars FFFFFFF -> size = 128 => [0, 127]
             *  index 0: size = 64 => [0,63]
             *  index 1: size = 32 => [0,31]
             *  index 2: size = 16 => [0,15]
             *  index 3: size = 8 => [0,7]
             *  index 4: size = 4 => [0,3]
             *  index 5: size = 2 => [0,1]
             *  index 6: size = 1 => [0,0]
            */
            var size = (int) Math.Pow(2, input.Length);
            var lower = 0;
            var upper = size - 1;

            foreach(char k in input)
            {
                var range = upper - lower + 1;
                var mid = range / 2 + lower;

                if (k == this.UpperHalf)
                {
                    lower = mid;
                }
                else if(k == this.LowerHalf)
                {
                    upper = mid - 1;
                }
            }

            if(upper != lower)
            {
                throw new Exception("After end of algorithm, should converge to a single number");
            }

            return upper;
        }
    }
}
