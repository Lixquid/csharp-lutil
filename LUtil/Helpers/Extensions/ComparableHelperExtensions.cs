using System;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class ComparableHelperExtensions {
        /// <inheritdoc cref="ComparableHelper.IsBetween{T}"/>
        public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T> =>
            ComparableHelper.IsBetween(value, min, max);
    }
}
