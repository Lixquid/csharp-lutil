using System;

namespace LUtil.Helpers.Extensions {
    public static class ComparableHelperExtensions {
        /// <inheritdoc cref="ComparableHelper.IsBetween{T}"/>
        public static bool IsBetween<T>(
            this T value,
            T min,
            T max,
            ComparableHelper.IsBetweenInclusivity inclusivity = ComparableHelper.IsBetweenInclusivity.Inclusive
        ) where T : IComparable<T> =>
            ComparableHelper.IsBetween(value, min, max, inclusivity);
    }
}
