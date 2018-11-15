using JetBrains.Annotations;

namespace LUtil.Random {
    /// <summary>
    ///     Contains thread-safe, static methods to return values from the
    ///     default <see cref="System.Random"/> class.
    /// </summary>
    [PublicAPI]
    public static class StaticRandom {
        private static readonly System.Random Random = new System.Random();
        private static readonly object RandomLock = new object();

        /// <inheritdoc cref="System.Random.Next()"/>
        public static int Next() {
            lock (RandomLock)
                return Random.Next();
        }

        /// <inheritdoc cref="System.Random.Next(int)"/>
        public static int Next(int maxValue) {
            lock (RandomLock)
                return Random.Next(maxValue);
        }

        /// <inheritdoc cref="System.Random.Next(int,int)"/>
        public static int Next(int minValue, int maxValue) {
            lock (RandomLock)
                return Random.Next(minValue, maxValue);
        }

        /// <inheritdoc cref="System.Random.NextBytes"/>
        public static void NextBytes(byte[] buffer) {
            lock (RandomLock)
                Random.NextBytes(buffer);
        }

        /// <inheritdoc cref="System.Random.NextDouble"/>
        public static double NextDouble() {
            lock (RandomLock)
                return Random.NextDouble();
        }
    }
}
