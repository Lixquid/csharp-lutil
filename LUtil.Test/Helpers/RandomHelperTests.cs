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
    }
}
