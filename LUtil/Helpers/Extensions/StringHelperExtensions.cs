using System;

namespace LUtil.Helpers.Extensions {
    public static class StringHelperExtensions {
        /// <inheritdoc cref="StringHelper.Contains" />
        public static bool Contains(this string input, string value, StringComparison comparison) =>
            StringHelper.Contains(input, value, comparison);
    }
}
