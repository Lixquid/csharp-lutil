using System;
using System.Collections.Generic;

namespace LUtil.Helpers {
    public static class ComparerHelper {
        /// <summary>
        ///     Creates a new <see cref="Comparison{T}"/> delegate that defers
        ///     to the given <see cref="IComparer{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type to be compared.</typeparam>
        /// <param name="comparer">The comparer to delegate to.</param>
        /// <returns>
        ///     A new Comparison delegate that defers to a given comparer.
        /// </returns>
        /// <remarks>
        ///     To create a comparer from a comparison delegate, see
        ///     <see cref="Comparer{T}.Create(Comparison{T})"/>.
        /// </remarks>
        public static Comparison<T> ToComparison<T>(IComparer<T> comparer) =>
            delegate (T x, T y) { return comparer.Compare(x, y); };
    }
}
