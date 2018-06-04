using System.Collections.Generic;
using LUtil.Helpers;
using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class DictionaryHelperTests {
        [TestMethod]
        public void Reverse() {
            var d = new Dictionary<string, int> {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            };
            var dr = DictionaryHelper.Reverse(d);
            Assert.AreEqual(3, dr.Count);
            Assert.AreEqual("one", dr[1]);
            Assert.AreEqual("two", dr[2]);
            Assert.AreEqual("three", dr[3]);
        }

        [TestMethod]
        public void GetOrDefault_Constructor() {
            var d = new Dictionary<int, List<int>>();

            Assert.IsFalse(d.ContainsKey(2));
            var c = d.GetOrDefault(2);
            Assert.IsNotNull(c);
            Assert.AreEqual(c, d[2]);
            Assert.IsInstanceOfType(c, typeof(List<int>));
        }

        [TestMethod]
        public void GetOrDefault_TValue() {
            var d = new Dictionary<int, string>();

            Assert.IsFalse(d.ContainsKey(2));
            Assert.AreEqual("two", d.GetOrDefault(2, "two"));
            Assert.IsTrue(d.ContainsKey(2));
            Assert.AreEqual("two", d[2]);
        }

        [TestMethod]
        public void GetOrDefault_Func() {
            var d = new Dictionary<int, ICollection<int>>();

            Assert.IsFalse(d.ContainsKey(2));
            var c = d.GetOrDefault(2, i => new int[i]);
            Assert.IsTrue(d.ContainsKey(2));
            Assert.AreSame(c, d[2]);
            Assert.AreEqual(2, d[2].Count);
        }

        [TestMethod]
        public void GetOrNull() {
            var d = new Dictionary<int, string> {
                { 1, "one" },
                { 2, "two" }
            };

            Assert.AreEqual("one", d.GetOrNull(1));
            Assert.IsNull(d.GetOrNull(3));
        }

        [TestMethod]
        public void GetOrNullable() {
            var d = new Dictionary<string, int> {
                { "one", 1 },
                { "two", 2 }
            };

            Assert.AreEqual(1, d.GetOrNullable("one"));
            Assert.IsNull(d.GetOrNullable("three"));
        }
    }
}
