using System.Collections.Generic;
using JetBrains.Annotations;

namespace LUtil.Collections {
    [PublicAPI]
    public class ChainedComparer<T> : IComparer<T> {

        [ItemNotNull]
        private readonly IComparer<T>[] _comparers;
        [NotNull, ItemNotNull]
        public IReadOnlyCollection<IComparer<T>> Comparers => _comparers;

        public ChainedComparer([ItemNotNull] params IComparer<T>[] comparers) {
            _comparers = comparers;
        }

        public int Compare(T x, T y) {
            var result = 0;
            foreach (var comparer in Comparers) {
                result = comparer.Compare(x, y);
                if (result != 0)
                    break;
            }

            return result;
        }
    }
}
