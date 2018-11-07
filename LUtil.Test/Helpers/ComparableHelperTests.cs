using System;
using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class ComparableHelperTests {
        [TestMethod]
        public void IsBetween() {
            // Numeric
            Assert.IsTrue(5.IsBetween(0, 10));
            Assert.IsFalse((-5).IsBetween(0, 10));
            Assert.IsFalse(15.IsBetween(0, 10));
            // Non-Numeric
            Assert.IsTrue(new DateTime(2000, 1, 1).IsBetween(new DateTime(1999, 12, 1), new DateTime(2000, 2, 1)));
            Assert.IsFalse(new DateTime(2000, 1, 1).IsBetween(new DateTime(2010, 1, 1), new DateTime(2011, 1, 1)));
        }
    }
}
