using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Transforms
{
    public class SpreadMuncherTransform : TransformBase
    {
        protected override bool ApplyTransformInternal(char[,] map, int x, int y, out char nextState)
        {
            var currentState = map[x, y];
            //default to currentState
            nextState = currentState;

            if (currentState != Constants22_18.Silicon)
            {
                return false;
            }

            //If exists an adjacent Muncher, spread
            if (GetAdjacentCount(map, x, y, Constants22_18.Muncher) > 0)
            {
                nextState = Constants22_18.Muncher;
                return true;
            }

            return false;
        }
    }
}
