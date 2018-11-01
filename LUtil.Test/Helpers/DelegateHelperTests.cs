using System;
using System.Linq;
using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class DelegateHelperTests {

        private delegate int InvokeAllTestDelegate(int input);
        [TestMethod]
        public void InvokeAll_General() {
            InvokeAllTestDelegate mul = input => input * 2;
            mul += input => input * 4;
            mul += input => input * 8;

            CollectionAssert.AreEqual(new[] { 2, 4, 8 }, mul.InvokeAll(1).Cast<int>().ToArray());
            CollectionAssert.AreEqual(new[] { 6, 12, 24 }, mul.InvokeAll(3).Cast<int>().ToArray());
        }

        [TestMethod]
        public void InvokeAll_Func() {
            Func<int, int> mul = i => i * 2;
            mul += i => i * 4;
            mul += i => i * 8;

            CollectionAssert.AreEqual(new[] { 2, 4, 8 }, mul.InvokeAll(1).ToArray());
            CollectionAssert.AreEqual(new[] { 6, 12, 24 }, mul.InvokeAll(3).ToArray());
        }
    }
}
