using System.Collections.Generic;

namespace LUtil.Collections {
    public class ChainedComparer<T> : IComparer<T> {

        public readonly IComparer<T> First;
        public readonly IComparer<T> Second;
        public readonly IComparer<T> Third;
        public readonly IComparer<T> Fourth;
        public readonly IComparer<T> Fifth;
        public readonly IComparer<T> Sixth;
        public readonly IComparer<T> Seventh;
        public readonly IComparer<T> Eighth;

        #region Constructors

        public ChainedComparer(
            IComparer<T> first
        ) : this(first, null, null, null, null, null, null, null) { }
        public ChainedComparer(
            IComparer<T> first,
            IComparer<T> second
        ) : this(first, second, null, null, null, null, null, null) { }
        public ChainedComparer(
            IComparer<T> first,
            IComparer<T> second,
            IComparer<T> third
        ) : this(first, second, third, null, null, null, null, null) { }
        public ChainedComparer(
            IComparer<T> first,
            IComparer<T> second,
            IComparer<T> third,
            IComparer<T> fourth
        ) : this(first, second, third, fourth, null, null, null, null) { }
        public ChainedComparer(
            IComparer<T> first,
            IComparer<T> second,
            IComparer<T> third,
            IComparer<T> fourth,
            IComparer<T> fifth
        ) : this(first, second, third, fourth, fifth, null, null, null) { }
        public ChainedComparer(
            IComparer<T> first,
            IComparer<T> second,
            IComparer<T> third,
            IComparer<T> fourth,
            IComparer<T> fifth,
            IComparer<T> sixth
        ) : this(first, second, third, fourth, fifth, sixth, null, null) { }
        public ChainedComparer(
            IComparer<T> first,
            IComparer<T> second,
            IComparer<T> third,
            IComparer<T> fourth,
            IComparer<T> fifth,
            IComparer<T> sixth,
            IComparer<T> seventh
        ) : this(first, second, third, fourth, fifth, sixth, seventh, null) { }

        public ChainedComparer(
            IComparer<T> first,
            IComparer<T> second,
            IComparer<T> third,
            IComparer<T> fourth,
            IComparer<T> fifth,
            IComparer<T> sixth,
            IComparer<T> seventh,
            IComparer<T> eighth
        ) {
            First = first;
            Second = second;
            Third = third;
            Fourth = fourth;
            Fifth = fifth;
            Sixth = sixth;
            Seventh = seventh;
            Eighth = eighth;
        }
        #endregion

        public int Compare(T x, T y) {
            int result;
            if ((result = First.Compare(x, y)) != 0 || Second == null)
                return result;
            if ((result = Second.Compare(x, y)) != 0 || Third == null)
                return result;
            if ((result = Third.Compare(x, y)) != 0 || Fourth == null)
                return result;
            if ((result = Fourth.Compare(x, y)) != 0 || Fifth == null)
                return result;
            if ((result = Fifth.Compare(x, y)) != 0 || Sixth == null)
                return result;
            if ((result = Sixth.Compare(x, y)) != 0 || Seventh == null)
                return result;
            if ((result = Seventh.Compare(x, y)) != 0 || Eighth == null)
                return result;
            return Eighth.Compare(x, y);
        }
    }
}
