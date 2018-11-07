using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LUtil.Helpers.Extensions {
    [PublicAPI]
    public static class ComparerHelperExtensions {
        /// <inheritdoc cref="ComparerHelper.ToComparison{T}(IComparer{T})"/>
        public static Comparison<T> ToComparison<T>([NotNull] this IComparer<T> comparer) =>
            ComparerHelper.ToComparison(comparer);
    }
}
