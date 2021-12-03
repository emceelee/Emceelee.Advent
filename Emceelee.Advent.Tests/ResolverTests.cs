using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
