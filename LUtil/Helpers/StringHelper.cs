using System;
using JetBrains.Annotations;
using LUtil.Helpers.Extensions;

namespace LUtil.Helpers {
    [PublicAPI]
    public static class StringHelper {
        /// <summary>
        ///     Returns a value indicating whether a specified substring occurs
        ///     within this string. Accepts a <see cref="StringComparison" />
        ///     search option.
        /// </summary>
        /// <param name="input">The string to search.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="comparison">The Comparison option to use.</param>
        /// <returns>
        ///     <c>true</c> if the <paramref name="value" /> parameter occurs
        ///     within this string, or if <paramref name="value" /> is the empty
        ///     string (""); otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="input"/> or
        ///     <paramref name="value"/> is <c>null</c>.
        /// </exception>
        [Pure]
        public static bool Contains([NotNull] string input, [NotNull] string value, StringComparison comparison) {
            input.ThrowIfNull(nameof(input));
            value.ThrowIfNull(nameof(value));
            return input.IndexOf(value, comparison) >= 0;
        }
    }
}
