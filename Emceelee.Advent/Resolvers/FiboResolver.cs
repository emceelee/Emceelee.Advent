using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class FiboResolver
    {
        List<BigInteger> FiboSequence = new List<BigInteger>() { 0, 1 };

        public BigInteger ResolveFibo(int n)
        {
            if(n < 1)
            {
                throw new ArgumentOutOfRangeException("n must be > 0");
            }
            while (FiboSequence.Count < n)
            {
                var lastIndex = FiboSequence.Count - 1;
                var lastIndexMinus1 = lastIndex - 1;
                var nextNumber = FiboSequence[lastIndexMinus1] + FiboSequence[lastIndex];
                FiboSequence.Add(nextNumber);
            }

            return FiboSequence[n-1];
        }
    }
}
