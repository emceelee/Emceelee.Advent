using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class ElevatorFloorResolver
    {
        public const string ExampleInstruction2_1 = "((";  //Resolves to Floor 2
        public const string ExampleInstruction2_2 = "2(";  //Resolves to Floor 2
        public const string ExampleInstruction0_1 = "(())";  //Resolves to Floor 0
        public const string ExampleInstruction0_2 = "()()";  //Resolves to Floor 0
        public const string ExampleInstruction0_3 = "2(2)";  //Resolves to Floor 0
        public const string ExampleInstruction1_1 = "((())()(())";  //Resolves to Floor 1

        public int ResolveFloor(string instructions)
        {
            var result = 0;
            var multiplier = 1;
            foreach(char k in instructions)
            {
                if(k == '(')
                {
                    result += multiplier;
                }
                else if(k == ')')
                {
                    result -= multiplier;
                }
                else if (short.TryParse(k.ToString(), out short value))
                {
                    if(multiplier == 1)
                    {
                        multiplier = value;
                        continue;
                    }
                    else //already have a multiplier
                    {
                        throw new InvalidOperationException("Multiplier can only be a single digit.");
                    }
                }
                else if(k != '\n' && k != '\r')
                {
                    throw new ArgumentOutOfRangeException("Character Unrecognized.");
                }

                multiplier = 1;
            }

            return result;
        }
    }
}
