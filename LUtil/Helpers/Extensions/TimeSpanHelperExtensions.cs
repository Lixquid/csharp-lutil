using System;

namespace LUtil.Helpers.Extensions {
    public static class TimeSpanHelperExtensions {
        /// <inheritdoc cref="TimeSpanHelper.Multiply(System.TimeSpan,double)" />
        public static TimeSpan Multiply(this TimeSpan input, double value) =>
            TimeSpanHelper.Multiply(input, value);

        /// <inheritdoc cref="TimeSpanHelper.Multiply(System.TimeSpan,long)"/>
        public static TimeSpan Multiply(this TimeSpan input, long value) =>
            TimeSpanHelper.Multiply(input, value);

        /// <inheritdoc cref="TimeSpanHelper.Divide(System.TimeSpan,double)" />
        public static TimeSpan Divide(this TimeSpan input, double value) =>
            TimeSpanHelper.Divide(input, value);

        /// <inheritdoc cref="TimeSpanHelper.Divide(System.TimeSpan,long)"/>
        public static TimeSpan Divide(this TimeSpan input, long value) =>
            TimeSpanHelper.Divide(input, value);

        /// <inheritdoc cref="TimeSpanHelper.Abs"/>
        public static TimeSpan Abs(this TimeSpan input) =>
            TimeSpanHelper.Abs(input);
    }
}
