using System;
using Emceelee.Advent.Solutions;

namespace Emceelee.Advent
{
    class Program
    {
        static void Main(string[] args)
        {
            ISolution solution;
            #region 2021
            //solution = new Solution21_00_5();
            //solution = new Solution21_01();
            //solution = new Solution21_03();
            //solution = new Solution21_04();
            //solution = new Solution21_05();
            //solution = new Solution21_06();
            //solution = new Solution21_07();
            //solution = new Solution21_08();
            //solution = new Solution21_09();
            //solution = new Solution21_10();
            //solution = new Solution21_11();
            //solution = new Solution21_12();
            //solution = new Solution21_13();
            //solution = new Solution21_14();
            //solution = new Solution21_15();
            //solution = new Solution21_17();
            //solution = new Solution21_18();
            //solution = new Solution21_19();
            //solution = new Solution21_21();
            #endregion

            #region 2022
            //solution = new Solution22_01();
            //solution = new Solution22_02();
            solution = new Solution22_03();
            #endregion
            solution.Solve();

            Console.ReadLine();
        }
    }
}
