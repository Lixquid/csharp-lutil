using System;

namespace LUtil.Helpers.Extensions {
    public static class TimeSpanHelperExtensions {
        /// <inheritdoc cref="TimeSpanHelper.Multiply" />
        public static TimeSpan Multiply( this TimeSpan input, double value ) {
            return TimeSpanHelper.Multiply( input, value );
        }

        /// <inheritdoc cref="TimeSpanHelper.Divide" />
        public static TimeSpan Divide( this TimeSpan input, double value ) {
            return TimeSpanHelper.Divide( input, value );
        }
    }
}
