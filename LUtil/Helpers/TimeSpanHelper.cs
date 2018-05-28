using System;

namespace LUtil.Helpers {
    public static class TimeSpanHelper {
        /// <summary>
        ///     Returns a new <see cref="TimeSpan" /> that multiplies the given
        ///     duration by the amount given.
        /// </summary>
        /// <param name="input">The duration to be multiplied.</param>
        /// <param name="value">The amount to multiply by.</param>
        /// <returns>
        ///     An object whose value is the result of multiplying the given
        ///     duration by the amount given.
        /// </returns>
        public static TimeSpan Multiply( TimeSpan input, double value ) {
            return TimeSpan.FromTicks( (long) ( input.Ticks * value ) );
        }

        /// <summary>
        ///     Returns a new <see cref="TimeSpan" /> that divides the given
        ///     duration by the amount given.
        /// </summary>
        /// <param name="input">The duration to be divided.</param>
        /// <param name="value">The amount to divided by.</param>
        /// <returns>
        ///     An object whose value is the result of dividing the given
        ///     duration by the amount given.
        /// </returns>
        public static TimeSpan Divide( TimeSpan input, double value ) {
            return TimeSpan.FromTicks( (long) ( input.Ticks / value ) );
        }
    }
}
