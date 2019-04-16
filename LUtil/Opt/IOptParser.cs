using System;
using System.Collections.Generic;

namespace LUtil.Opt {
    /// <summary>
    ///     Defines the contract for an argument parser the Opt engine can
    ///     use.
    /// </summary>
    public interface IOptParser {
        /// <summary>
        ///     Converts an argument list into a collection of arguments.
        /// </summary>
        /// <param name="args">The literal arguments to parse.</param>
        /// <returns>
        ///     An ordered list of argument sets.
        ///
        ///     A value of <c>null</c> on a key is considered a bare argument.
        ///     A value of <c>null</c> on a value is considered a set flag with no value.
        /// </returns>
        ICollection<KeyValuePair<string, string>> Parse(IEnumerable<string> args);

        /// <summary>
        ///     The operation to compare key values with for the purposes of
        ///     duplicate / compound arguments.
        /// </summary>
        StringComparison KeyComparison { get; }
    }
}
