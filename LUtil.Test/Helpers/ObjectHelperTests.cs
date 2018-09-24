using System;
using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class ObjectHelperTests {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ThrowIfNull() {
            // No Exception should be thrown
            var input = "value";
            input.ThrowIfNull(nameof(input));

            // ArgumentNullException should be thrown
            input = null;
            input.ThrowIfNull(nameof(input));
        }
    }
}
