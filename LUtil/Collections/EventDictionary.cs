using System;
using System.Collections;
using System.Collections.Generic;

namespace LUtil.Collections {
    /// <summary>
    ///     A dictionary implementation that raises events when mutated.
    /// </summary>
    /// <typeparam name="TKey">
    ///     The type of the keys in the dictionary.
    /// </typeparam>
    /// <typeparam name="TValue">
    ///     The type of the values in the dictionary.
    /// </typeparam>
    public class EventDictionary<TKey, TValue> : IDictionary<TKey, TValue> {
        internal readonly Dictionary<TKey, TValue> DictionaryImplementation;

        #region Events

        /// <summary>
        ///     Occurs when an item is successfully set on the Dictionary.
        /// </summary>
        public event EventHandler<KeyValuePair<TKey, TValue>> ItemSet;

        /// <summary>
        ///     Occurs when an item is successfully removed from the Dictionary.
        /// </summary>
        public event EventHandler<KeyValuePair<TKey, TValue>> ItemRemoved;

        /// <summary>
        ///     Occurs when <see cref="Dictionary{TKey,TValue}.Clear" /> is
        ///     called on the Dictionary.
        /// </summary>
        public event EventHandler DictionaryCleared;

        #endregion

        #region Constructors

        /// <inheritdoc cref="Dictionary{TKey,TValue}()" />
        public EventDictionary() {
            DictionaryImplementation = new Dictionary<TKey, TValue>();
        }

        /// <inheritdoc cref="Dictionary{TKey,TValue}(IDictionary{TKey,TValue})" />
        public EventDictionary( IDictionary<TKey, TValue> dictionary ) {
            DictionaryImplementation = new Dictionary<TKey, TValue>( dictionary );
        }

        /// <inheritdoc cref="Dictionary{TKey,TValue}(IDictionary{TKey,TValue}, IEqualityComparer{TKey})" />
        public EventDictionary( IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer ) {
            DictionaryImplementation = new Dictionary<TKey, TValue>( dictionary, comparer );
        }

        /// <inheritdoc cref="Dictionary{TKey,TValue}(IEqualityComparer{TKey})" />
        public EventDictionary( IEqualityComparer<TKey> comparer ) {
            DictionaryImplementation = new Dictionary<TKey, TValue>( comparer );
        }

        /// <inheritdoc cref="Dictionary{TKey,TValue}(int)" />
        public EventDictionary( int capacity ) {
            DictionaryImplementation = new Dictionary<TKey, TValue>( capacity );
        }

        /// <inheritdoc cref="Dictionary{TKey,TValue}(int, IEqualityComparer{TKey})" />
        public EventDictionary( int capacity, IEqualityComparer<TKey> comparer ) {
            DictionaryImplementation = new Dictionary<TKey, TValue>( capacity, comparer );
        }

        #endregion

        #region Evented Methods

        public TValue this[ TKey key ] {
            get => DictionaryImplementation[key];
            set {
                DictionaryImplementation[key] = value;
                ItemSet?.Invoke( this, new KeyValuePair<TKey, TValue>( key, value ) );
            }
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add( KeyValuePair<TKey, TValue> item ) {
            ( (ICollection<KeyValuePair<TKey, TValue>>) DictionaryImplementation ).Add( item );
            ItemSet?.Invoke( this, item );
        }

        public void Clear() {
            DictionaryImplementation.Clear();
            DictionaryCleared?.Invoke( this, null );
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove( KeyValuePair<TKey, TValue> item ) {
            var output = ( (ICollection<KeyValuePair<TKey, TValue>>) DictionaryImplementation ).Remove( item );
            if ( output ) ItemRemoved?.Invoke( this, item );

            return output;
        }

        public void Add( TKey key, TValue value ) {
            DictionaryImplementation.Add( key, value );
            ItemSet?.Invoke( this, new KeyValuePair<TKey, TValue>( key, value ) );
        }

        public bool Remove( TKey key ) {
            DictionaryImplementation.TryGetValue( key, out var removed_value );
            var output = DictionaryImplementation.Remove( key );
            if ( output ) ItemRemoved?.Invoke( this, new KeyValuePair<TKey, TValue>( key, removed_value ) );

            return output;
        }

        #endregion

        #region Non-Evented Methods

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            return DictionaryImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ( (IEnumerable) DictionaryImplementation ).GetEnumerator();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains( KeyValuePair<TKey, TValue> item ) {
            return ( (ICollection<KeyValuePair<TKey, TValue>>) DictionaryImplementation ).Contains( item );
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo( KeyValuePair<TKey, TValue>[] array, int arrayIndex ) {
            ( (ICollection<KeyValuePair<TKey, TValue>>) DictionaryImplementation ).CopyTo( array, arrayIndex );
        }

        public int Count => DictionaryImplementation.Count;

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly =>
            ( (ICollection<KeyValuePair<TKey, TValue>> ) DictionaryImplementation ).IsReadOnly;

        public bool ContainsKey( TKey key ) {
            return DictionaryImplementation.ContainsKey( key );
        }

        public bool TryGetValue( TKey key, out TValue value ) {
            return DictionaryImplementation.TryGetValue( key, out value );
        }

        public ICollection<TKey> Keys => DictionaryImplementation.Keys;

        public ICollection<TValue> Values => DictionaryImplementation.Values;

        #endregion
    }
}
