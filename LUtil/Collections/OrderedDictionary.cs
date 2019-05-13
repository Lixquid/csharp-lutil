using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LUtil.Collections {
    public class OrderedDictionary<TKey, TValue> : IDictionary<TKey, TValue> {
        private IDictionary<TKey, TValue> _dictionary { get; }
        private IList<KeyValuePair<TKey, TValue>> _pairs { get; }

        public OrderedDictionary() : this(0) { }
        public OrderedDictionary(int capacity) : this(capacity, null) { }
        public OrderedDictionary(IEqualityComparer<TKey> comparer) : this(0, comparer) { }
        public OrderedDictionary(int capacity, IEqualityComparer<TKey> comparer) {
            _dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
            _pairs = new List<KeyValuePair<TKey, TValue>>(capacity);
        }
        public OrderedDictionary([NotNull, InstantHandle] IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : this(collection, null) { }

        public OrderedDictionary(
            [NotNull, InstantHandle] IEnumerable<KeyValuePair<TKey, TValue>> collection,
            IEqualityComparer<TKey> comparer
        ) {
            collection = collection.ToList();
            _pairs = collection.ToList();
            _dictionary = collection.ToDictionary(kv => kv.Key, kv => kv.Value, comparer);
        }

        #region Implementation of IEnumerable

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _pairs.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Implementation of ICollection<KeyValuePair<TKey,TValue>>

        public void Add(KeyValuePair<TKey, TValue> item) {
            _dictionary.Add(item);
            _pairs.Add(item);
        }

        public void Clear() {
            _dictionary.Clear();
            _pairs.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) => _dictionary.Contains(item);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _dictionary.CopyTo(array, arrayIndex);

        public bool Remove(KeyValuePair<TKey, TValue> item) {
            _dictionary.Remove(item);
            return _pairs.Remove(item);
        }

        public int Count => _dictionary.Count;
        public bool IsReadOnly => _dictionary.IsReadOnly;

        #endregion

        #region Implementation of IDictionary<TKey,TValue>

        public void Add(TKey key, TValue value) {
            _dictionary.Add(key, value);
            _pairs.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);

        public bool Remove(TKey key) {
            if (!_dictionary.TryGetValue(key, out var value))
                return false;
            _dictionary.Remove(key);
            return _pairs.Remove(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool TryGetValue(TKey key, out TValue value) => _dictionary.TryGetValue(key, out value);

        public TValue this[TKey key] {
            get => _dictionary[key];
            set => Add(key, value);
        }

        public ICollection<TKey> Keys => _pairs.Select(p => p.Key).ToList();
        public ICollection<TValue> Values => _pairs.Select(p => p.Value).ToList();

        #endregion
    }
}
