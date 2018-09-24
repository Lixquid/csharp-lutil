using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class EnumerableHelperTests {
        [TestMethod]
        public void Repeat() {
            var i = 0;
            var enumerable = new[] { 1, 2, 3 };
            foreach (var v in enumerable.Repeat()) {
                Assert.AreEqual(enumerable[i % 3], v);
                if (i++ == 10)
                    break;
            }
        }

        [TestMethod]
        public void Repeat_Condition() {
            var i = 0;
            var enumerable = new[] { 1, 2, 3 };
            foreach (var v in enumerable.Repeat(iv => i < 10 || iv != 3)) {
                Assert.AreEqual(enumerable[i % 3], v);
                i++;
            }
            Assert.AreEqual(11, i);
        }
    }
}
