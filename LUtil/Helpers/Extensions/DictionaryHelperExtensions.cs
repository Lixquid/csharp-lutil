using System;
using System.Collections.Generic;

namespace LUtil.Helpers.Extensions {
    public static class DictionaryHelperExtensions {
        /// <inheritdoc cref="DictionaryHelper.GetOrDefault{TKey,TValue}(IDictionary{TKey,TValue},TKey)"/>
        public static TValue GetOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key
        ) where TValue : new() =>
            DictionaryHelper.GetOrDefault(dictionary, key);

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

        /// <inheritdoc cref="DictionaryHelper.ToDictionary{TKey,TValue}(System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{TKey,TValue}})"/>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> enumerable
        ) =>
            DictionaryHelper.ToDictionary(enumerable);

        /// <inheritdoc cref="DictionaryHelper.ToDictionary{TKey,TValue}(System.Collections.Generic.IEnumerable{System.Tuple{TKey,TValue}})"/>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<Tuple<TKey, TValue>> enumerable
        ) =>
            DictionaryHelper.ToDictionary(enumerable);

        /// <inheritdoc cref="DictionaryHelper.ToDictionary{TKey,TValue}(System.Collections.Generic.IEnumerable{System.ValueTuple{TKey,TValue}})"/>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<ValueTuple<TKey, TValue>> enumerable
        ) =>
            DictionaryHelper.ToDictionary(enumerable);
    }
}
