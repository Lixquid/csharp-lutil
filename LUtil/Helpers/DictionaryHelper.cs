using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

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
        public static IDictionary<TValue, TKey> Reverse<TKey, TValue>( IDictionary<TKey, TValue> dictionary ) {
            return dictionary.Select( kp => ( kp.Value, kp.Key ) )
                .ToDictionary( kp => kp.Item1, kp => kp.Item2 );
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
        public static TValue GetOrDefault<TKey, TValue>( IDictionary<TKey, TValue> dictionary, TKey key, TValue default_value ) {
            if ( dictionary.ContainsKey( key ) )
                return dictionary[ key];
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
        public static TValue GetOrDefault<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> default_delegate
        ) {
            if ( dictionary.ContainsKey( key ) )
                return dictionary[key];
            dictionary[key] = default_delegate( key );
            return dictionary[key];
        }

        /// <summary>
        ///     Returns the value at the specified key in the dictionary if it
        ///     exists, otherwise returns <c>null</c>.
        /// </summary>
        /// <param name="dictionary">The dictionary to return the key at.</param>
        /// <param name="key">The key to retreive the value from in the dictionary.</param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The specified value at he key in the dictionary, <c>null</c> otherwise.</returns>
        public static TValue GetOrNull<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key
        ) where TValue : class {
            return dictionary.ContainsKey( key ) ? dictionary[key] : null;
        }

        /// <summary>
        ///     Returns the value at the specified key in the dictionary if it
        ///     exists, otherwise returns <c>null</c>.
        /// </summary>
        /// <param name="dictionary">The dictionary to return the key at.</param>
        /// <param name="key">The key to retreive the value from in the dictionary.</param>
        /// <typeparam name="TKey">The type of the keys of the Dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values of the Dictionary.</typeparam>
        /// <returns>The specified value at he key in the dictionary, <c>null</c> otherwise.</returns>
        public static TValue? GetOrNullable<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key
        ) where TValue : struct {
            return dictionary.ContainsKey( key ) ? (TValue?)dictionary[key] : null;
        }
    }
}
