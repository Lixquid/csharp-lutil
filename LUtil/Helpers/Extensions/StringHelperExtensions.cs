using System;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class StringHelperExtensions {
        /// <inheritdoc cref="StringHelper.Contains" />
        [Pure]
        public static bool Contains([NotNull] this string input, [NotNull] string value, StringComparison comparison) =>
            StringHelper.Contains(input, value, comparison);
    }
}
