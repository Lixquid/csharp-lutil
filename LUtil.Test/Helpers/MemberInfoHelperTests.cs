using System.Linq;
using LUtil.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class MemberInfoHelperTests {
        private class TestingClass {
            public string StringField;
            public int IntProperty { get; set; }
        }

        [TestMethod]
        public void GetMemberType() {
            Assert.AreEqual( typeof( string ), typeof( TestingClass ).GetMembers().Single( m => m.Name == "StringField" ).GetMemberType() );
            Assert.AreEqual( typeof( int ), typeof( TestingClass ).GetMembers().Single( m => m.Name == "IntProperty" ).GetMemberType() );
        }

        [TestMethod]
        public void SetValue() {
            var instance = new TestingClass();

            typeof( TestingClass ).GetMembers()
                .Single( m => m.Name == "StringField" )
                .SetValue( instance, "hello" );
            Assert.AreEqual( "hello", instance.StringField );
            typeof( TestingClass ).GetMembers()
                .Single( m => m.Name == "IntProperty" )
                .SetValue( instance, 5 );
            Assert.AreEqual( 5, instance.IntProperty );
        }

        [TestMethod]
        public void GetValue() {
            var instance = new TestingClass {
                StringField = "hello",
                IntProperty = 5
            };

            Assert.AreEqual(
                "hello",
                typeof( TestingClass ).GetMembers()
                    .Single( m => m.Name == "StringField" )
                    .GetValue( instance )
            );
            Assert.AreEqual(
                5,
                typeof( TestingClass ).GetMembers()
                    .Single( m => m.Name == "IntProperty" )
                    .GetValue( instance )
            );
        }

    }
}
