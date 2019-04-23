using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LUtil.Helpers.Extensions;

namespace LUtil.Helpers {
    [PublicAPI]
    public static class EnumerableHelper {
        /// <summary>
        ///     Returns a random value from an enumerable.
        ///
        ///     Warning: This will enumerate the enumerable!
        /// </summary>
        /// <typeparam name="T">The type enumerated in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to get a random value from.</param>
        /// <param name="random">The source of randomness.</param>
        public static T Random<T>([NotNull, InstantHandle] IEnumerable<T> enumerable, [NotNull] System.Random random) =>
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
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> is <c>null</c>.
        /// </exception>
        public static T Random<T>([NotNull, InstantHandle] IEnumerable<T> enumerable) {
            enumerable.ThrowIfNull(nameof(enumerable));

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
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<T> Repeat<T>([NotNull, InstantHandle] IEnumerable<T> enumerable) {
            enumerable.ThrowIfNull(nameof(enumerable));

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
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> or
        ///     <paramref name="condition"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<T> Repeat<T>([NotNull, InstantHandle] IEnumerable<T> enumerable, [NotNull] Func<T, bool> condition) {
            enumerable.ThrowIfNull(nameof(enumerable));
            condition.ThrowIfNull(nameof(condition));

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

        /// <summary>
        ///     Returns a new enumerable which repeats an existing enumerable
        ///     the specified number of times.
        /// </summary>
        /// <typeparam name="T">The type of value returned in the Enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to get values from.</param>
        /// <param name="count">The number of times to repeat the Enumerable.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="count"/> is a negative number.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if the source <paramref name="enumerable"/> contains no
        ///     elements.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<T> Repeat<T>([NotNull, InstantHandle] IEnumerable<T> enumerable, int count) {
            enumerable.ThrowIfNull(nameof(enumerable));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var list = enumerable as IList<T> ?? enumerable.ToList();
            if (list.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            return GetIterator();

            IEnumerable<T> GetIterator() {
                var iterations = 0;
                while (iterations++ < count) {
                    foreach (var v in list) {
                        yield return v;
                    }
                }
            }
        }

        /// <summary>
        ///     Returns a new enumerable which includes the specified value(s)
        ///     at the end.
        /// </summary>
        /// <typeparam name="T">The type of value returned in the Enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to add values to.</param>
        /// <param name="values">The value(s) to be appended.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> or
        ///     <paramref name="values"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<T> Concat<T>([NotNull] IEnumerable<T> enumerable, params T[] values) {
            enumerable.ThrowIfNull(nameof(enumerable));
            values.ThrowIfNull(nameof(values));
            return Enumerable.Concat(enumerable, values);
        }

        /// <summary>
        ///     Returns a copy of the given enumerable, shuffled with the
        ///     Fisher-Yates algorithm.
        /// </summary>
        /// <typeparam name="T">The type of value returned in the Enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to be shuffled.</param>
        /// <param name="random">The source of randomness.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> or
        ///     <paramref name="random"/> is <c>null</c>.
        /// </exception>>
        public static IEnumerable<T> Shuffle<T>([NotNull, InstantHandle] IEnumerable<T> enumerable,
            [NotNull] System.Random random) {

            enumerable.ThrowIfNull(nameof(enumerable));
            random.ThrowIfNull(nameof(random));

            var output = new List<T>(enumerable);
            var n = output.Count;
            while (n > 1) {
                n--;
                var k = random.Next(n + 1);
                var swap = output[k];
                output[k] = output[n];
                output[n] = swap;
            }

            return output;
        }

        /// <summary>
        ///     Returns a copy of the given enumerable, shuffled with the
        ///     Fisher-Yates algorithm.
        /// </summary>
        /// <typeparam name="T">The type of value returned in the Enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to be shuffled.</param>
        /// <remarks>
        ///     Behind the scenes, this uses a <c>static</c>, <c>lock</c>ed
        ///     <see cref="System.Random"/> to generate random values. To use
        ///     your own source of randomness, see
        ///     <see cref="Random{T}(IEnumerable{T},System.Random)"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<T> Shuffle<T>([NotNull, InstantHandle] IEnumerable<T> enumerable) {
            enumerable.ThrowIfNull(nameof(enumerable));

            lock (_randomDefaultLock) {
                return Shuffle(enumerable, _randomDefault);
            }
        }

    }
}
