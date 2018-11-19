using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LUtil.Helpers.Extensions;

namespace LUtil.Random {
    /// <summary>
    ///     A weighted Random outcome source.
    /// </summary>
    /// <typeparam name="T">The type of outputs to generate.</typeparam>
    [PublicAPI]
    public class WeightedRandom<T> {
        private readonly System.Random _source;
        /// <summary>
        ///     The list of possible outcomes to generate.
        /// </summary>
        public readonly IReadOnlyList<Outcome> Outcomes;
        private readonly decimal _maximum;

        /// <summary>
        ///     Creates a new weighted Random outcome source, using the default
        ///     pseudo-random number generator built into .NET
        /// </summary>
        /// <param name="outcomes">
        ///     The list of outcomes to generate, in addition to their chances.
        ///     Chances do not have to add up to 1, but must be less than or
        ///     equal to <see cref="decimal.MaxValue"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="outcomes"/> contains no items.
        /// </exception>
        public WeightedRandom([NotNull] params Outcome[] outcomes) : this(new System.Random(), outcomes) { }
        /// <summary>
        ///     Creates a new weighted Random outcome source.
        /// </summary>
        /// <param name="source">
        ///     The random number generator source.
        /// </param>
        /// <param name="outcomes">
        ///     The list of outcomes to generate, in addition to their chances.
        ///     Chances do not have to add up to 1, but must be less than or
        ///     equal to <see cref="decimal.MaxValue"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="outcomes"/> contains no items.
        /// </exception>
        public WeightedRandom([NotNull] System.Random source, [NotNull] params Outcome[] outcomes) {
            source.ThrowIfNull(nameof(source));
            outcomes.ThrowIfNull(nameof(outcomes));

            if (outcomes.Length == 0)
                throw new ArgumentException("Outcome source must contain at least one outcome", nameof(outcomes));

            _source = source;
            Outcomes = outcomes.ToList().AsReadOnly();
            _maximum = Outcomes.Select(o => o.Chance).Sum();
        }

        /// <summary>
        ///     Returns a random outcome from the possible outcomes.
        /// </summary>
        public T Next() {
            var result = (decimal)_source.Next() / int.MaxValue * _maximum;
            var baseline = 0m;
            foreach (var outcome in Outcomes) {
                baseline += outcome.Chance;
                if (result < baseline)
                    return outcome.Value;
            }
            throw new ArithmeticException("Random result exceeded outcome total");
        }

        /// <summary>
        ///     A possible outcome that can be generated, as well as its chance
        ///     of occurring.
        /// </summary>
        public struct Outcome {
            /// <summary>
            ///     The chance of this outcome being returned. Higher chances
            ///     are more likely, and are strictly linear compared to other
            ///     outcomes: an outcome with chance 0.9 is nine times more
            ///     more to be returned than an outcome with chance 0.1
            /// </summary>
            public readonly decimal Chance;
            /// <summary>
            ///     The value this outcome will return.
            /// </summary>
            public readonly T Value;

            /// <summary>
            ///     Creates a new potential weighted random outcome.
            /// </summary>
            /// <param name="value">
            ///     The value the weighted random sample will return.
            /// </param>
            /// <param name="chance">
            ///     The weighted chance of this outcome being returned.
            /// </param>
            public Outcome(T value, decimal chance) {
                Value = value;
                Chance = chance;
            }

            public static implicit operator Outcome((T, decimal) tuple) =>
                new Outcome(tuple.Item1, tuple.Item2);
        }
    }
}
