using System;

namespace LUtil.Helpers {
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
    }
}
