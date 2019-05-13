using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LUtil.Helpers {
    [PublicAPI]
    public class EnumHelper {

        /// <summary>
        ///     Returns all values an enum can have.
        /// </summary>
        /// <typeparam name="T">
        ///     The enum type to return the values of.
        /// </typeparam>
        public static IEnumerable<T> GetValues<T>() where T : IComparable, IConvertible, IFormattable =>
            Enum.GetValues(typeof(T)).Cast<T>();
    }
}
