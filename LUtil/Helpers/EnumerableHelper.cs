using System;
using System.Collections.Generic;
using System.Linq;

namespace LUtil.Helpers {
    public static class EnumerableHelper {
        /// <summary>
        ///     Returns a random value from an enumerable.
        ///
        ///     Warning: This will enumerate the enumerable!
        /// </summary>
        /// <typeparam name="T">The type enumerated in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to get a random value from.</param>
        /// <param name="random">The source of randomness.</param>
        public static T Random<T>(IEnumerable<T> enumerable, System.Random random) =>
            RandomHelper.NextFromEnumerable(random, enumerable);

        private static readonly System.Random _randomDefault = new System.Random();
        private static readonly object _randomDefaultLock = new object();


        /// <summary>
        ///     Returns a random value from an enumerable.
        ///
        ///     Warning: This will enumerate the enumerable!
        /// </summary>
        /// <typeparam name="T">The type enumerated in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to get a random value from.</param>
        /// <remarks>
        ///     Behind the scenes, this uses a <c>static</c>, <c>lock</c>ed
        ///     <see cref="System.Random"/> to generate random values. To use
        ///     your own source of randomness, see
        ///     <see cref="Random{T}(IEnumerable{T},System.Random)"/>.
        /// </remarks>
        public static T Random<T>(IEnumerable<T> enumerable) {
            lock (_randomDefaultLock) {
                return Random(enumerable, _randomDefault);
            }
        }

        /// <summary>
        ///     Returns an enumerable that will infinitely return values from
        ///     another enumerable, looping when it reaches the end.
        /// </summary>
        /// <typeparam name="T">The type of value returned in the Enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to get values from.</param>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if the source <paramref name="enumerable"/> contains no
        ///     elements.
        /// </exception>
        public static IEnumerable<T> Repeat<T>(IEnumerable<T> enumerable) {
            // Create a new list to avoid problems with the enumerable mutating
            // as we iterate over it
            var list = enumerable as IList<T> ?? enumerable.ToList();
            if (list.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            return GetIterator();

            // Use a private iterator so the list copy is created immediately,
            // and not when the enumerable is iterated.
            IEnumerable<T> GetIterator() {
                while (true) {
                    foreach (var v in list) {
                        yield return v;
                    }
                }
            }
        }

        /// <summary>
        ///     Returns an enumerable that will return values from
        ///     another enumerable (looping when it reaches the end), while a
        ///     condition returns <c>true</c>.
        /// </summary>
        /// <typeparam name="T">The type of value returned in the Enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to get values from.</param>
        /// <param name="condition">
        ///     The condition to check when the enumerable is enumerated. If
        ///     <c>false</c> is returned, the enumerable will end.
        /// </param>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if the source <paramref name="enumerable"/> contains no
        ///     elements.
        /// </exception>
        public static IEnumerable<T> Repeat<T>(IEnumerable<T> enumerable, Func<T, bool> condition) {
            var list = enumerable as IList<T> ?? enumerable.ToList();
            if (list.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            return GetIterator();

            IEnumerable<T> GetIterator() {
                while (true) {
                    foreach (var v in list) {
                        if (!condition(v))
                            yield break;
                        yield return v;
                    }
                }
            }
        }

    }
}
