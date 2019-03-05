using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class RandomHelperExtensions {
        /// <inheritdoc cref="RandomHelper.NextString(System.Random,int,System.Collections.Generic.IList{char})"/>
        public static string NextString([NotNull] this System.Random random, int length, [NotNull] IList<char> source) =>
            RandomHelper.NextString(random, length, source);

        /// <inheritdoc cref="RandomHelper.NextString(System.Random,int,string)"/>
        public static string NextString(
            [NotNull] this System.Random random,
            int length,
            [NotNull] string source = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        ) =>
            RandomHelper.NextString(random, length, source);

        /// <inheritdoc cref="RandomHelper.NextFromEnumerable{T}(System.Random,IEnumerable{T})"/>
        public static T NextFromEnumerable<T>([NotNull] this System.Random random, [NotNull, InstantHandle] IEnumerable<T> enumerable) =>
            RandomHelper.NextFromEnumerable(random, enumerable);

        /// <inheritdoc cref="RandomHelper.NextBoolean(System.Random)"/>
        public static bool NextBoolean([NotNull] this System.Random random) =>
            RandomHelper.NextBoolean(random);

        /// <inheritdoc cref="RandomHelper.GetDoubleEnumerable"/>
        public static IEnumerable<double> GetDoubleEnumerable([NotNull] this System.Random random) =>
            RandomHelper.GetDoubleEnumerable(random);

        /// <inheritdoc cref="RandomHelper.GetIntEnumerable(System.Random)"/>
        public static IEnumerable<int> GetIntEnumerable([NotNull] this System.Random random) =>
            RandomHelper.GetIntEnumerable(random);

        /// <inheritdoc cref="RandomHelper.GetIntEnumerable(System.Random,int)"/>
        public static IEnumerable<int> GetIntEnumerable([NotNull] this System.Random random, int maxValue) =>
            RandomHelper.GetIntEnumerable(random, maxValue);

        /// <inheritdoc cref="RandomHelper.GetIntEnumerable(System.Random,int,int)"/>
        public static IEnumerable<int> GetIntEnumerable([NotNull] this System.Random random, int minValue, int maxValue) =>
            RandomHelper.GetIntEnumerable(random, minValue, maxValue);
    }
}
