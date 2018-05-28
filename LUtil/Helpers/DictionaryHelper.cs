using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
