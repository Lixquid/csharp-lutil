using System;
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
        }

        [TestMethod]
        public void GetOrDefault_TValue() {
            // Value type
            var d = new Dictionary<int, int>();

            Assert.IsFalse(d.ContainsKey(2));
            var c = d.GetOrDefault(2, 5);
            Assert.AreEqual(5, c);

            // Reference type
            var d2 = new Dictionary<int, List<int>>();

            Assert.IsFalse(d.ContainsKey(2));
            var c2 = d2.GetOrDefault(2, new List<int> { 1, 2, 3 });
            Assert.IsNotNull(c2);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, c2);
        }

        [TestMethod]
        public void GetOrDefault_Func() {
            var d = new Dictionary<int, List<int>>();

            Assert.IsFalse(d.ContainsKey(2));
            var c = d.GetOrDefault(2, i => new List<int> { i, i, i });
            Assert.IsNotNull(c);
            CollectionAssert.AreEqual(new[] { 2, 2, 2 }, c);
        }

        [TestMethod]
        public void GetOrInsert_Constructor() {
            var d = new Dictionary<int, List<int>>();

            Assert.IsFalse(d.ContainsKey(2));
            var c = d.GetOrInsert(2);
            Assert.IsNotNull(c);
            Assert.AreEqual(c, d[2]);
            Assert.IsInstanceOfType(c, typeof(List<int>));
        }

        [TestMethod]
        public void GetOrInsert_TValue() {
            var d = new Dictionary<int, string>();

            Assert.IsFalse(d.ContainsKey(2));
            Assert.AreEqual("two", d.GetOrInsert(2, "two"));
            Assert.IsTrue(d.ContainsKey(2));
            Assert.AreEqual("two", d[2]);
        }

        [TestMethod]
        public void GetOrInsert_Func() {
            var d = new Dictionary<int, ICollection<int>>();

            Assert.IsFalse(d.ContainsKey(2));
            var c = d.GetOrInsert(2, i => new int[i]);
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

        [TestMethod]
        public void ToDictionary() {
            var d1 = new[] {
                new KeyValuePair<int, string>( 1, "one" ),
                new KeyValuePair<int, string>( 2, "two" ),
                new KeyValuePair<int, string>( 3, "three" )
            }.ToDictionary();
            var d2 = new[] {
                Tuple.Create(1, "one"),
                Tuple.Create(2, "two"),
                Tuple.Create(3, "three")
            }.ToDictionary();
            var d3 = new[] {
                (1, "one"),
                (2, "two"),
                (3, "three")
            }.ToDictionary();

            Assert.AreEqual("one", d1[1]);
            Assert.AreEqual("one", d2[1]);
            Assert.AreEqual("one", d3[1]);
            Assert.AreEqual("two", d1[2]);
            Assert.AreEqual("two", d2[2]);
            Assert.AreEqual("two", d3[2]);
            Assert.AreEqual("three", d1[3]);
            Assert.AreEqual("three", d2[3]);
            Assert.AreEqual("three", d3[3]);
        }
    }
}
