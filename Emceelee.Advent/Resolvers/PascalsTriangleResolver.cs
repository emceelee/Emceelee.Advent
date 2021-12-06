using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class PascalsTriangleResolver
    {
        public void ResolveNextRow(List<long[]> triangle)
        {
            if(triangle == null)
            {
                throw new ArgumentNullException("triangle must not be null.");
            }

            var prevLength = 0;

            var prevRow = triangle.LastOrDefault();
            if(prevRow != null)
            {
                prevLength = prevRow.Length;
            }

            var currentLength = prevLength + 1;
            var currentRow = new long[currentLength];

            triangle.Add(currentRow);

            //set sides to 1
            currentRow[0] = 1;
            currentRow[currentLength - 1] = 1;
            
            //sum previous row's elements for current row
            for(int i = 1; i < prevLength; ++i)
            {
                var sum = prevRow[i - 1] + prevRow[i];
                currentRow[i] = sum;
            }
        }
    }
}
