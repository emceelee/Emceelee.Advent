using Microsoft.VisualStudio.TestTools.UnitTesting;

using Emceelee.Advent.Solutions;

namespace Emceelee.Advent.Tests
{
    [TestClass]
    public class SolutionTests
    {
        [TestMethod]
        public void Solution_00_5_Iteration1()
        {
            var solution = new Solution_00_5();

            var result = solution.Solve(1);

            Assert.AreEqual(2.667, result);
        }

        [TestMethod]
        public void Solution_00_5_Iteration10()
        {
            var solution = new Solution_00_5();

            var result = solution.Solve(5);

            Assert.AreEqual(2.976, result);
        }
    }
}
