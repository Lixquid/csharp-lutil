using System.Linq;
using LUtil.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class EnumHelperTests {
        private enum GetValues_Typical {
            First, Second, Third
        }

        private enum GetValues_Strange : byte {
            None = 0,
            First = 1,
            FirstAgain = 1,
            Second = 2,
            Many = 100
        }

        [TestMethod]
        public void GetValues() {
            CollectionAssert.AreEqual(
                new[] { GetValues_Typical.First, GetValues_Typical.Second, GetValues_Typical.Third },
                EnumHelper.GetValues<GetValues_Typical>().ToList()
            );
            CollectionAssert.AreEqual(
                new[] { GetValues_Strange.None, GetValues_Strange.First, GetValues_Strange.FirstAgain, GetValues_Strange.Second, GetValues_Strange.Many },
                EnumHelper.GetValues<GetValues_Strange>().ToList()
            );
        }
    }
}
