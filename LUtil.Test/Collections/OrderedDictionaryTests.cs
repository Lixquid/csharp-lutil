using System.Linq;
using LUtil.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Collections {
    [TestClass]
    public class OrderedDictionaryTests {
        [TestMethod]
        public void InterfaceMethods() {
            var d = new OrderedDictionary<int, string> {
                [3] = "three",
                [2] = "two",
                [1] = "one",
            };

            Assert.AreEqual("one", d[1]);
            Assert.AreEqual(3, d.First().Key);
            Assert.IsTrue(d.ContainsKey(3));
            Assert.IsFalse(d.ContainsKey(4));

            d.Add(4, "four");
            CollectionAssert.AreEqual(new[] { 3, 2, 1, 4 }, d.Keys.ToList());
            CollectionAssert.AreEqual(new[] { 3, 2, 1, 4 }, d.Select(kv => kv.Key).ToList());
        }

        // TODO: Add more tests for constructors
    }
}
