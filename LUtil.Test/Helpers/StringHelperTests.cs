using System;
using LUtil.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class StringHelperTests {
        [TestMethod]
        public void Contains() {
            Assert.IsTrue(StringHelper.Contains("hello", "ll", StringComparison.Ordinal));
            Assert.IsFalse(StringHelper.Contains("hello", "LL", StringComparison.Ordinal));
            Assert.IsTrue(StringHelper.Contains("hello", "LL", StringComparison.OrdinalIgnoreCase));
        }
    }
}
