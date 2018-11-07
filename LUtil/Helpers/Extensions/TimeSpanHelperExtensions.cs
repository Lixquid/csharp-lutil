using System;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class TimeSpanHelperExtensions {
        [Pure]
        /// <inheritdoc cref="TimeSpanHelper.Multiply(System.TimeSpan,double)" />
        public static TimeSpan Multiply(this TimeSpan input, double value) =>
            TimeSpanHelper.Multiply(input, value);

        /// <inheritdoc cref="TimeSpanHelper.Multiply(System.TimeSpan,long)"/>
        [Pure]
        public static TimeSpan Multiply(this TimeSpan input, long value) =>
            TimeSpanHelper.Multiply(input, value);

        /// <inheritdoc cref="TimeSpanHelper.Divide(System.TimeSpan,double)" />
        [Pure]
        public static TimeSpan Divide(this TimeSpan input, double value) =>
            TimeSpanHelper.Divide(input, value);

        /// <inheritdoc cref="TimeSpanHelper.Divide(System.TimeSpan,long)"/>
        [Pure]
        public static TimeSpan Divide(this TimeSpan input, long value) =>
            TimeSpanHelper.Divide(input, value);

        /// <inheritdoc cref="TimeSpanHelper.Abs"/>
        [Pure]
        public static TimeSpan Abs(this TimeSpan input) =>
            TimeSpanHelper.Abs(input);
    }
}
