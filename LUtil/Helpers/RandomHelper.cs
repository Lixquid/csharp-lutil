using System.Collections.Generic;
using System.Linq;

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
        public static string NextString(System.Random random, int length, IList<char> source) {
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
        ) =>
            NextString(random, length, source.ToCharArray());

        /// <summary>
        ///     Returns a random member of a specified enumerable.
        /// </summary>
        /// <typeparam name="T">The type enumerated in the enumerable.</typeparam>
        /// <param name="random">The source of randomness.</param>
        /// <param name="enumerable">The enumerable to get a random value from.</param>
        public static T NextFromEnumerable<T>(System.Random random, IEnumerable<T> enumerable) {
            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list[random.Next(list.Count)];
        }
    }
}
