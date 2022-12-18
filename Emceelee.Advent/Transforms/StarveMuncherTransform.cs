using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Transforms
{
    public class StarveMuncherTransform : TransformBase
    {
        protected override bool ApplyTransformInternal(char[,] map, int x, int y, out char nextState)
        {
            var currentState = map[x, y];
            //default to currentState
            nextState = currentState;

            if (currentState != Constants22_18.Muncher)
            {
                return false;
            }

            //If no adjacent silicon, starve
            if (GetAdjacentCount(map, x, y, Constants22_18.Silicon) == 0)
            {
                nextState = Constants22_18.Empty;
                return true;
            }

            return false;
        }
    }
}
