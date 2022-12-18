using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Transforms
{
    public class DestroyMineTransform : TransformBase
    {
        protected override bool ApplyTransformInternal(char[,] map, int x, int y, out char nextState)
        {
            var currentState = map[x, y];
            //default to currentState
            nextState = currentState;

            if (currentState != Constants22_18.Mine)
            {
                return false;
            }

            //If not adjacent to at least one other Mine AND at least one Silicon
            if (!(GetAdjacentCount(map, x, y, Constants22_18.Mine) >= 1 &&
                GetAdjacentCount(map, x, y, Constants22_18.Silicon) >= 1))
            {
                nextState = Constants22_18.Empty;
                return true;
            }

            return false;
        }
    }
}
