using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_05 : ISolution
    {
        public void Solve()
        {
            var instructions = Utility.ReadAllText(@"DataSet\2022\05_codes.txt");
            Console.WriteLine("Day 05 Solution: " + Solve(instructions));
        }

        public int Solve(string instructions)
        {
            var resolver = new ElevatorFloorResolver();
            var result = resolver.ResolveFloor(instructions);
            return result;
        }
    }
}
