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
            //solution = new Solution_06();
            //solution = new Solution_07();
            //solution = new Solution_08();
            //solution = new Solution_09();
            //solution = new Solution_10();
            //solution = new Solution_11();
            solution = new Solution_12();
            solution.Solve();

            Console.ReadLine();
        }
    }
}
