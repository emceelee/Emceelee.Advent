using System;
using Emceelee.Advent.Solutions;

namespace Emceelee.Advent
{
    class Program
    {
        static void Main(string[] args)
        {
            ISolution solution = new Solution_00_5();
            solution.Solve();

            Console.ReadLine();
        }
    }
}
