using System.Collections.Generic;

namespace LUtil.Helpers.Extensions {
    public static class RandomHelperExtensions {
        /// <inheritdoc cref="RandomHelper.NextString(System.Random,int,System.Collections.Generic.IList{char})"/>
        public static string NextString(this System.Random random, int length, IList<char> source) =>
            RandomHelper.NextString(random, length, source);

        /// <inheritdoc cref="NextString(System.Random,int,string)"/>
        public static string NextString(
            System.Random random,
            int length,
            string source = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        ) =>
            RandomHelper.NextString(random, length, source);
    }
}
