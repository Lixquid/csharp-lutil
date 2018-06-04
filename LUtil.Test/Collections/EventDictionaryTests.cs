using System;
using LUtil.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Collections {
    [TestClass]
    public class EventDictionaryTests {
        [TestMethod]
        public void Constructors() {
            var d1 = new EventDictionary<int, string> { { 1, "one" }, { 2, "two" } };
            Assert.AreEqual("one", d1[1]);
            Assert.AreEqual("two", d1[2]);

            var d2 = new EventDictionary<string, int>(StringComparer.OrdinalIgnoreCase) {
                { "one", 1 },
                { "two", 2 }
            };
            Assert.AreEqual(1, d2["ONE"]);
            Assert.AreEqual(2, d2["TWO"]);
        }

        [TestMethod]
        public void ItemSet() {
            var d = new EventDictionary<string, string>();
            d.ItemSet += (sender, pair) => {
                Assert.AreEqual("key", pair.Key);
                Assert.AreEqual("value", pair.Value);
            };
            d.Add("key", "value");
            Assert.AreEqual(1, d.Count);
        }

        [TestMethod]
        public void ItemRemoved() {
            var d = new EventDictionary<string, string> {
                { "key", "value" }
            };
            d.ItemRemoved += (sender, kp) => {
                Assert.AreEqual("key", kp.Key);
                Assert.AreEqual("value", kp.Value);
            };
            d.Remove("key");
            Assert.AreEqual(0, d.Count);
        }

        [TestMethod]
        public void DictionaryCleared() {
            var d = new EventDictionary<string, string> {
                { "key", "value" },
                { "2", "two" }
            };
            var eventTriggered = false;
            d.DictionaryCleared += (sender, args) => eventTriggered = true;
            d.Clear();
            Assert.IsTrue(eventTriggered);
            Assert.AreEqual(0, d.Count);
        }
    }
}
