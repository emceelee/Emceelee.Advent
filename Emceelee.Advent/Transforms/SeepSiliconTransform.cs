using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Transforms
{
    public class SeepSiliconTransform : TransformBase
    {
        protected override bool ApplyTransformInternal(char[,] map, int x, int y, out char nextState)
        {
            var currentState = map[x, y];
            //default to currentState
            nextState = currentState;

            if (currentState != Constants22_18.Empty)
            {
                return false;
            }

            //If >= 3 surrounding silicon, transform into Silicon
            if(GetAdjacentCount(map, x, y, Constants22_18.Silicon) >= 3)
            {
                nextState = Constants22_18.Silicon;
                return true;
            }

            return false;
        }
    }
}
