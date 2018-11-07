using System;
using JetBrains.Annotations;

namespace LUtil.Helpers {
    [PublicAPI]
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
        [Pure]
        public static TimeSpan Multiply(TimeSpan input, double value) =>
            TimeSpan.FromTicks((long)(input.Ticks * value));

        /// <inheritdoc cref="Multiply(System.TimeSpan,double)"/>
        [Pure]
        public static TimeSpan Multiply(TimeSpan input, long value) =>
            TimeSpan.FromTicks(input.Ticks * value);

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
        [Pure]
        public static TimeSpan Divide(TimeSpan input, double value) =>
            TimeSpan.FromTicks((long)(input.Ticks / value));

        /// <inheritdoc cref="Divide(System.TimeSpan,double)"/>
        [Pure]
        public static TimeSpan Divide(TimeSpan input, long value) =>
            TimeSpan.FromTicks(input.Ticks / value);

        /// <summary>
        ///     Negates a <see cref="TimeSpan"/> if it has a negative value.
        /// </summary>
        /// <param name="input">
        ///     The duration to gain the absolute value for.
        /// </param>
        /// <returns>
        ///     The given <see cref="TimeSpan"/> if it has a positive value,
        ///     a new one with a negated value if it has a negative value.
        /// </returns>
        [Pure]
        public static TimeSpan Abs(TimeSpan input) =>
            input.Ticks < 0 ? input.Negate() : input;
    }
}
