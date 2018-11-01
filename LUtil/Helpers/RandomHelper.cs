using System.Collections.Generic;
using System.Linq;
using LUtil.Helpers.Extensions;

namespace LUtil.Helpers {
    public static class RandomHelper {
        /// <summary>
        ///     Generates a new random string of the specified length, composed
        ///     of characters from the specified source.
        /// </summary>
        /// <param name="random">The source of randomness.</param>
        /// <param name="length">The length of string to generate.</param>
        /// <param name="source">
        ///     The source of characters to build the string from.
        ///
        ///     If a character appears multiple times in the source, it is more
        ///     likely to appear in the output string.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if <paramref name="random"/> or
        ///     <paramref name="source"/> is <c>null</c>.
        /// </exception>
        public static string NextString(System.Random random, int length, IList<char> source) {
            random.ThrowIfNull(nameof(random));
            source.ThrowIfNull(nameof(source));

            var output = new char[length];
            for (var i = 0; i < length; i++) {
                output[i] = source[random.Next(source.Count)];
            }

            return string.Concat(output);
        }

        /// <inheritdoc cref="NextString(System.Random,int,System.Collections.Generic.IList{char})"/>
        public static string NextString(
            System.Random random,
            int length,
            string source = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        ) {
            source.ThrowIfNull(nameof(source));
            return NextString(random, length, source.ToCharArray());
        }

        /// <summary>
        ///     Returns a random member of a specified enumerable.
        /// </summary>
        /// <typeparam name="T">The type enumerated in the enumerable.</typeparam>
        /// <param name="random">The source of randomness.</param>
        /// <param name="enumerable">The enumerable to get a random value from.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if <paramref name="random"/> or
        ///     <paramref name="enumerable"/> is <c>null</c>.
        /// </exception>
        public static T NextFromEnumerable<T>(System.Random random, IEnumerable<T> enumerable) {
            random.ThrowIfNull(nameof(random));
            enumerable.ThrowIfNull(nameof(enumerable));

            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list[random.Next(list.Count)];
        }

        /// <summary>
        ///     Returns an infinite enumerable that returns <c>double</c>s
        ///     between 0 inclusive and 1 exclusive from a
        ///     <see cref="System.Random"/>.
        /// </summary>
        /// <param name="random">The source of random values.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if <paramref name="random"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<double> GetDoubleEnumerable(System.Random random) {
            random.ThrowIfNull(nameof(random));
            return GetIterator();

            IEnumerable<double> GetIterator() {
                while (true) {
                    yield return random.NextDouble();
                }
            }
        }

        /// <summary>
        ///     Returns an infinite enumerable that returns non-negative
        ///     <c>int</c>s from a <see cref="System.Random"/>.
        /// </summary>
        /// <param name="random">The source of random values.</param>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if <paramref name="random"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<int> GetIntEnumerable(System.Random random) {
            random.ThrowIfNull(nameof(random));
            return GetIterator();

            IEnumerable<int> GetIterator() {
                while (true) {
                    yield return random.Next();
                }
            }
        }

        /// <summary>
        ///     Returns an infinite enumerable that returns non-negative
        ///     <c>int</c>s that are below a maximum value from a
        ///     <see cref="System.Random"/>.
        /// </summary>
        /// <param name="random">The source of random values.</param>
        /// <param name="maxValue">
        ///     The exclusive upper bound of generated values.
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="maxValue">maxValue</paramref> is less
        ///     than 0.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if <paramref name="random"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<int> GetIntEnumerable(System.Random random, int maxValue) {
            random.ThrowIfNull(nameof(random));
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            random.Next(maxValue);
            return GetIterator();

            IEnumerable<int> GetIterator() {
                while (true) {
                    yield return random.Next(maxValue);
                }
            }
        }

        /// <summary>
        ///     Returns an infinite enumerable that returns <c>int</c>s that are
        ///     between a specified range from a <see cref="System.Random"/>.
        /// </summary>
        /// <param name="random">The source of random values.</param>
        /// <param name="minValue">
        ///     The inclusive lower bound of generated values.
        /// </param>
        /// <param name="maxValue">
        ///     The exclusive upper bound of generated values.
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="minValue">minValue</paramref> is greater than
        ///     <paramref name="maxValue">maxValue</paramref>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     Thrown if <paramref name="random"/> is <c>null</c>.
        /// </exception>
        public static IEnumerable<int> GetIntEnumerable(System.Random random, int minValue, int maxValue) {
            random.ThrowIfNull(nameof(random));
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            random.Next(minValue, maxValue);
            return GetIterator();

            IEnumerable<int> GetIterator() {
                while (true) {
                    yield return random.Next(minValue, maxValue);
                }
            }
        }
    }
}
