using System;
using System.Collections.Generic;
using LUtil.Helpers.Extensions;

namespace LUtil.Helpers {
    public static class EnumerableStaticHelper {
        /// <summary>
        ///     Returns an enumerable that infinitely returns a value.
        /// </summary>
        /// <typeparam name="T">The type enumerated in the enumerable.</typeparam>
        /// <param name="value">The value the enumerable should return.</param>
        public static IEnumerable<T> Repeat<T>(T value) {
            while (true) {
                yield return value;
            }
        }

        /// <summary>
        ///     Returns an enumerable that returns a value while a condition is
        ///     <c>true</c>.
        /// </summary>
        /// <typeparam name="T">The type enumerated in the enumerable.</typeparam>
        /// <param name="value">The value the enumerable should return.</param>
        /// <param name="condition">
        ///     The condition to check when the enumerable is enumerated. If
        ///     <c>false</c> is returned, the enumerable will end.
        /// </param>
        public static IEnumerable<T> Repeat<T>(T value, Func<bool> condition) {
            condition.ThrowIfNull(nameof(condition));
            return GetIterator();

            IEnumerable<T> GetIterator() {
                while (condition()) {
                    yield return value;
                }
            }
        }
    }
}
