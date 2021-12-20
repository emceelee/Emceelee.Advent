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
    }
}
