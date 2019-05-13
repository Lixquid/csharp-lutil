using System;
using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class ComparableHelperTests {
        private static DateTime DT(int year) => new DateTime(year, 1, 1);

        [TestMethod]
        public void IsBetween() {
            // Numeric
            Assert.IsTrue(5.IsBetween(0, 10));
            Assert.IsFalse((-5).IsBetween(0, 10));
            Assert.IsFalse(15.IsBetween(0, 10));
            // Non-Numeric
            Assert.IsTrue(DT(2000).IsBetween(DT(1999), DT(2001)));
            Assert.IsFalse(DT(2000).IsBetween(DT(2010), DT(2015)));
        }

        [TestMethod]
        public void Clamp() {
            // Numeric
            Assert.AreEqual(5, 5.Clamp(0, 10));
            Assert.AreEqual(0, (-5).Clamp(0, 10));
            Assert.AreEqual(10, 15.Clamp(0, 10));
            // Non-Numeric
            Assert.AreEqual(DT(2010), DT(2010).Clamp(DT(2000), DT(2020)));
            Assert.AreEqual(DT(2000), DT(1999).Clamp(DT(2000), DT(2020)));
            Assert.AreEqual(DT(2020), DT(2030).Clamp(DT(2000), DT(2020)));
        }
    }
}
