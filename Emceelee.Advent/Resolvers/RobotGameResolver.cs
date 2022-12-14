using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class RobotGameResolver
    {
        const int SecondsPerDigit = 2;
        const int SecondsPerPause = 5;

        public int ResolveSeconds(int rounds, out string result)
        {
            if(rounds == 0)
            {
                result = string.Empty;
                return 0;
            }

            var seconds = SecondsPerDigit;

            seconds += ResolveSeconds("1", rounds - 1, out result);
            return seconds;
        }

        public int ResolveSeconds(string current, int rounds, out string result)
        {
            if(rounds == 0)
            {
                result = current;
                return 0;
            }

            var seconds = SecondsPerPause;
            var next = GetNext(current);
            seconds += SecondsPerDigit * next.Length;
            seconds += ResolveSeconds(next, rounds - 1, out result);

            return seconds;
        }

        public string GetNext(string current)
        {
            var runningCount = 0;
            var prevChar = '0';
            var nextValue = new StringBuilder();

            for(int i = 0; i < current.Length; ++i)
            {
                var currChar = current[i];

                if(currChar != prevChar)
                {
                    if (runningCount > 0)
                    {
                        nextValue.Append(runningCount);
                        nextValue.Append(prevChar);
                    }
                    runningCount = 1;
                }
                else //increment
                {
                    ++runningCount;
                }
                prevChar = currChar;
            }
            nextValue.Append(runningCount);
            nextValue.Append(prevChar);

            return nextValue.ToString();
        }
    }
}
