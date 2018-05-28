using System;

namespace LUtil.Helpers {
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
        public static bool Contains( string input, string value, StringComparison comparison ) {
            return input.IndexOf( value, comparison ) >= 0;
        }
    }
}
