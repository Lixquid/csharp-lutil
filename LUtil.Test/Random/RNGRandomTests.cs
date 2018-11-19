using System.Security.Cryptography;
using LUtil.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Random {


    [TestClass]
    public class RNGRandomTests {

        private class MockRNG : RandomNumberGenerator {
            private byte Counter { get; set; } = 0;

            private byte GetByte() {
                unchecked {
                    return Counter++;
                }
            }

            public override void GetBytes(byte[] data) {
                for (var i = 0; i < data.Length; i++) {
                    data[i] = GetByte();
                }
            }
        }

        [TestMethod]
        public void RandomOverriddenMethods() {
            var r = new RNGRandom(new MockRNG());

            double d;
            int i;
            for (var x = 0; x < 50000; x++) {
                d = r.NextDouble();
                Assert.IsTrue(0 <= d);
                Assert.IsTrue(d < 1);
                i = r.Next();
                Assert.IsTrue(0 <= i);
                Assert.IsTrue(i < int.MaxValue);
                i = r.Next(10);
                Assert.IsTrue(0 <= i);
                Assert.IsTrue(i < 10);
                i = r.Next(-10, 10);
                Assert.IsTrue(-10 <= i);
                Assert.IsTrue(i < 10);
            }
        }

    }
}
