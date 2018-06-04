using System;
using System.Collections.Generic;

namespace LUtil.Helpers.Extensions {
    public static class DictionaryHelperExtensions {
        /// <inheritdoc cref="DictionaryHelper.GetOrDefault{TKey,TValue}(IDictionary{TKey,TValue},TKey,TValue)"/>
        public static TValue GetOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue default_value
        ) =>
            DictionaryHelper.GetOrDefault(dictionary, key, default_value);

        /// <inheritdoc cref="DictionaryHelper.GetOrDefault{TKey,TValue}(IDictionary{TKey,TValue},TKey,Func{TKey,TValue})"/>
        public static TValue GetOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> default_delegate
        ) =>
            DictionaryHelper.GetOrDefault(dictionary, key, default_delegate);

        /// <inheritdoc cref="DictionaryHelper.GetOrNull{TKey,TValue}"/>
        public static TValue GetOrNull<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key
        ) where TValue : class =>
            DictionaryHelper.GetOrNull(dictionary, key);

        /// <inheritdoc cref="DictionaryHelper.GetOrNullable{TKey,TValue}"/>
        public static TValue? GetOrNullable<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key
        ) where TValue : struct =>
            DictionaryHelper.GetOrNullable(dictionary, key);
    }
}
