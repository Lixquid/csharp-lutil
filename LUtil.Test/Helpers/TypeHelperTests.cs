using System;
using System.Collections;
using System.Collections.Generic;
using LUtil.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Helpers {
    [TestClass]
    public class TypeHelperTests {
        [TestMethod]
        public void GetAllImplementedTypes() {
            Assert.IsTrue(new HashSet<Type> {
                typeof(IComparable),
                typeof(IFormattable),
                typeof(IConvertible),
                typeof(IComparable<int>),
                typeof(IEquatable<int>),
                typeof(ValueType),
                typeof(object)
            }.SetEquals(TypeHelper.GetAllImplementedTypes(typeof(int))));

            Assert.IsTrue(new HashSet<Type> {
                typeof(IEnumerable)
            }.SetEquals(TypeHelper.GetAllImplementedTypes(typeof(IEnumerable<int>))));

            Assert.IsTrue(new HashSet<Type> {
                typeof(IEnumerable),
                // The T in IEnumerable<T> is *technically* more unbound than
                // the T in ICollection<T>, even though they accept the same
                // type. So, we need to construct a "more-bound" unbound type.
                // You can get the fully unbound IEnumerable<T> type by adding
                // withUnboundGenerics
                typeof(IEnumerable<>).MakeGenericType(typeof(ICollection<>).GetGenericArguments())
            }.SetEquals(TypeHelper.GetAllImplementedTypes(typeof(ICollection<>))));

            Assert.IsTrue(new HashSet<Type> {
                typeof(IComparable),
                typeof(IFormattable),
                typeof(IConvertible),
                typeof(IComparable<int>),
                typeof(IEquatable<int>),
                typeof(ValueType),
                typeof(object),
                typeof(IComparable<>),
                typeof(IEquatable<>)
            }.SetEquals(TypeHelper.GetAllImplementedTypes(typeof(int), withUnboundGenerics: true)));
        }
    }
}
