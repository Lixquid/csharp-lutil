using System;
using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LUtil.Helpers.ComparableHelper;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class ComparableHelperTests {
        [TestMethod]
        public void IsBetween_Inclusivity() {
            // Base
            Assert.IsTrue(5.IsBetween(0, 10));
            Assert.IsFalse((-5).IsBetween(0, 10));
            Assert.IsFalse(15.IsBetween(0, 10));
            // Inclusivity
            Assert.IsTrue(0.IsBetween(0, 10, IsBetweenInclusivity.Inclusive));
            Assert.IsFalse(0.IsBetween(0, 10, IsBetweenInclusivity.Exclusive));
            Assert.IsTrue(0.IsBetween(0, 10, IsBetweenInclusivity.MinInclusiveMaxExclusive));
            Assert.IsFalse(0.IsBetween(0, 10, IsBetweenInclusivity.MinExclusiveMaxInclusive));

            Assert.IsTrue(5.IsBetween(0, 10, IsBetweenInclusivity.Inclusive));
            Assert.IsTrue(5.IsBetween(0, 10, IsBetweenInclusivity.Exclusive));
            Assert.IsTrue(5.IsBetween(0, 10, IsBetweenInclusivity.MinExclusiveMaxInclusive));
            Assert.IsTrue(5.IsBetween(0, 10, IsBetweenInclusivity.MinInclusiveMaxExclusive));

            Assert.IsTrue(10.IsBetween(0, 10, IsBetweenInclusivity.Inclusive));
            Assert.IsFalse(10.IsBetween(0, 10, IsBetweenInclusivity.Exclusive));
            Assert.IsTrue(10.IsBetween(0, 10, IsBetweenInclusivity.MinExclusiveMaxInclusive));
            Assert.IsFalse(10.IsBetween(0, 10, IsBetweenInclusivity.MinInclusiveMaxExclusive));

            Assert.IsFalse((-5).IsBetween(0, 10, IsBetweenInclusivity.Inclusive));
            Assert.IsFalse((-5).IsBetween(0, 10, IsBetweenInclusivity.Exclusive));
            Assert.IsFalse((-5).IsBetween(0, 10, IsBetweenInclusivity.MinExclusiveMaxInclusive));
            Assert.IsFalse((-5).IsBetween(0, 10, IsBetweenInclusivity.MinInclusiveMaxExclusive));

            Assert.IsFalse(15.IsBetween(0, 10, IsBetweenInclusivity.Inclusive));
            Assert.IsFalse(15.IsBetween(0, 10, IsBetweenInclusivity.Exclusive));
            Assert.IsFalse(15.IsBetween(0, 10, IsBetweenInclusivity.MinExclusiveMaxInclusive));
            Assert.IsFalse(15.IsBetween(0, 10, IsBetweenInclusivity.MinInclusiveMaxExclusive));
        }

        [TestMethod]
        public void IsBetween_NonNumeric() {
            Assert.IsTrue(new DateTime(2000, 1, 1).IsBetween(new DateTime(1999, 12, 1), new DateTime(2000, 2, 1)));
            Assert.IsFalse(new DateTime(2000, 1, 1).IsBetween(new DateTime(2010, 1, 1), new DateTime(2011, 1, 1)));
        }
    }
}
