using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_04 : ISolution
    {
        private enum enAction
        {
            GOTO,
            READ,
            INVALID
        }

        public void Solve()
        {
            var memory = Utility.ReadAllText("DataSet\\03_memory.txt");
            var instructions = Utility.ReadLines("DataSet\\03_program.txt");

            Console.WriteLine("Day 04 Solution: " + Solve(memory, instructions));
        }
        
        public string Solve(string memory, IEnumerable<string> instructions)
        {
            var result = new List<char>();
            var currentIndex = 0;

            foreach(var instruction in instructions)
            {
                ParseInstruction(instruction, out enAction action, out int value);

                switch(action)
                {
                    //move index
                    case(enAction.GOTO):
                        currentIndex += value;
                        if (currentIndex < 0 || currentIndex >= memory.Length)
                        {
                            throw new ArgumentOutOfRangeException($"Invalid position {currentIndex}. ");
                        }
                        break;
                    //read value characters
                    case (enAction.READ):
                        for(int i = 0; i < value; ++i)
                        {
                            var indexToRead = currentIndex + i;
                            if (indexToRead >= memory.Length)
                            {
                                throw new ArgumentOutOfRangeException($"Invalid position to read {indexToRead}. ");
                            }
                            result.Add(memory[indexToRead]);
                        }
                        break;
                    case (enAction.INVALID):
                        break;
                }
            }

            return new string(result.ToArray());
        }

        private void ParseInstruction(string instruction, out enAction action, out int value)
        {
            value = 0;
            action = enAction.INVALID;

            var indexOpen = instruction.IndexOf('(');
            var indexClose = instruction.IndexOf(')');
            var valueLength = indexClose - indexOpen - 1;

            if(indexOpen < 0 || indexClose < 0 || valueLength < 1)
            {
                throw new ArgumentException($"Can't parse instruction {instruction}.  ");
            }

            var actionToParse = instruction.Substring(0, indexOpen);
            var valueToParse = instruction.Substring(indexOpen+1, valueLength);

            switch(actionToParse.ToUpper())
            {
                case ("GOTO"):
                    action = enAction.GOTO;
                    break;
                case ("READ"):
                    action = enAction.READ;
                    break;
                default:
                    throw new ArgumentException($"Can't parse action {actionToParse}.  ");
            }

            var success = int.TryParse(valueToParse, out value);
            if(!success)
            {
                throw new ArgumentException($"Can't parse value {valueToParse}.  ");
            }
        }
    }
}
