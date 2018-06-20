using System;
using System.Collections.Generic;

namespace LUtil.Helpers.Extensions {
    public static class ComparerHelperExtensions {
        /// <inheritdoc cref="ComparerHelper.ToComparison{T}(IComparer{T})"/>
        public static Comparison<T> ToComparison<T>(this IComparer<T> comparer) =>
            ComparerHelper.ToComparison(comparer);
    }
}
