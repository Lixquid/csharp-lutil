using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace LUtil.Helpers.Extensions {
    public static class DictionaryHelperExtensions {
        /// <inheritdoc cref="DictionaryHelper.GetOrDefault{TKey,TValue}(System.Collections.Generic.IDictionary{TKey,TValue},TKey,TValue)"/>
        public static TValue GetOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue default_value
        ) => DictionaryHelper.GetOrDefault( dictionary, key, default_value );

        /// <inheritdoc cref="DictionaryHelper.GetOrDefault{TKey,TValue}(System.Collections.Generic.IDictionary{TKey,TValue},TKey,Func{TKey,TValue})"/>
        public static TValue GetOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> default_delegate
        ) => DictionaryHelper.GetOrDefault( dictionary, key, default_delegate );
    }
}
