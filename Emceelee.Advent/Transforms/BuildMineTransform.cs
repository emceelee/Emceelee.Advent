using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Transforms
{
    public class BuildMineTransform : TransformBase
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

            //If >= 3 surrounding Mine, transform into Mine
            if (GetAdjacentCount(map, x, y, Constants22_18.Mine) >= 3)
            {
                nextState = Constants22_18.Mine;
                return true;
            }

            return false;
        }
    }
}
