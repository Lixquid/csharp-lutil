using System;

namespace LUtil.Helpers {
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
            if (value == null) {
                if (name == null) {
                    throw new ArgumentNullException();
                }

                throw new ArgumentNullException(name);
            }
        }
    }
}
