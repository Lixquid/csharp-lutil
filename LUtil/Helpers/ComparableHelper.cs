using System;

namespace LUtil.Helpers {
    public static class ComparableHelper {
        public enum IsBetweenInclusivity {
            /// <summary>
            ///     Specifies the value can be the same as the minimum or maximum.
            /// </summary>
            Inclusive = 0,
            /// <summary>
            ///     Specifies the value must be strictly larger than the minimum
            ///     and smaller than the maximum.
            /// </summary>
            Exclusive = 1,
            /// <summary>
            ///     Specifies the value can be equal to the minimum, but must be
            ///     strictly smaller than the maximum.
            /// </summary>
            MinInclusiveMaxExclusive = 2,
            /// <summary>
            ///     Specifies the value must be strictly larger than the minimum,
            ///     but can be equal to the maximum.
            /// </summary>
            MinExclusiveMaxInclusive = 3
        }
        /// <summary>
        ///     Returns if a value is between two other values.
        /// </summary>
        /// <typeparam name="T">The type of the value to be compared.</typeparam>
        /// <param name="value">The value to compare.</param>
        /// <param name="min">The minimum value the value can take.</param>
        /// <param name="max">The maximum value the value can take.</param>
        /// <param name="inclusivity">
        ///     The inclusivity rules to use. See
        ///     <see cref="IsBetweenInclusivity"/>.
        /// </param>
        public static bool IsBetween<T>(
            T value,
            T min,
            T max,
            IsBetweenInclusivity inclusivity = IsBetweenInclusivity.Inclusive
        ) where T : IComparable<T> {
            switch (inclusivity) {
                case IsBetweenInclusivity.Inclusive:
                    return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
                case IsBetweenInclusivity.Exclusive:
                    return value.CompareTo(min) > 0 && value.CompareTo(max) < 0;
                case IsBetweenInclusivity.MinInclusiveMaxExclusive:
                    return value.CompareTo(min) >= 0 && value.CompareTo(max) < 0;
                case IsBetweenInclusivity.MinExclusiveMaxInclusive:
                    return value.CompareTo(min) > 0 && value.CompareTo(max) <= 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inclusivity), inclusivity, null);
            }
        }
    }
}
