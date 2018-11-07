using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LUtil.Helpers {
    [PublicAPI]
    public static class ObjectHelper {
        /// <summary>
        ///     Throws an <see cref="ArgumentNullException"/> if the given
        ///     <paramref name="value"/> is <c>null</c>.
        /// </summary>
        /// <param name="value">The value to check for <c>null</c>.</param>
        /// <param name="name">
        ///     The name of the argument. This should be passed in via
        ///     <c>nameof</c>.
        /// </param>
        /// <example>
        ///     <code><![CDATA[
        ///     void MethodName(string input) {
        ///         input.ThrowIfNull(nameof(input));
        ///         // ...
        ///     }
        ///     ]]></code>
        ///     This code will throw an <see cref="ArgumentNullException"/> if
        ///     the given <c>input</c> parameter is <c>null</c>.
        /// </example>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static void ThrowIfNull(object value, string name = null) {
            if (value != null) return;

            if (name == null)
                throw new ArgumentNullException();
            throw new ArgumentNullException(name);
        }

        /// <summary>
        ///     Returns a boolean indicating if the given value is equal to any
        ///     of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the checked value.</typeparam>
        /// <param name="source">The value to be tested.</param>
        /// <param name="any">
        ///     The list of values <paramref name="source"/> can be equal to.
        /// </param>
        /// <example>
        ///     <code><![CDATA[
        ///     if (input.EqualTo(1, 2, 4)) {
        ///         // ...
        ///     }
        ///     ]]></code>
        ///     This code will enter the <c>if</c> block if <c>input</c> is
        ///     1, 2, or 4.
        /// </example>
        public static bool EqualTo<T>(T source, params T[] any) {
            return any.Any(x => EqualityComparer<T>.Default.Equals(source, x));
        }
    }
}
