using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class KeypadCodeResolver
    {
        public const string OnInstruction = "on ";
        public const string RotateColumnInstruction = "rotate column x=";
        public const string RotateRowInstruction = "rotate row y=";

        public bool[,] ResolveKeypadCode(int x, int y, IEnumerable<string> instructions)
        {
            var result = new bool[x,y];

            SetValues(result, result.GetLength(0), result.GetLength(1), false);

            foreach(var instruction in instructions)
            {
                ParseInstruction(result, instruction);
            }

            return result;
        }

        private void ParseInstruction(bool[,] matrix, string instruction)
        {
            var lowerInstruction = instruction.Trim().ToLower();
            if(lowerInstruction.StartsWith(OnInstruction))
            {
                var parameters = lowerInstruction.Replace(OnInstruction, string.Empty).Split("x");
                int x = int.Parse(parameters[0]);
                int y = int.Parse(parameters[1]);

                //set values to true
                SetValues(matrix, x, y, true);
            }
            else if (lowerInstruction.StartsWith(RotateColumnInstruction))
            {
                var parameters = lowerInstruction.Replace(RotateColumnInstruction, string.Empty).Split(" by ");
                int x = int.Parse(parameters[0]);
                int offset = int.Parse(parameters[1]);

                var length = matrix.GetLength(1);
                var original = new bool[length];
                for(int i = 0; i < length; ++i)
                {
                    original[i] = matrix[x, i];
                }

                for (int i = 0; i < length; ++i)
                {
                    var newY = i + offset;
                    if(newY >= length)
                    {
                        newY -= length;
                    }

                    matrix[x, newY] = original[i];
                }
            }
            else if (lowerInstruction.StartsWith(RotateRowInstruction))
            {
                var parameters = lowerInstruction.Replace(RotateRowInstruction, string.Empty).Split(" by ");
                int y = int.Parse(parameters[0]);
                int offset = int.Parse(parameters[1]);

                var length = matrix.GetLength(0);
                var original = new bool[length];
                for (int i = 0; i < length; ++i)
                {
                    original[i] = matrix[i, y];
                }

                for (int i = 0; i < length; ++i)
                {
                    var newX = i + offset;
                    if (newX >= length)
                    {
                        newX -= length;
                    }

                    matrix[newX, y] = original[i];
                }
            }
        }

        private void SetValues<T>(T[,] matrix, int x, int y, T value)
        {
            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    matrix[i, j] = value;
                }
            }
        }
    }
}
