using System;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class StringHelperExtensions {
        /// <inheritdoc cref="StringHelper.Contains" />
        [Pure]
        public static bool Contains([NotNull] this string input, [NotNull] string value, StringComparison comparison) =>
            StringHelper.Contains(input, value, comparison);

        /// <inheritdoc cref="StringHelper.Repeat"/>
        [Pure]
        public static string Repeat([NotNull] this string input, int count) =>
            StringHelper.Repeat(input, count);
    }
}
