using System;
using System.Collections.Generic;
using System.Linq;
using LUtil.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Collections {
    [TestClass]
    public class ChainedComparerTests {
        #region Setup
        private class Person {
            public readonly int Id;
            public readonly string Name;
            public readonly int Age;

            public Person(int id, string name, int age) {
                Id = id;
                Name = name;
                Age = age;
            }
        }

        private static readonly IComparer<Person> AgeComparer = Comparer<Person>.Create((x, y) => x.Age.CompareTo(y.Age));

        private static readonly IComparer<Person> NameComparer =
            Comparer<Person>.Create((x, y) => string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase));

        private readonly Person[] _people = {
            new Person(1, "A", 15),
            new Person(2, "A", 10),
            new Person(3, "A", 5),
            new Person(4, "B", 5),
            new Person(5, "C", 15)
        };
        #endregion

        [TestMethod]
        public void Compare() {
            var nameAgeSorted = _people
                .OrderBy(x => x, new ChainedComparer<Person>(NameComparer, AgeComparer))
                .Select(x => x.Id)
                .ToArray();
            CollectionAssert.AreEqual(new[] { 3, 2, 1, 4, 5 }, nameAgeSorted);

            var ageNameSorted = _people
                .OrderBy(x => x, new ChainedComparer<Person>(AgeComparer, NameComparer))
                .Select(x => x.Id)
                .ToArray();
            CollectionAssert.AreEqual(new[] { 3, 4, 2, 1, 5 }, ageNameSorted);
        }
    }
}
