﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Tests
{
    [TestClass]
    public class ResolverTests
    {
        #region PrimeResolver
        [TestMethod]
        [TestCategory("PrimeResolver")]
        public void PrimeResolver_ResolvePrimes()
        {
            var resolver = new PrimeResolver();

            var result = resolver.ResolvePrimes(10);

            Assert.AreEqual(0, result.Count(x => x == 1));
            Assert.AreEqual(1, result.Count(x => x == 2));
            Assert.AreEqual(1, result.Count(x => x == 3));
            Assert.AreEqual(0, result.Count(x => x == 4));
            Assert.AreEqual(1, result.Count(x => x == 5));
            Assert.AreEqual(0, result.Count(x => x == 6));
            Assert.AreEqual(1, result.Count(x => x == 7));
            Assert.AreEqual(0, result.Count(x => x == 8));
            Assert.AreEqual(0, result.Count(x => x == 9));
            Assert.AreEqual(0, result.Count(x => x == 10));
        }

        [TestMethod]
        [TestCategory("PrimeResolver")]
        public void PrimeResolver_ResolvePrimes_Twice()
        {
            var resolver = new PrimeResolver();

            var result = resolver.ResolvePrimes(5);

            Assert.AreEqual(0, result.Count(x => x == 1));
            Assert.AreEqual(1, result.Count(x => x == 2));
            Assert.AreEqual(1, result.Count(x => x == 3));
            Assert.AreEqual(0, result.Count(x => x == 4));
            Assert.AreEqual(1, result.Count(x => x == 5));

            result = resolver.ResolvePrimes(10);

            Assert.AreEqual(0, result.Count(x => x == 1));
            Assert.AreEqual(1, result.Count(x => x == 2));
            Assert.AreEqual(1, result.Count(x => x == 3));
            Assert.AreEqual(0, result.Count(x => x == 4));
            Assert.AreEqual(1, result.Count(x => x == 5));
            Assert.AreEqual(0, result.Count(x => x == 6));
            Assert.AreEqual(1, result.Count(x => x == 7));
            Assert.AreEqual(0, result.Count(x => x == 8));
            Assert.AreEqual(0, result.Count(x => x == 9));
            Assert.AreEqual(0, result.Count(x => x == 10));
        }
        #endregion

        #region PalindromeResolver
        [TestMethod]
        [TestCategory("PalindromeResolver")]
        public void PalindromeResolver_IsPalindrome_Odd_True()
        {
            var resolver = new PalindromeResolver();
            var possiblePalindrome = 12321;

            var result = resolver.IsPalindrome(possiblePalindrome);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("PalindromeResolver")]
        public void PalindromeResolver_IsPalindrome_Odd_False()
        {
            var resolver = new PalindromeResolver();
            var possiblePalindrome = 12345;

            var result = resolver.IsPalindrome(possiblePalindrome);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("PalindromeResolver")]
        public void PalindromeResolver_IsPalindrome_Even_True()
        {
            var resolver = new PalindromeResolver();
            var possiblePalindrome = 1221;

            var result = resolver.IsPalindrome(possiblePalindrome);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("PalindromeResolver")]
        public void PalindromeResolver_IsPalindrome_Even_False()
        {
            var resolver = new PalindromeResolver();
            var possiblePalindrome = 1234;

            var result = resolver.IsPalindrome(possiblePalindrome);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("PalindromeResolver")]
        public void PalindromeResolver_ResolvePalindromes()
        {
            var resolver = new PalindromeResolver();
            var possiblePalindromes = new List<int>() { 3, 1234, 1001, 54321, 2002 };

            var result = resolver.ResolvePalindromes(possiblePalindromes);

            Assert.AreEqual(1, result.Count(x => x == 3));
            Assert.AreEqual(0, result.Count(x => x == 1234));
            Assert.AreEqual(1, result.Count(x => x == 1001));
            Assert.AreEqual(0, result.Count(x => x == 54321));
            Assert.AreEqual(1, result.Count(x => x == 2002));
        }
        #endregion

        #region CiphertextResolver
        [TestMethod]
        [TestCategory("CiphertextResolver")]
        public void CiphertextResolver_ResolveCiphertext()
        {
            var resolver = new CiphertextResolver();

            var result = resolver.ResolveCiphertextAlphabet("2ZEBRAS");

            Assert.AreEqual("2ZEBRAS CDFGHIJKLMNOPQTUVWXY013456789", result);
        }
        #endregion

        #region PascalsTriangleResolver
        [TestMethod]
        [TestCategory("PascalsTriangleResolver")]
        public void PascalsTriangleResolver_ResolveNextRow()
        {
            var resolver = new PascalsTriangleResolver();
            var prevRow = new long[] { 1, 6, 15, 20, 15, 6, 1 }; //7 elements
            var triangle = new List<long[]>() { prevRow };

            resolver.ResolveNextRow(triangle);

            var currentRow = triangle.LastOrDefault();

            Assert.AreEqual(8, currentRow.Length);
            Assert.AreEqual(1, currentRow[0]);
            Assert.AreEqual(7, currentRow[1]);
            Assert.AreEqual(21, currentRow[2]);
            Assert.AreEqual(35, currentRow[3]);
            Assert.AreEqual(35, currentRow[4]);
            Assert.AreEqual(21, currentRow[5]);
            Assert.AreEqual(7, currentRow[6]);
            Assert.AreEqual(1, currentRow[7]);
        }

        [TestMethod]
        [TestCategory("PascalsTriangleResolver")]
        public void PascalsTriangleResolver_ResolveNextRow_EmptyTriangle()
        {
            var resolver = new PascalsTriangleResolver();
            var triangle = new List<long[]>();

            resolver.ResolveNextRow(triangle);

            var currentRow = triangle.LastOrDefault();

            Assert.AreEqual(1, currentRow.Length);
            Assert.AreEqual(1, currentRow[0]);
        }

        [TestMethod]
        [TestCategory("PascalsTriangleResolver")]
        public void PascalsTriangleResolver_ResolveNextRow_EmptyLastRow()
        {
            var resolver = new PascalsTriangleResolver();
            var prevRow = new long[0]; //7 elements
            var triangle = new List<long[]>() { prevRow };

            resolver.ResolveNextRow(triangle);

            var currentRow = triangle.LastOrDefault();

            Assert.AreEqual(1, currentRow.Length);
            Assert.AreEqual(1, currentRow[0]);
        }

        [TestMethod]
        [TestCategory("PascalsTriangleResolver")]
        public void PascalsTriangleResolver_ResolveNextRow_NullLastRow()
        {
            var resolver = new PascalsTriangleResolver();
            var triangle = new List<long[]>() { null };

            resolver.ResolveNextRow(triangle);

            var currentRow = triangle.LastOrDefault();

            Assert.AreEqual(1, currentRow.Length);
            Assert.AreEqual(1, currentRow[0]);
        }

        [TestMethod]
        [TestCategory("PascalsTriangleResolver")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PascalsTriangleResolver_ResolveNextRow_NullInput()
        {
            var resolver = new PascalsTriangleResolver();

            resolver.ResolveNextRow(null);
        }
        #endregion

        #region SetCountResolver
        [TestMethod]
        [TestCategory("SetCountResolver")]
        public void SetCountResolver_ResolveSetCounts_ExampleTriplets()
        {
            string text = Utility.ReadAllText("Examples\\07_example.txt");
            var resolver = new SetCountResolver();

            var result = resolver.ResolveSetCounts(text, 3);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [TestCategory("SetCountResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetCountResolver_ResolveSetCounts_ArgumentOutOfRangeException()
        {
            string text = Utility.ReadAllText("Examples\\07_example.txt");
            var resolver = new SetCountResolver();

            var result = resolver.ResolveSetCounts(text, 0);
        }
        #endregion

        #region CollisionResolver
        [TestMethod]
        [TestCategory("CollisionResolver")]
        public void CollisionResolver_ResolveCollisions_Example()
        {
            var lines = Utility.ReadLines("Examples\\08_example.txt");
            var resolver = new CollisionResolver();

            var result = resolver.ResolveCollisions(lines, 3, 1);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [TestCategory("CollisionResolver")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollisionResolver_ResolveCollisions_NullLines()
        {
            List<string> lines = null;
            var resolver = new CollisionResolver();

            var result = resolver.ResolveCollisions(lines, 3, 1);
        }

        [TestMethod]
        [TestCategory("CollisionResolver")]
        [ExpectedException(typeof(ArgumentException))]
        public void CollisionResolver_ResolveCollisions_ZeroLines()
        {
            var lines = Enumerable.Empty<string>();
            var resolver = new CollisionResolver();

            var result = resolver.ResolveCollisions(lines, 3, 1);
        }

        [TestMethod]
        [TestCategory("CollisionResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CollisionResolver_ResolveCollisions_InvalidRight()
        {
            var lines = new List<string>() { ".#" };
            var resolver = new CollisionResolver();

            var result = resolver.ResolveCollisions(lines, -1, 1);
        }

        [TestMethod]
        [TestCategory("CollisionResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CollisionResolver_ResolveCollisions_InvalidDown()
        {
            var lines = new List<string>() { ".#" };
            var resolver = new CollisionResolver();

            var result = resolver.ResolveCollisions(lines, 1, 0);
        }

        [TestMethod]
        [TestCategory("CollisionResolver")]
        [ExpectedException(typeof(ArgumentException))]
        public void CollisionResolver_ResolveCollisions_InvalidLineLengths()
        {
            var lines = new List<string>() { ".#", ".#." };
            var resolver = new CollisionResolver();

            var result = resolver.ResolveCollisions(lines, 1, 1);
        }
        #endregion


        #region SquaresResolver
        [TestMethod]
        [TestCategory("SquaresResolver")]
        public void SquaresResolver_ResolveSquares_100()
        {
            var resolver = new SquaresResolver();

            var result = resolver.ResolveSquares(100);

            Assert.IsTrue(result.Contains(0));
            Assert.IsTrue(result.Contains(1));
            Assert.IsTrue(result.Contains(4));
            Assert.IsTrue(result.Contains(9));
            Assert.IsTrue(result.Contains(16));
            Assert.IsTrue(result.Contains(25));
            Assert.IsTrue(result.Contains(36));
            Assert.IsTrue(result.Contains(49));
            Assert.IsTrue(result.Contains(64));
            Assert.IsTrue(result.Contains(81));
            Assert.IsTrue(result.Contains(100));
        }

        [TestMethod]
        [TestCategory("SquaresResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SquaresResolver_ResolveSquares_Exception()
        {
            var resolver = new SquaresResolver();

            var result = resolver.ResolveSquares(-1);
        }
        #endregion

        #region CubesResolver
        [TestMethod]
        [TestCategory("CubesResolver")]
        public void CubesResolver_ResolveCubes_100()
        {
            var resolver = new CubesResolver();

            var result = resolver.ResolveCubes(100);

            Assert.IsTrue(result.Contains(0));
            Assert.IsTrue(result.Contains(1));
            Assert.IsTrue(result.Contains(8));
            Assert.IsTrue(result.Contains(27));
            Assert.IsTrue(result.Contains(64));
        }

        [TestMethod]
        [TestCategory("CubesResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CubesResolver_ResolveCubes_Exception()
        {
            var resolver = new CubesResolver();

            var result = resolver.ResolveCubes(-1);
        }
        #endregion
    }
}
