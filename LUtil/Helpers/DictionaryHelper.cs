using System;
using System.Collections.Generic;
using System.Linq;
using LUtil.Helpers.Extensions;

namespace LUtil.Helpers {
    public static class DictionaryHelper {
        /// <summary>
        ///     Returns a new Dictionary, whose keys are the values of the input
        ///     dictionary, and values are the keys.
        ///     An <see cref="ArgumentException" /> is thrown if a value appears
        ///     twice in the input Dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary to reverse.</param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>
        ///     A new <see cref="Dictionary{TKey,TValue}" />, with keys and values reversed from the input
        ///     <paramref name="dictionary" />.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown if <paramref name="dictionary" /> contains multiple values that would
        ///     resolve to the same key.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> is <c>null</c>.
        /// </exception>
        /// <example>
        ///     <code><![CDATA[
        ///         var dict = new Dictionary<int, string>{
        ///             [1] = "one", [2] = "two"
        ///         };
        ///         dict.Reverse();
        ///         // = Dictionary<string, int>(2) { { "one", 1 }, { "two", 2 } }
        ///     ]]></code>
        /// </example>
        public static IDictionary<TValue, TKey> Reverse<TKey, TValue>(IDictionary<TKey, TValue> dictionary) {
            dictionary.ThrowIfNull(nameof(dictionary));
            return ToDictionary(dictionary.Select(kp => (kp.Value, kp.Key)));
        }

        /// <summary>
        ///     Returns the value at the specified key if it exists, otherwise
        ///     returns a new object of the key's type.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary to return the value of.
        /// </param>
        /// <param name="key">
        ///     The key to attempt to return from the
        ///     <paramref name="dictionary"/>.
        /// </param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The value at the key of the dictionary if it exists, a new instance of the key's type otherwise.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> is <c>null</c>.
        /// </exception>
        public static TValue GetOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : new() {
            dictionary.ThrowIfNull(nameof(dictionary));
            return dictionary.ContainsKey(key) ? dictionary[key] : new TValue();
        }

        /// <summary>
        ///     Returns the value at the specified key if it exists, otherwise
        ///     returns a default value.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary to return the value of.
        /// </param>
        /// <param name="key">
        ///     The key to attempt to return from the
        ///     <paramref name="dictionary"/>.
        /// </param>
        /// <param name="default_value">
        ///     The default value to return if the key does not exist
        ///     in the <paramref name="dictionary"/>.
        /// </param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The value at the key of the dictionary if it exists, the default value otherwise.</returns>
        /// <remarks>
        ///     Note that the <paramref name="default_value"/> will be shared
        ///     across all calls to this function if
        ///     <typeparamref name="TValue"/> is a reference type. To generate a
        ///     unique default value on each invocation, see
        ///     <see cref="GetOrDefault{TKey,TValue}(IDictionary{TKey,TValue},TKey,Func{TKey,TValue})"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> is <c>null</c>.
        /// </exception>
        public static TValue GetOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key, TValue default_value) {
            dictionary.ThrowIfNull(nameof(dictionary));
            return dictionary.ContainsKey(key) ? dictionary[key] : default_value;
        }

        /// <summary>
        ///     Returns the value at the specified key if it exists, otherwise
        ///     returns the output of the specified default delegate.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary to return the value of.
        /// </param>
        /// <param name="key">
        ///     The key to attempt to return from the
        ///     <paramref name="dictionary"/>.
        /// </param>
        /// <param name="default_delegate">
        ///     The delegate to call to generate the default value if the key
        ///     does not exist in the <paramref name="dictionary"/>.
        /// </param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The value at the key of the dictionary if it exists, the generated default value otherwise.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> or
        ///     <paramref name="default_delegate"/> is <c>null</c>.
        /// </exception>
        public static TValue GetOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key,
            Func<TKey, TValue> default_delegate) {
            dictionary.ThrowIfNull(nameof(dictionary));
            default_delegate.ThrowIfNull(nameof(default_delegate));
            return dictionary.ContainsKey(key) ? dictionary[key] : default_delegate(key);
        }

        /// <summary>
        ///     Returns the value at the specified key if it exists, otherwise
        ///     sets the key to a new instance of the key's type.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary to return the value of and set the value to.
        /// </param>
        /// <param name="key">
        ///     The key to return from the <paramref name="dictionary"/>,
        ///     and set the default value to.
        /// </param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The value at the key of the dictionary if it exists, a new instance of the key's type otherwise.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> is <c>null</c>.
        /// </exception>
        public static TValue GetOrInsert<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key) where TValue : new() {
            dictionary.ThrowIfNull(nameof(dictionary));
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            dictionary[key] = new TValue();
            return dictionary[key];
        }

        /// <summary>
        ///     Returns the value at the specified key if it exists, otherwise
        ///     sets the key to the default object given and returns it.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary to return the value of and set the value to.
        /// </param>
        /// <param name="key">
        ///     The key to return from the <paramref name="dictionary"/>,
        ///     and set the default value to.
        /// </param>
        /// <param name="default_value">
        ///     The default value to set and return if the key does not exist
        ///     in the <paramref name="dictionary"/>.
        /// </param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The value at the key of the dictionary if it exists, the default value otherwise.</returns>
        /// <remarks>
        ///     Note that the <paramref name="default_value"/> will be shared
        ///     across all calls to this function if
        ///     <typeparamref name="TValue"/> is a reference type. To generate a
        ///     unique default value on each invocation, see
        ///     <see cref="GetOrInsert{TKey,TValue}(IDictionary{TKey,TValue},TKey,Func{TKey,TValue})"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> is <c>null</c>.
        /// </exception>
        public static TValue GetOrInsert<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key, TValue default_value) {
            dictionary.ThrowIfNull(nameof(dictionary));
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            dictionary[key] = default_value;
            return default_value;
        }

        /// <summary>
        ///     Returns the value at the specified key if it exists, otherwise
        ///     sets the key to the output of the default delegate and returns it.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary to return the value of and set the value to.
        /// </param>
        /// <param name="key">
        ///     The key to return from the <paramref name="dictionary"/>,
        ///     and set the default value to.
        /// </param>
        /// <param name="default_delegate">
        ///     The delegate to call to generate the default value if the key
        ///     does not exist in the <paramref name="dictionary"/>.
        /// </param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The value at the key of the dictionary if it exists, the generated default value otherwise.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> or
        ///     <paramref name="default_delegate"/> is <c>null</c>.
        /// </exception>
        public static TValue GetOrInsert<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> default_delegate
        ) {
            dictionary.ThrowIfNull(nameof(dictionary));
            default_delegate.ThrowIfNull(nameof(default_delegate));
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            dictionary[key] = default_delegate(key);
            return dictionary[key];
        }

        /// <summary>
        ///     Returns the value at the specified key in the dictionary if it
        ///     exists, otherwise returns <c>null</c>.
        /// </summary>
        /// <param name="dictionary">The dictionary to return the key at.</param>
        /// <param name="key">The key to retrieve the value from in the dictionary.</param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The specified value at the key in the dictionary, <c>null</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> is <c>null</c>.
        /// </exception>
        public static TValue GetOrNull<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key
        ) where TValue : class {
            dictionary.ThrowIfNull(nameof(dictionary));
            return dictionary.ContainsKey(key) ? dictionary[key] : null;
        }

        /// <summary>
        ///     Returns the value at the specified key in the dictionary if it
        ///     exists, otherwise returns <c>null</c>.
        /// </summary>
        /// <param name="dictionary">The dictionary to return the key at.</param>
        /// <param name="key">The key to retrieve the value from in the dictionary.</param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The specified value at the key in the dictionary, <c>null</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="dictionary"/> is <c>null</c>.
        /// </exception>
        public static TValue? GetOrNullable<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key
        ) where TValue : struct {
            dictionary.ThrowIfNull(nameof(dictionary));
            return dictionary.ContainsKey(key) ? (TValue?)dictionary[key] : null;
        }

        /// <summary>
        ///     Converts an enumerable of
        ///     <see cref="KeyValuePair{TKey,TValue}"/>s back into a
        ///     <see cref="Dictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> is <c>null</c>.
        /// </exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            IEnumerable<KeyValuePair<TKey, TValue>> enumerable
        ) {
            enumerable.ThrowIfNull(nameof(enumerable));
            return enumerable.ToDictionary(kp => kp.Key, kp => kp.Value);
        }

        /// <summary>
        ///     Converts an enumerable of
        ///     <see cref="Tuple{T1,T2}"/>s back into a
        ///     <see cref="Dictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> is <c>null</c>.
        /// </exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            IEnumerable<Tuple<TKey, TValue>> enumerable
        ) {
            enumerable.ThrowIfNull(nameof(enumerable));
            return enumerable.ToDictionary(t => t.Item1, t => t.Item2);
        }

        /// <summary>
        ///     Converts an enumerable of
        ///     <see cref="ValueTuple{T1,T2}"/>s back into a
        ///     <see cref="Dictionary{TKey,TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="enumerable"/> is <c>null</c>.
        /// </exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            IEnumerable<ValueTuple<TKey, TValue>> enumerable
        ) {
            enumerable.ThrowIfNull(nameof(enumerable));
            return enumerable.ToDictionary(t => t.Item1, t => t.Item2);
        }
    }
}
