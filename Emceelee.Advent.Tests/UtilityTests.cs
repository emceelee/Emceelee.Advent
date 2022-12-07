using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Tests
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void Utility_GetPermutations_1234()
        {
            var input = new List<int>() { 1, 2, 3, 4 };

            var result = Utility.GetPermutations(input);

            Assert.AreEqual(24, result.Count());
        }

        [TestMethod]
        public void Utility_GetPermutations_MARS()
        {
            var input = "MARS";

            var result = Utility.GetPermutations(input);

            Assert.AreEqual(24, result.Count());
        }
    }
}
