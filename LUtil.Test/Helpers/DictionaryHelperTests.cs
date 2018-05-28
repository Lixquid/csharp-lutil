using System.Collections.Generic;
using LUtil.Helpers;
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
            var dr = DictionaryHelper.Reverse( d );
            Assert.AreEqual( 3, dr.Count );
            Assert.AreEqual( "one", dr[1] );
            Assert.AreEqual( "two", dr[2] );
            Assert.AreEqual( "three", dr[3] );
        }
    }
}
