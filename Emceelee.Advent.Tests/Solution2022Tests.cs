using Emceelee.Advent.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Tests
{
    [TestClass]
    public class Solution2022Tests
    {
        [TestMethod]
        [TestCategory("Solution22_01")]
        public void Solution22_01_10()
        {
            var solution = new Solution22_01();
            var result = solution.Solve(10);

            Assert.AreEqual(15, result);
        }
    }
}
