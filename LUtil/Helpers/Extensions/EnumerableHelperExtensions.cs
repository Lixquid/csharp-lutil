using System;
using System.Collections.Generic;

namespace LUtil.Helpers.Extensions {
    public static class EnumerableHelperExtensions {
        /// <inheritdoc cref="EnumerableHelper.Random{T}(IEnumerable{T},System.Random)"/>
        public static T Random<T>(this IEnumerable<T> enumerable, System.Random random) =>
            EnumerableHelper.Random(enumerable, random);

        /// <inheritdoc cref="EnumerableHelper.Random{T}(IEnumerable{T})"/>
        public static T Random<T>(this IEnumerable<T> enumerable) =>
            EnumerableHelper.Random(enumerable);

        /// <inheritdoc cref="EnumerableHelper.Repeat{T}(IEnumerable{T})"/>
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> enumerable) =>
            EnumerableHelper.Repeat(enumerable);

        /// <inheritdoc cref="EnumerableHelper.Repeat{T}(IEnumerable{T},Func{T,bool})"/>
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> enumerable, Func<T, bool> condition) =>
            EnumerableHelper.Repeat(enumerable, condition);
    }
}
