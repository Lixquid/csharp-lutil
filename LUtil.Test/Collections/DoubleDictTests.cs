using System;
using System.Collections.Generic;
using LUtil.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Collections {
    [TestClass]
    public class DoubleDictTests {
        [TestMethod]
        public void InterfaceMethods() {
            var d = new DoubleDict<int, string> {
                { 1, "one" },
                { "two", 2 },
                { 3, "three" }
            };
            Assert.AreEqual( 1, d["one"] );
            Assert.AreEqual( "one", d[1] );
            Assert.IsTrue( d.ContainsKey( 3 ) );
            Assert.IsTrue( d.ContainsKey( "three" ) );
            Assert.IsFalse( d.ContainsKey( 4 ) );

            Assert.AreEqual( 3, d.Count );
            Assert.IsTrue( d.Remove( 3 ) );
            Assert.IsFalse( d.ContainsKey( "three" ) );
        }

        [TestMethod]
        public void ForwardBackward() {
            var d = new DoubleDict<int, int>();
            d.Forward.Add( 1, 2 );
            d.Forward.Add( 2, 3 );
            d.Forward.Add( 3, 4 );

            Assert.AreEqual( 2, d.Forward[1] );
            Assert.AreEqual( 1, d.Backward[2] );
        }

        [TestMethod]
        public void Constructors_Comparers() {
            var d = new DoubleDict<string, int>( StringComparer.OrdinalIgnoreCase, EqualityComparer<int>.Default ) {
                { "one", 1 },
                { 2, "two" },
                { "three", 3 }
            };

            Assert.AreEqual( 1, d["ONE"] );
            Assert.IsTrue( d.ContainsKey( "TWO" ) );
            Assert.IsFalse( d.ContainsKey( "FOUR" ) );
        }

        [TestMethod]
        public void Constructors_ExistingDictionary() {
            var d = new DoubleDict<int, int>( new Dictionary<int, int> {
                { 1, 2 },
                { 2, 3 },
                { 3, 4 }
            } );
            Assert.AreEqual( 2, d.Forward[1] );
            Assert.AreEqual( 1, d.Backward[2] );
        }
    }
}
