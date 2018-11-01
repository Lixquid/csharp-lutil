using LUtil.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class EnumerableStaticHelperTests {
        [TestMethod]
        public void Repeat() {
            var i = 0;
            foreach (var v in EnumerableStaticHelper.Repeat(5)) {
                Assert.AreEqual(5, v);
                if (i++ == 10)
                    break;
            }
        }

        [TestMethod]
        public void Repeat_Condition() {
            var i = 0;
            foreach (var v in EnumerableStaticHelper.Repeat(5, () => i != 10)) {
                Assert.AreEqual(5, v);
                i++;
            }
            Assert.AreEqual(10, i);
        }
    }
}
