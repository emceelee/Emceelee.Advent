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
        /*
        [TestMethod]
        [TestCategory("SetCountResolver")]
        public void SetCountResolver_ResolveSetCounts_ExampleTriplets()
        {
            string text = Utility.ReadAllText("Examples\\07_example.txt");
            var resolver = new SetCountResolver();

            var result = resolver.ResolveSetCounts(text, 3);

            Assert.AreEqual(4, result);
        }
        */

        [TestMethod]
        [TestCategory("SetCountResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetCountResolver_ResolveSetCounts_ArgumentOutOfRangeException()
        {
            var resolver = new SetCountResolver();

            var result = resolver.ResolveSetCounts("text", 0);
        }
        #endregion

        #region CollisionResolver
        /*
        [TestMethod]
        [TestCategory("CollisionResolver")]
        public void CollisionResolver_ResolveCollisions_Example()
        {
            var lines = Utility.ReadLines("Examples\\08_example.txt");
            var resolver = new CollisionResolver();

            var result = resolver.ResolveCollisions(lines, 3, 1);

            Assert.AreEqual(4, result);
        }
        */

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

        #region TrolleyPathNodeTreeResolver
        [TestMethod]
        [TestCategory("TrolleyPathNodeTreeResolver")]
        public void TrolleyPath_Value()
        {
            var path = new TrolleyPath("start", "end", "EEES....");

            Assert.AreEqual(10, path.Value);
        }

        [TestMethod]
        [TestCategory("TrolleyPathNodeTreeResolver")]
        public void TrolleyPath_NullObstacles()
        {
            var path = new TrolleyPath("start", "end");

            Assert.AreEqual(0, path.Value);
        }

        [TestMethod]
        [TestCategory("TrolleyPathNodeTreeResolver")]
        public void TrolleyPathNode_Constructor()
        {
            var parentPath = new TrolleyPath("start", "start");
            var rootNode = new TrolleyPathNode(null, parentPath);

            Assert.IsNull(rootNode.Parent);
            Assert.AreEqual(parentPath.End, rootNode.NodeName);
            Assert.AreEqual(parentPath.Value, rootNode.NodeValue);
            Assert.AreEqual(parentPath.Value, rootNode.PathToNodeValue);

            var path1 = new TrolleyPath("start", "mid", "S"); //value 1
            var midNode = new TrolleyPathNode(rootNode, path1);

            Assert.AreSame(rootNode, midNode.Parent);
            Assert.AreEqual(path1.End, midNode.NodeName);
            Assert.AreEqual(path1.Value, midNode.NodeValue);
            Assert.AreEqual(path1.Value, midNode.PathToNodeValue);

            var path2 = new TrolleyPath("mid", "end", "E"); //value 3
            var endNode = new TrolleyPathNode(midNode, path2);

            Assert.AreSame(midNode, endNode.Parent);
            Assert.AreEqual(path2.End, endNode.NodeName);
            Assert.AreEqual(path2.Value, endNode.NodeValue);
            Assert.AreEqual(path1.Value + path2.Value, endNode.PathToNodeValue);
        }

        [TestMethod]
        [TestCategory("TrolleyPathNodeTreeResolver")]
        public void TrolleyPathNodeTreeResolver_ResolveTrolleyPathNodeTree()
        {
            var path1 = new TrolleyPath("start", "mid", "S"); //value 1
            var path2 = new TrolleyPath("mid", "end", "E"); //value 3
            var paths = new List<TrolleyPath>() { path1, path2 };

            var resolver = new TrolleyPathNodeTreeResolver();

            var rootNode = resolver.ResolveTrolleyPathNodeTree(paths);
            var midNode = rootNode["mid"];
            var endNode = midNode["end"];

            Assert.IsNull(rootNode.Parent);
            Assert.AreEqual("start", rootNode.NodeName);
            Assert.AreEqual(0, rootNode.NodeValue);
            Assert.AreEqual(0, rootNode.PathToNodeValue);

            Assert.AreSame(rootNode, midNode.Parent);
            Assert.AreEqual(path1.End, midNode.NodeName);
            Assert.AreEqual(path1.Value, midNode.NodeValue);
            Assert.AreEqual(path1.Value, midNode.PathToNodeValue);

            Assert.AreSame(midNode, endNode.Parent);
            Assert.AreEqual(path2.End, endNode.NodeName);
            Assert.AreEqual(path2.Value, endNode.NodeValue);
            Assert.AreEqual(path1.Value + path2.Value, endNode.PathToNodeValue);
        }

        [TestMethod]
        [TestCategory("TrolleyPathNodeTreeResolver")]
        [ExpectedException(typeof(ArgumentException))]
        public void TrolleyPathNodeTreeResolver_NoRootNode()
        {
            //circular paths
            var path1 = new TrolleyPath("start", "end", "S");
            var path2 = new TrolleyPath("end", "start", "E");
            var paths = new List<TrolleyPath>() { path1, path2 };

            var resolver = new TrolleyPathNodeTreeResolver();

            var rootNode = resolver.ResolveTrolleyPathNodeTree(paths);
        }

        [TestMethod]
        [TestCategory("TrolleyPathNodeTreeResolver")]
        [ExpectedException(typeof(ArgumentException))]
        public void TrolleyPathNodeTreeResolver_MultipleRootNode()
        {
            //two starts
            var path1 = new TrolleyPath("start1", "end1", "S");
            var path2 = new TrolleyPath("start2", "end2", "S");
            var paths = new List<TrolleyPath>() { path1, path2 };

            var resolver = new TrolleyPathNodeTreeResolver();

            var rootNode = resolver.ResolveTrolleyPathNodeTree(paths);
        }

        [TestMethod]
        [TestCategory("TrolleyPathNodeTreeResolver")]
        [ExpectedException(typeof(ArgumentException))]
        public void TrolleyPathNodeTreeResolver_RemainingPaths()
        {
            //remaining path same as multiple starts
            var path1 = new TrolleyPath("start", "mid", "S");
            var path2 = new TrolleyPath("mid", "end", "E");
            var path3 = new TrolleyPath("nowhere1", "nowhere2", "S"); //remaining path should be caught by multiple root nodes
            var paths = new List<TrolleyPath>() { path1, path2, path3 };

            var resolver = new TrolleyPathNodeTreeResolver();

            var rootNode = resolver.ResolveTrolleyPathNodeTree(paths);
        }

        [TestMethod]
        [TestCategory("TrolleyPathNodeTreeResolver")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TrolleyPathNodeTreeResolver_DuplicatePath()
        {
            var path1 = new TrolleyPath("start", "mid", "S");
            var path2a = new TrolleyPath("mid", "end", "E");
            var path2b = new TrolleyPath("mid", "end", "E"); //duplicate of path2a
            var paths = new List<TrolleyPath>() { path1, path2a, path2b };

            var resolver = new TrolleyPathNodeTreeResolver();

            var rootNode = resolver.ResolveTrolleyPathNodeTree(paths);
        }
        #endregion

        #region FiboResolver

        [TestMethod]
        [TestCategory("FiboResolver")]
        public void FiboResolver_ResolveFibo()
        {
            var resolver = new FiboResolver();

            var result = resolver.ResolveFibo(5);

            Assert.AreEqual(3, result);

            result = resolver.ResolveFibo(20);

            Assert.AreEqual(4181, result);
        }

        [TestMethod]
        [TestCategory("FiboResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FiboResolver_Zero()
        {
            var resolver = new FiboResolver();

            var result = resolver.ResolveFibo(0);
        }
        #endregion

        #region NodeNetworkResolver
        [TestMethod]
        [TestCategory("NodeNetworkResolver")]
        public void NodeNetworkResolver_ResolveMinimumPathValue_Example()
        {
            var resolver = new NodeNetworkResolver();
            resolver.AddNode("NARNIA");
            resolver.AddNode("CALGARY");
            resolver.AddNode("DENVER");
            resolver.AddNode("HOUSTON");
            resolver.AddPath("NARNIA", "CALGARY", 31);
            resolver.AddPath("CALGARY", "DENVER", 27);
            resolver.AddPath("DENVER", "HOUSTON", 23);
            resolver.AddPath("CALGARY", "HOUSTON", 50);

            resolver.CacheMinPathValues("HOUSTON");
            var result = resolver.ResolveMinimumPathValue("NARNIA", "HOUSTON", out IEnumerable<NetworkPath> minValuePath);

            Assert.AreEqual(81, result.Value);
        }
        #endregion

        #region PermutationResolver
        [TestMethod]
        [TestCategory("PermutationResolver")]
        public void PermutationResolver_ResolvePermutations_Example()
        {
            var resolver = new PermutationResolver();
            var result = resolver.ResolvePermutations("01234").ToList();

            Assert.AreEqual(120, result.Count);
            Assert.AreEqual("01234", result[0]);
            Assert.AreEqual("01243", result[1]);
            Assert.AreEqual("01324", result[2]);
            Assert.AreEqual("01342", result[3]);
            Assert.AreEqual("01423", result[4]);

        }
        #endregion

        #region OddsResolver
        [TestMethod]
        [TestCategory("OddsResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OddsResolver_ResolveOdds_ArgumentOutOfRange()
        {
            var resolver = new OddsResolver();
            resolver.ResolveOdds(0);
        }

        [TestMethod]
        [TestCategory("OddsResolver")]
        public void OddsResolver_ResolveOdds_Odds()
        {
            var resolver = new OddsResolver();
            var result = resolver.ResolveOdds(5);

            Assert.IsTrue(result.Contains(1));
            Assert.IsTrue(!result.Contains(2));
            Assert.IsTrue(result.Contains(3));
            Assert.IsTrue(!result.Contains(4));
            Assert.IsTrue(result.Contains(5));
        }
        #endregion

        #region EvensResolver
        [TestMethod]
        [TestCategory("EvensResolver")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EvensResolver_ResolveEvens_ArgumentOutOfRange()
        {
            var resolver = new EvensResolver();
            resolver.ResolveEvens(0);
        }

        [TestMethod]
        [TestCategory("OddsResolver")]
        public void EvensResolver_ResolveEvens_Evens()
        {
            var resolver = new EvensResolver();
            var result = resolver.ResolveEvens(5);

            Assert.IsTrue(!result.Contains(1));
            Assert.IsTrue(result.Contains(2));
            Assert.IsTrue(!result.Contains(3));
            Assert.IsTrue(result.Contains(4));
            Assert.IsTrue(!result.Contains(5));
        }
        #endregion

        #region ElevatorFloorResolver
        [TestMethod]
        [TestCategory("ElevatorFloorResolver")]
        public void ElevatorFloorResolver_ResolveFloor_2_1()
        {
            var resolver = new ElevatorFloorResolver();
            var result = resolver.ResolveFloor(ElevatorFloorResolver.ExampleInstruction2_1);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [TestCategory("ElevatorFloorResolver")]
        public void ElevatorFloorResolver_ResolveFloor_2_2()
        {
            var resolver = new ElevatorFloorResolver();
            var result = resolver.ResolveFloor(ElevatorFloorResolver.ExampleInstruction2_2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [TestCategory("ElevatorFloorResolver")]
        public void ElevatorFloorResolver_ResolveFloor_0_1()
        {
            var resolver = new ElevatorFloorResolver();
            var result = resolver.ResolveFloor(ElevatorFloorResolver.ExampleInstruction0_1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("ElevatorFloorResolver")]
        public void ElevatorFloorResolver_ResolveFloor_0_2()
        {
            var resolver = new ElevatorFloorResolver();
            var result = resolver.ResolveFloor(ElevatorFloorResolver.ExampleInstruction0_2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("ElevatorFloorResolver")]
        public void ElevatorFloorResolver_ResolveFloor_0_3()
        {
            var resolver = new ElevatorFloorResolver();
            var result = resolver.ResolveFloor(ElevatorFloorResolver.ExampleInstruction0_3);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("ElevatorFloorResolver")]
        public void ElevatorFloorResolver_ResolveFloor_1_1()
        {
            var resolver = new ElevatorFloorResolver();
            var result = resolver.ResolveFloor(ElevatorFloorResolver.ExampleInstruction1_1);

            Assert.AreEqual(1, result);
        }
        #endregion

        #region MartianResolver
        [TestMethod]
        [TestCategory("MartianResolver")]
        public void MartianResolver_IsMartian_Mark_Phillips()
        {
            var resolver = new MartianResolver();
            var name = "Mark Phillips";

            var result = resolver.IsMartian(name);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("MartianResolver")]
        public void MartianResolver_IsMartian_Jason_Marshall()
        {
            var resolver = new MartianResolver();
            var name = "Jason Marshall";

            var result = resolver.IsMartian(name);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("MartianResolver")]
        public void MartianResolver_IsMartian_Elon_Musk()
        {
            var resolver = new MartianResolver();
            var name = "Elon Musk";

            var result = resolver.IsMartian(name);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("MartianResolver")]
        public void MartianResolver_ResolveMartians_MARS_Permutations()
        {
            var resolver = new MartianResolver();
            var name = "MARS";
            var names = Utility.GetPermutations(name);

            var result = resolver.ResolveMartians(names);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(name, result.First());
        }
        #endregion

        #region PassphraseResolver
        [TestMethod]
        [TestCategory("PassphraseResolver")]
        public void PassphraseResolver_IsValidPassphrase_Short()
        {
            var resolver = new PassphraseResolver();
            var passphrase = "santa";

            var result = resolver.IsValidPassphrase(passphrase);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("PassphraseResolver")]
        public void PassphraseResolver_IsValidPassphrase_Valid1()
        {
            var resolver = new PassphraseResolver();
            var passphrase = "santa rudolf cupid";

            var result = resolver.IsValidPassphrase(passphrase);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("PassphraseResolver")]
        public void PassphraseResolver_IsValidPassphrase_Duplicated()
        {
            var resolver = new PassphraseResolver();
            var passphrase = "santa rudolf santa cupid";

            var result = resolver.IsValidPassphrase(passphrase);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("PassphraseResolver")]
        public void PassphraseResolver_IsValidPassphrase_InvalidChars()
        {
            var resolver = new PassphraseResolver();
            var passphrase = "santa spending some$$$";

            var result = resolver.IsValidPassphrase(passphrase);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("PassphraseResolver")]
        public void PassphraseResolver_IsValidPassphrase_Valid2()
        {
            var resolver = new PassphraseResolver();
            var passphrase = "cupid rudolf cupids";

            var result = resolver.IsValidPassphrase(passphrase);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("PassphraseResolver")]
        public void PassphraseResolver_IsValidPassphrase_Long()
        {
            var resolver = new PassphraseResolver();
            var passphrase = "dasher dancer prancer vixen comet cupid donner blitzen rudolph";

            var result = resolver.IsValidPassphrase(passphrase);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("PassphraseResolver")]
        public void PassphraseResolver_ResolveValidPassphrases()
        {
            var resolver = new PassphraseResolver();
            var passphrase1 = "santa rudolf cupid";
            var passphrase2 = "cupid rudolf cupids";
            var passphrase3 = "dasher dancer prancer vixen comet cupid donner blitzen rudolph";

            var passphrases = new List<string>() { passphrase1, passphrase2, passphrase3 };

            var result = resolver.ResolveValidPassphrases(passphrases);
            var list = result.ToList();

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(passphrase1, list[0]);
            Assert.AreEqual(passphrase2, list[1]);
        }
        #endregion

        #region KeypadCodeResolver
        [TestMethod]
        [TestCategory("KeypadCodeResolver")]
        public void KeypadCodeResolver_ResolveKeypadCode()
        {
            var resolver = new KeypadCodeResolver();
            var instruction1 = "on 3x2";
            var instruction2 = "rotate column x=2 by 1";
            var instruction3 = " rotate row y=0 by 6";

            var x = 7;
            var y = 3;

            var instructions = new List<string>() { instruction1, instruction2, instruction3 };

            var result = resolver.ResolveKeypadCode(x, y, instructions);

            var expected = new bool[7, 3]
            {
                { true, true, false },
                { false, true, false },
                { false, true, true },
                { false, false, false },
                { false, false, false },
                { false, false, false },
                { true, false, false },
            };

            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    Assert.AreEqual(expected[i, j], result[i, j]);
                }
            }
        }
        #endregion

        #region RobotGameResolver
        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetNext_1()
        {
            var resolver = new RobotGameResolver();
            var result = resolver.GetNext("1");

            Assert.AreEqual("11", result);
        }

        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetNext_11()
        {
            var resolver = new RobotGameResolver();
            var result = resolver.GetNext("11");

            Assert.AreEqual("21", result);
        }

        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetNext_21()
        {
            var resolver = new RobotGameResolver();
            var result = resolver.GetNext("21");

            Assert.AreEqual("1211", result);
        }

        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetNext_1211()
        {
            var resolver = new RobotGameResolver();
            var result = resolver.GetNext("1211");

            Assert.AreEqual("111221", result);
        }

        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetNext_111221()
        {
            var resolver = new RobotGameResolver();
            var result = resolver.GetNext("111221");

            Assert.AreEqual("312211", result);
        }

        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetSeconds_1Round()
        {
            var resolver = new RobotGameResolver();
            var seconds = resolver.ResolveSeconds(1, out string result);

            Assert.AreEqual(2, seconds);
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetSeconds_2Rounds()
        {
            var resolver = new RobotGameResolver();
            var seconds = resolver.ResolveSeconds(2, out string result);

            Assert.AreEqual(11, seconds);
            Assert.AreEqual("11", result);
        }

        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetSeconds_3Rounds()
        {
            var resolver = new RobotGameResolver();
            var seconds = resolver.ResolveSeconds(3, out string result);

            Assert.AreEqual(20, seconds);
            Assert.AreEqual("21", result);
        }

        [TestMethod]
        [TestCategory("RobotGameResolver")]
        public void RobotGameResolver_GetSeconds_4Rounds()
        {
            var resolver = new RobotGameResolver();
            var seconds = resolver.ResolveSeconds(4, out string result);

            Assert.AreEqual(33, seconds);
            Assert.AreEqual("1211", result);
        }
        #endregion

        #region BinarySpacePartitionResolver
        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_FBFBBFF()
        {
            var resolver = new BinarySpacePartitionResolver('F', 'B');
            var result = resolver.ResolveIndex("FBFBBFF");

            Assert.AreEqual(44, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_FFFBBFF()
        {
            var resolver = new BinarySpacePartitionResolver('F', 'B');
            var result = resolver.ResolveIndex("FFFBBFF");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_FBBFFBF()
        {
            var resolver = new BinarySpacePartitionResolver('F', 'B');
            var result = resolver.ResolveIndex("FBBFFBF");

            Assert.AreEqual(50, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_BBFFBBF()
        {
            var resolver = new BinarySpacePartitionResolver('F', 'B');
            var result = resolver.ResolveIndex("BBFFBBF");

            Assert.AreEqual(102, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_BFFBBFB()
        {
            var resolver = new BinarySpacePartitionResolver('F', 'B');
            var result = resolver.ResolveIndex("BFFBBFB");

            Assert.AreEqual(77, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_RLR()
        {
            var resolver = new BinarySpacePartitionResolver('L', 'R');
            var result = resolver.ResolveIndex("RLR");

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_LLL()
        {
            var resolver = new BinarySpacePartitionResolver('L', 'R');
            var result = resolver.ResolveIndex("LLL");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_RRR()
        {
            var resolver = new BinarySpacePartitionResolver('L', 'R');
            var result = resolver.ResolveIndex("RRR");

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_RLL()
        {
            var resolver = new BinarySpacePartitionResolver('L', 'R');
            var result = resolver.ResolveIndex("RLL");

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [TestCategory("BinarySpacePartitionResolver")]
        public void BinarySpacePartitionResolver_ResolveIndex_LRR()
        {
            var resolver = new BinarySpacePartitionResolver('L', 'R');
            var result = resolver.ResolveIndex("LRR");

            Assert.AreEqual(3, result);
        }
        #endregion
    }
}