using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Transforms
{
    public abstract class TransformBase : ITransform<char>
    {
        public int SuccessCount { get; private set; } = 0;

        public bool ApplyTransform(char[,] map, int x, int y, out char nextState)
        {
            if(ApplyTransformInternal(map, x, y, out nextState))
            {
                ++SuccessCount;
                return true;
            }
            return false;
        }

        protected abstract bool ApplyTransformInternal(char[,] map, int x, int y, out char nextState);

        public short GetAdjacentCount(char[,] map, int x, int y, char search)
        {
            var nearby = new short[3] { -1, 0, 1 };
            short count = 0;

            for (int nx = 0; nx < nearby.Length; ++nx)
            {
                for (int ny = 0; ny < nearby.Length; ++ny)
                {
                    var offsetX = nearby[nx];
                    var offsetY = nearby[ny];

                    //don't search original position
                    if(offsetX == 0 && offsetY == 0)
                    {
                        continue;
                    }

                    var currX = x + offsetX;
                    var currY = y + offsetY;

                    //out of bounds
                    if(currX < 0 || currY < 0)
                    {
                        continue;
                    }
                    //out of bounds
                    if (currX >= map.GetLength(0) || currY >= map.GetLength(1))
                    {
                        continue;
                    }

                    var curr = map[currX, currY];
                    if(curr == search)
                    {
                        ++count;
                    }
                }
            }
            return count;
        }
    }
}
