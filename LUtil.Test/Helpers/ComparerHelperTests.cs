using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LUtil.Helpers.Extensions.ComparerHelperExtensions;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class ComparerHelperTests {
        [TestMethod]
        public void ToComparison() {
            var comparison = StringComparer.OrdinalIgnoreCase.ToComparison();

            var data = new[] { "a", "D", "B", "c" };
            Array.Sort(data, comparison);
            Assert.AreEqual("a", data[0]);
            Assert.AreEqual("B", data[1]);
            Assert.AreEqual("c", data[2]);
            Assert.AreEqual("D", data[3]);
        }
    }
}
