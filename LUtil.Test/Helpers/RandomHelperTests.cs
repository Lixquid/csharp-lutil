using System.Linq;
using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class RandomHelperTests {
        [TestMethod]
        public void NextString_Array() {
            var chars = new[] { 'a', 'b', 'c' };
            var random = new System.Random();
            foreach (var _ in Enumerable.Range(0, 100)) {
                var output = random.NextString(20, chars);
                Assert.AreEqual(20, output.Length);
                foreach (var c in output) {
                    CollectionAssert.Contains(chars, c);
                }
            }
        }

        [TestMethod]
        public void NextString_String() {
            var random = new System.Random();
            foreach (var _ in Enumerable.Range(0, 100)) {
                var output = random.NextString(20, "abc");
                Assert.AreEqual(20, output.Length);
                foreach (var c in output) {
                    CollectionAssert.Contains(new[] { 'a', 'b', 'c' }, c);
                }
            }
        }

        [TestMethod]
        public void NextFromEnumerable() {
            var enumerable = Enumerable.Range(0, 100).ToList();
            var random = new System.Random();

            foreach (var _ in Enumerable.Range(0, 100)) {
                CollectionAssert.Contains(enumerable, random.NextFromEnumerable(enumerable));
            }
        }

        [TestMethod]
        public void GetDoubleEnumerable() {
            var i = 0;
            var enumerable = new System.Random().GetDoubleEnumerable();
            foreach (var v in enumerable) {
                Assert.IsTrue(v >= 0);
                Assert.IsTrue(v < 1);
                if (i++ == 100)
                    break;
            }
        }

        [TestMethod]
        public void GetIntEnumerable() {
            var i = 0;
            var enumerable = new System.Random().GetIntEnumerable();
            foreach (var v in enumerable) {
                Assert.IsTrue(v >= 0);
                if (i++ == 1000)
                    break;
            }

            i = 0;
            enumerable = new System.Random().GetIntEnumerable(10);
            foreach (var v in enumerable) {
                Assert.IsTrue(v >= 0);
                Assert.IsTrue(v < 10);
                if (i++ == 1000)
                    break;
            }

            i = 0;
            enumerable = new System.Random().GetIntEnumerable(-10, 10);
            foreach (var v in enumerable) {
                Assert.IsTrue(v >= -10);
                Assert.IsTrue(v < 10);
                if (i++ == 1000)
                    break;
            }
        }
    }
}
