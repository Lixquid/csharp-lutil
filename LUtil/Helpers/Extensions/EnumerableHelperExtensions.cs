using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class EnumerableHelperExtensions {
        /// <inheritdoc cref="EnumerableHelper.Random{T}(IEnumerable{T},System.Random)"/>
        public static T Random<T>([NotNull, InstantHandle] this IEnumerable<T> enumerable, [NotNull] System.Random random) =>
            EnumerableHelper.Random(enumerable, random);

        /// <inheritdoc cref="EnumerableHelper.Random{T}(IEnumerable{T})"/>
        public static T Random<T>([NotNull, InstantHandle] this IEnumerable<T> enumerable) =>
            EnumerableHelper.Random(enumerable);

        /// <inheritdoc cref="EnumerableHelper.Repeat{T}(IEnumerable{T})"/>
        public static IEnumerable<T> Repeat<T>([NotNull, InstantHandle] this IEnumerable<T> enumerable) =>
            EnumerableHelper.Repeat(enumerable);

        /// <inheritdoc cref="EnumerableHelper.Repeat{T}(IEnumerable{T},Func{T,bool})"/>
        public static IEnumerable<T> Repeat<T>([NotNull, InstantHandle] this IEnumerable<T> enumerable, Func<T, bool> condition) =>
            EnumerableHelper.Repeat(enumerable, condition);

        /// <inheritdoc cref="EnumerableHelper.Repeat{T}(IEnumerable{T},int)"/>
        public static IEnumerable<T> Repeat<T>([NotNull, InstantHandle] this IEnumerable<T> enumerable, int count) =>
            EnumerableHelper.Repeat(enumerable, count);

        /// <inheritdoc cref="EnumerableHelper.Concat{T}(IEnumerable{T},T[])"/>
        public static IEnumerable<T> Concat<T>([NotNull] this IEnumerable<T> enumerable, params T[] values) =>
            EnumerableHelper.Concat(enumerable, values);

        /// <inheritdoc cref="EnumerableHelper.Shuffle{T}(IEnumerable{T},System.Random)"/>
        public static IEnumerable<T> Shuffle<T>([NotNull, InstantHandle] this IEnumerable<T> enumerable,
            System.Random random) =>
            EnumerableHelper.Shuffle(enumerable, random);

        /// <inheritdoc cref="EnumerableHelper.Shuffle{T}(IEnumerable{T})"/>
        public static IEnumerable<T> Shuffle<T>([NotNull, InstantHandle] this IEnumerable<T> enumerable) =>
            EnumerableHelper.Shuffle(enumerable);
    }
}
