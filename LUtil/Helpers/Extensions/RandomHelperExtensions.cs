﻿using System.Collections.Generic;

namespace LUtil.Helpers.Extensions {
    public static class RandomHelperExtensions {
        /// <inheritdoc cref="RandomHelper.NextString(System.Random,int,System.Collections.Generic.IList{char})"/>
        public static string NextString(this System.Random random, int length, IList<char> source) =>
            RandomHelper.NextString(random, length, source);

        /// <inheritdoc cref="RandomHelper.NextString(System.Random,int,string)"/>
        public static string NextString(
            this System.Random random,
            int length,
            string source = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        ) =>
            RandomHelper.NextString(random, length, source);

        /// <inheritdoc cref="RandomHelper.NextFromEnumerable{T}(System.Random,IEnumerable{T})"/>
        public static T NextFromEnumerable<T>(this System.Random random, IEnumerable<T> enumerable) =>
            RandomHelper.NextFromEnumerable(random, enumerable);

        /// <inheritdoc cref="RandomHelper.GetDoubleEnumerable"/>
        public static IEnumerable<double> GetDoubleEnumerable(this System.Random random) =>
            RandomHelper.GetDoubleEnumerable(random);

        /// <inheritdoc cref="RandomHelper.GetIntEnumerable(System.Random)"/>
        public static IEnumerable<int> GetIntEnumerable(this System.Random random) =>
            RandomHelper.GetIntEnumerable(random);

        /// <inheritdoc cref="RandomHelper.GetIntEnumerable(System.Random,int)"/>
        public static IEnumerable<int> GetIntEnumerable(this System.Random random, int maxValue) =>
            RandomHelper.GetIntEnumerable(random, maxValue);

        /// <inheritdoc cref="RandomHelper.GetIntEnumerable(System.Random,int,int)"/>
        public static IEnumerable<int> GetIntEnumerable(this System.Random random, int minValue, int maxValue) =>
            RandomHelper.GetIntEnumerable(random, minValue, maxValue);
    }
}