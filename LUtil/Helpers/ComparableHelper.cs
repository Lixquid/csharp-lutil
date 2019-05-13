using System;
using JetBrains.Annotations;

namespace LUtil.Helpers {
    [PublicAPI]
    public static class ComparableHelper {
        /// <summary>
        ///     Returns if a value is between two other values, inclusive.
        /// </summary>
        /// <typeparam name="T">The type of the value to be compared.</typeparam>
        /// <param name="value">The value to compare.</param>
        /// <param name="min">The minimum value the value can take.</param>
        /// <param name="max">The maximum value the value can take.</param>
        public static bool IsBetween<T>(T value, T min, T max) where T : IComparable<T> =>
            value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;

        /// <summary>
        ///     Returns the given value if it between the given bounds,
        ///     otherwise the respective bound.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T> {
            return value.CompareTo(min) < 0 ? min
                 : value.CompareTo(max) > 0 ? max
                 : value;
        }
    }
}
