using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LUtil.Helpers;

namespace LUtil.Collections {
    public class DoubleDict<TForward, TBackward> : IDictionary<TForward, TBackward> {
        private readonly EventDictionary<TBackward, TForward> _backwardInternal;
        private readonly EventDictionary<TForward, TBackward> _forwardInternal;
        public IDictionary<TForward, TBackward> Forward => _forwardInternal;
        public IDictionary<TBackward, TForward> Backward => _backwardInternal;

        #region Added Events

        private void AddEvents() {
            _forwardInternal.ItemSet += (sender, kp) => _backwardInternal.RawSet(kp.Value, kp.Key);
            _backwardInternal.ItemSet += (sender, kp) => _forwardInternal.RawSet(kp.Value, kp.Key);
            _forwardInternal.ItemRemoved += (sender, kp) => _backwardInternal.RawRemove(kp.Value);
            _backwardInternal.ItemRemoved += (sender, kp) => _forwardInternal.RawRemove(kp.Value);
            _forwardInternal.ItemsCleared += (sender, _) => _backwardInternal.RawClear();
            _backwardInternal.ItemsCleared += (sender, _) => _forwardInternal.RawClear();
        }

        #endregion

        #region Constructors

        /// <inheritdoc cref="EventDictionary{TKey,TValue}()" />
        public DoubleDict() {
            _forwardInternal = new EventDictionary<TForward, TBackward>();
            _backwardInternal = new EventDictionary<TBackward, TForward>();
            AddEvents();
        }

        /// <inheritdoc cref="EventDictionary{TKey,TValue}( IDictionary{TKey,TValue} )" />
        /// <remarks>
        ///     <c>DoubleDict</c> only accepts an existing dictionary that
        ///     maps forwards (<typeparamref name="TForward" /> to
        ///     <typeparamref name="TBackward" />), to avoid ambiguity in the
        ///     cases where <typeparamref name="TForward" /> is the same type
        ///     as <typeparamref name="TBackward" />. To initialize with a
        ///     backwards mapping Dictionary, reverse it with
        ///     <see cref="DictionaryHelper.Reverse{TKey,TValue}" /> first.
        /// </remarks>
        public DoubleDict(IDictionary<TForward, TBackward> dictionary) {
            _forwardInternal = new EventDictionary<TForward, TBackward>(dictionary);
            _backwardInternal = new EventDictionary<TBackward, TForward>(DictionaryHelper.Reverse(dictionary));
            AddEvents();
        }

        /// <inheritdoc cref="EventDictionary{TKey,TValue}( IDictionary{TKey,TValue}, IEqualityComparer{TKey} )" />
        /// <param name="forwardComparer">
        ///     The comparer to use for the forward-pointing keys.
        /// </param>
        /// <param name="backwardComparer">
        ///     The comparer to use for the backwards-pointing keys.
        /// </param>
        public DoubleDict(IDictionary<TForward, TBackward> dictionary, IEqualityComparer<TForward> forwardComparer,
            IEqualityComparer<TBackward> backwardComparer) {
            _forwardInternal = new EventDictionary<TForward, TBackward>(dictionary, forwardComparer);
            _backwardInternal =
                new EventDictionary<TBackward, TForward>(DictionaryHelper.Reverse(dictionary), backwardComparer);
            AddEvents();
        }

        /// <inheritdoc cref="EventDictionary{TKey,TValue}( IEqualityComparer{TKey} )" />
        /// <param name="forwardComparer">
        ///     The comparer to use for the forward-pointing keys.
        /// </param>
        /// <param name="backwardComparer">
        ///     The comparer to use for the backwards-pointing keys.
        /// </param>
        public DoubleDict(IEqualityComparer<TForward> forwardComparer,
            IEqualityComparer<TBackward> backwardComparer) {
            _forwardInternal = new EventDictionary<TForward, TBackward>(forwardComparer);
            _backwardInternal = new EventDictionary<TBackward, TForward>(backwardComparer);
            AddEvents();
        }

        /// <inheritdoc cref="EventDictionary{TKey,TValue}( int )" />
        public DoubleDict(int capacity) {
            _forwardInternal = new EventDictionary<TForward, TBackward>(capacity);
            _backwardInternal = new EventDictionary<TBackward, TForward>(capacity);
            AddEvents();
        }

        /// <inheritdoc cref="EventDictionary{TKey,TValue}( int, IEqualityComparer{TKey} )" />
        /// <param name="forwardComparer">
        ///     The comparer to use for the forward-pointing keys.
        /// </param>
        /// <param name="backwardComparer">
        ///     The comparer to use for the backwards-pointing keys.
        /// </param>
        public DoubleDict(int capacity, IEqualityComparer<TForward> forwardComparer,
            IEqualityComparer<TBackward> backwardComparer) {
            _forwardInternal = new EventDictionary<TForward, TBackward>(capacity, forwardComparer);
            _backwardInternal = new EventDictionary<TBackward, TForward>(capacity, backwardComparer);
            AddEvents();
        }

        #endregion

        #region Methods

        public IEnumerator<KeyValuePair<TForward, TBackward>> GetEnumerator() {
            return _forwardInternal.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)_forwardInternal).GetEnumerator();
        }

        void ICollection<KeyValuePair<TForward, TBackward>>.Add(KeyValuePair<TForward, TBackward> item) {
            ((ICollection<KeyValuePair<TForward, TBackward>>)_forwardInternal).Add(item);
        }

        public void Clear() {
            _forwardInternal.Clear();
        }

        public bool Contains(KeyValuePair<TForward, TBackward> item) {
            return _forwardInternal.Contains(item);
        }

        void ICollection<KeyValuePair<TForward, TBackward>>.CopyTo(KeyValuePair<TForward, TBackward>[] array,
            int arrayIndex) {
            ((ICollection<KeyValuePair<TForward, TBackward>>)_forwardInternal).CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<TForward, TBackward>>.Remove(KeyValuePair<TForward, TBackward> item) {
            return ((ICollection<KeyValuePair<TForward, TBackward>>)_forwardInternal).Remove(item);
        }

        public int Count => _forwardInternal.Count;

        bool ICollection<KeyValuePair<TForward, TBackward>>.IsReadOnly =>
            ((ICollection<KeyValuePair<TForward, TBackward>>)_forwardInternal).IsReadOnly;

        public void Add(TForward key, TBackward value) {
            _forwardInternal.Add(key, value);
        }

        public void Add(TBackward key, TForward value) {
            _backwardInternal.Add(key, value);
        }

        public bool ContainsKey(TForward key) {
            return _forwardInternal.ContainsKey(key);
        }

        public bool ContainsKey(TBackward key) {
            return _backwardInternal.ContainsKey(key);
        }

        public bool Remove(TForward key) {
            return _forwardInternal.Remove(key);
        }

        public bool Remove(TBackward key) {
            return _backwardInternal.Remove(key);
        }

        public bool TryGetValue(TForward key, out TBackward value) {
            return _forwardInternal.TryGetValue(key, out value);
        }

        public bool TryGetValue(TBackward key, out TForward value) {
            return _backwardInternal.TryGetValue(key, out value);
        }

        public TBackward this[TForward key] {
            get => _forwardInternal[key];
            set => _forwardInternal[key] = value;
        }

        public TForward this[TBackward key] {
            get => _backwardInternal[key];
            set => _backwardInternal[key] = value;
        }

        public ICollection<TForward> Keys => _forwardInternal.Keys;

        public ICollection<TBackward> Values => _forwardInternal.Values;

        #endregion
    }
}
