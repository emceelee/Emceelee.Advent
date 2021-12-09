using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using Emceelee.Advent.Solutions;

namespace Emceelee.Advent.Tests
{
    [TestClass]
    public class SolutionTests
    {
        [TestMethod]
        [TestCategory("Solution_00_5")]
        public void Solution_00_5_Iteration1()
        {
            var solution = new Solution_00_5();

            var result = solution.Solve(1);

            Assert.AreEqual(2.667, result);
        }

        [TestMethod]
        [TestCategory("Solution_00_5")]
        public void Solution_00_5_Iteration10()
        {
            var solution = new Solution_00_5();

            var result = solution.Solve(5);

            Assert.AreEqual(2.976, result);
        }

        [TestMethod]
        [TestCategory("Solution_01")]
        public void Solution_01_PrimesUpTo30()
        {
            var solution = new Solution_01();

            var result = solution.Solve(30);
            Assert.AreEqual(129, result);
        }

        [TestMethod]
        [TestCategory("Solution_03")]
        public void Solution_03_PalindromePrimesUpTo50()
        {
            var solution = new Solution_03();

            var result = solution.Solve(50);
            Assert.AreEqual(28, result);
        }

        [TestMethod]
        [TestCategory("Solution_04")]
        public void Solution_04_HELLO()
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

            var solution = new Solution_04();

            var result = solution.Solve(memory, instructions);

            Assert.AreEqual("HELLO", result);
        }

        [TestMethod]
        [TestCategory("Solution_04")]
        [ExpectedException(typeof(ArgumentException))]
        public void Solution_04_MissingParen()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("goto7");

            var solution = new Solution_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution_04")]
        [ExpectedException(typeof(ArgumentException))]
        public void Solution_04_InvalidAction()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("asdf(7)");

            var solution = new Solution_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution_04")]
        [ExpectedException(typeof(ArgumentException))]
        public void Solution_04_InvalidValue()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("goto(b)");

            var solution = new Solution_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution_04")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Solution_04_OutOfBounds()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("goto(-1)");

            var solution = new Solution_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution_04")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Solution_04_OutOfBoundsRead()
        {
            var memory = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var instructions = new List<string>();
            instructions.Add("read(27)");

            var solution = new Solution_04();

            var result = solution.Solve(memory, instructions);
        }

        [TestMethod]
        [TestCategory("Solution_05")]
        public void Solution_05_Decryption()
        {
            var encrypted = "TRXMJZJONXHPSSRBX2IXRGAXOJB2VXHRMMVXE MCNOH2N";
            var solution = new Solution_05();

            var result = solution.Solve(encrypted, "ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789", "2ZEBRAS CDFGHIJKLMNOPQTUVWXY013456789");

            Assert.AreEqual("WE ROBOTS MUGGED AN ELF TODAY MERRY CHRISTMAS", result);
        }

        [TestMethod]
        [TestCategory("Solution_05")]
        [ExpectedException(typeof(ArgumentException))]
        public void Solution_05_DifferentAlphabetLengths()
        {
            var encrypted = "ABC";
            var solution = new Solution_05();

            var result = solution.Solve(encrypted, "ABC", "DCBA");
        }

        [TestMethod]
        [TestCategory("Solution_05")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Solution_05_CharacterMissingInAlphabet()
        {
            var encrypted = "D";
            var solution = new Solution_05();

            var result = solution.Solve(encrypted, "ABC", "CBA");
        }

        [TestMethod]
        [TestCategory("Solution_06")]
        public void Solution_06_Over30()
        {
            var solution = new Solution_06();

            var result = solution.Solve(30);

            Assert.AreEqual(35, result);
        }

        [TestMethod]
        [TestCategory("Solution_09")]
        public void Solution_09_wow()
        {
            var text = "408 329 759 49 973 975 969 343 270 127 103";
            var solution = new Solution_09();

            var result = solution.Solve(text);

            Assert.AreEqual("wow", result);
        }
    }
}
