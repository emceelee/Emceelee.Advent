using System;
using Emceelee.Advent.Solutions;

namespace Emceelee.Advent
{
    class Program
    {
        static void Main(string[] args)
        {
            ISolution solution;
            //solution = new Solution_00_5();
            //solution = new Solution_01();
            //solution = new Solution_03();
            //solution = new Solution_04();
            //solution = new Solution_05();
            solution = new Solution_06();
            solution.Solve();

            Console.ReadLine();
        }
    }
}
