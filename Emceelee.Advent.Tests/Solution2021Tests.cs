using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

using Emceelee.Advent.Solutions;

namespace Emceelee.Advent.Tests
{
    [TestClass]
    public class Solution2021Tests
    {
        [TestMethod]
        [TestCategory("Solution21_00_5")]
        public void Solution21_00_5_Iteration1()
        {
            var solution = new Solution21_00_5();

            var result = solution.Solve(1);

            Assert.AreEqual(2.667, result);
        }

        [TestMethod]
        [TestCategory("Solution21_00_5")]
        public void Solution21_00_5_Iteration10()
        {
            var solution = new Solution21_00_5();

            var result = solution.Solve(5);

            Assert.AreEqual(2.976, result);
        }

        [TestMethod]
        [TestCategory("Solution21_01")]
        public void Solution21_01_PrimesUpTo30()
        {
            var solution = new Solution21_01();

            var result = solution.Solve(30);
            Assert.AreEqual(129, result);
        }

        [TestMethod]
        [TestCategory("Solution21_03")]
        public void Solution21_03_PalindromePrimesUpTo50()
        {
            var solution = new Solution21_03();

            var result = solution.Solve(50);
            Assert.AreEqual(28, result);
        }

        [TestMethod]
        [TestCategory("Solution21_04")]
        public void Solution21_04_HELLO()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("goto(7);");
            instructions.Add("read(1);");
            instructions.Add("goto(-3);");
            instructions.Add("read(1);");
            instructions.Add("goto(7);");
            instructions.Add("read(1);");
            instructions.Add("read(1);");
            instructions.Add("goto(3);");
            instructions.Add("read(1);");

            var solution = new Solution21_04();

            var result = solution.Solve(memory, instructions);

            Assert.AreEqual("HELLO", result);
        }

        [TestMethod]
        [TestCategory("Solution21_04")]
        [ExpectedException(typeof(ArgumentException))]
        public void Solution21_04_MissingParen()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("goto7");

            var solution = new Solution21_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution21_04")]
        [ExpectedException(typeof(ArgumentException))]
        public void Solution21_04_InvalidAction()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("asdf(7)");

            var solution = new Solution21_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution21_04")]
        [ExpectedException(typeof(ArgumentException))]
        public void Solution21_04_InvalidValue()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("goto(b)");

            var solution = new Solution21_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution21_04")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Solution21_04_OutOfBounds()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("goto(-1)");

            var solution = new Solution21_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution21_04")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Solution21_04_OutOfBoundsRead()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("read(27)");

            var solution = new Solution21_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution21_05")]
        public void Solution21_05_Decryption()
        {
            var encrypted = "TRXMJZJONXHPSSRBX2IXRGAXOJB2VXHRMMVXE MCNOH2N";
            var solution = new Solution21_05();

            var result = solution.Solve(encrypted, "ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789", "2ZEBRAS CDFGHIJKLMNOPQTUVWXY013456789");

            Assert.AreEqual("WE ROBOTS MUGGED AN ELF TODAY MERRY CHRISTMAS", result);
        }

        [TestMethod]
        [TestCategory("Solution21_05")]
        [ExpectedException(typeof(ArgumentException))]
        public void Solution21_05_DifferentAlphabetLengths()
        {
            var encrypted = "ABC";
            var solution = new Solution21_05();

            var result = solution.Solve(encrypted, "ABC", "DCBA");
        }

        [TestMethod]
        [TestCategory("Solution21_05")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Solution21_05_CharacterMissingInAlphabet()
        {
            var encrypted = "D";
            var solution = new Solution21_05();

            var result = solution.Solve(encrypted, "ABC", "CBA");
        }

        [TestMethod]
        [TestCategory("Solution21_06")]
        public void Solution21_06_Over30()
        {
            var solution = new Solution21_06();

            var result = solution.Solve(30);

            Assert.AreEqual(35, result);
        }

        [TestMethod]
        [TestCategory("Solution21_09")]
        public void Solution21_09_wow()
        {
            var text = "408 329 759 49 973 975 969 343 270 127 103";
            var solution = new Solution21_09();

            var result = solution.Solve(text);

            Assert.AreEqual("wow", result);
        }

        [TestMethod]
        [TestCategory("Solution21_10")]
        public void Solution21_10_example()
        {
            var lines = new List<string>()
            {
                "A,AA,..........",
                "AA,AAA,.SE..E....",
                "AAA,AAAA,EEE.ES...S",
                "AAA,AAAB,EE..E..E..",
                "A,AB,.......S..",
                "AB,ABA,.......EEE",
                "ABA,ABAA,E.SS..S...",
                "ABA,ABAB,E...E.S.EE",
                "AB,ABB,....E.E...",
                "ABB,ABBA,.EEEE....E"
            };
            var solution = new Solution21_10();

            var result = solution.Solve(lines);

            Assert.AreEqual(16, result);
        }

        [TestMethod]
        [TestCategory("Solution21_11")]
        public void Solution21_11_First10()
        {
            var solution = new Solution21_11();

            var result = solution.Solve(40);

            Assert.AreEqual("1,2,1,2,1,2,1", result);
        }

        [TestMethod]
        [TestCategory("Solution21_12")]
        public void Solution21_12_TedJones98()
        {
            var solution = new Solution21_12();

            var names = new string[98];
            for(int i = 0; i < names.Length; ++i)
            {
                names[i] = " ";
            }
            names[97] = "Ted Jones";


            var result = solution.Solve(names);

            Assert.AreEqual(59192, result);
        }

        [TestMethod]
        [TestCategory("Solution21_13")]
        public void Solution21_13_Blitzen()
        {
            var solution = new Solution21_13();

            var garbledText = "3Bli[wtz!.9;en";
            var errorSequence = "3,3,7,7,0,10,9".Split(',').Select(num => int.Parse(num));

            var result = solution.Solve(garbledText, errorSequence);

            Assert.AreEqual("Blitzen", result);
        }

        [TestMethod]
        [TestCategory("Solution21_17")]
        public void Solution21_17_3Digits()
        {
            var solution = new Solution21_17();

            var result = solution.Solve(3);

            Assert.AreEqual("14455678767661239941060750283349851372786616456634781515481577509301997444983826731071749118079998628070030493", result);
        }

        [TestMethod]
        [TestCategory("Solution21_17")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Solution21_17_ArgumentOutOfRangeException()
        {
            var solution = new Solution21_17();

            var result = solution.Solve(0);
        }
    }
}
