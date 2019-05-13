using System;
using LUtil.Helpers;
using LUtil.Helpers.Extensions;
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

        [TestMethod]
        public void Repeat() {
            Assert.AreEqual("hello", "hello".Repeat(1));
            Assert.AreEqual("hellohello", "hello".Repeat(2));
        }
    }
}
