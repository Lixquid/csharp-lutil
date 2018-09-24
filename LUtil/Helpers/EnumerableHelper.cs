using System.Collections.Generic;

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

    }
}
