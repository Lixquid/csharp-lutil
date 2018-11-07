using System;
using System.Security.Cryptography;
using JetBrains.Annotations;
using LUtil.Helpers.Extensions;

namespace LUtil.Random {
    [PublicAPI]
    public class RNGRandom : System.Random {
        private RandomNumberGenerator Source { get; }

        /// <summary>
        ///     Creates a new RNGRandom using the specified
        ///     <see cref="RandomNumberGenerator"/> source.
        /// </summary>
        /// <param name="source">The Random source to use.</param>
        public RNGRandom([NotNull] RandomNumberGenerator source) {
            source.ThrowIfNull(nameof(source));
            Source = source;
        }

        /// <inheritdoc cref="System.Random.Sample"/>
        protected override double Sample() {
            var buffer = new byte[8];
            Source.GetBytes(buffer);
            // Grab the 53 bits of integer precision (max value, 2^53 - 1),
            // divide by 2^53.
            // Ensures 0 <= ( 2^53 - 1 ) / 2^53 < 1
            return (double)(BitConverter.ToUInt64(buffer, 0) >> 11) / (1UL << 53);
        }

        /// <inheritdoc cref="System.Random.NextDouble"/>
        public override double NextDouble() => Sample();
        /// <inheritdoc cref="System.Random.NextBytes"/>
        public override void NextBytes(byte[] buffer) => Source.GetBytes(buffer);
        /// <inheritdoc cref="System.Random.Next()"/>
        public override int Next() => (int)(Sample() * int.MaxValue);
        /// <inheritdoc cref="System.Random.Next(int)"/>
        public override int Next(int maxValue) => (int)(Sample() * maxValue);
        /// <inheritdoc cref="System.Random.Next(int,int)"/>
        public override int Next(int minValue, int maxValue) =>
            (int)(Sample() * (maxValue - minValue) + minValue);

    }
}
