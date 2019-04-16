using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace LUtil.Opt {
    [PublicAPI]
    public sealed class PowershellParser : IOptParser {
        public ICollection<KeyValuePair<string, string>> Parse(IEnumerable<string> args) {
            var output = new List<KeyValuePair<string, string>>();
            string currentFlag = null;
            var parsingOff = false;

            foreach (var arg in args) {
                if (string.IsNullOrWhiteSpace(arg)) continue;
                if (parsingOff) {
                    output.Add(new KeyValuePair<string, string>(null, arg));
                } else if (arg[0] == '-') {
                    if (arg == "--") {
                        parsingOff = true;
                    } else if (currentFlag != null) {
                        output.Add(new KeyValuePair<string, string>(currentFlag, null));
                    }

                    currentFlag = arg.Substring(1);
                } else {
                    output.Add(new KeyValuePair<string, string>(currentFlag, arg));
                    currentFlag = null;
                }
            }
            if (currentFlag != null)
                output.Add(new KeyValuePair<string, string>(currentFlag, null));

            return output;
        }

        public StringComparison KeyComparison => StringComparison.CurrentCultureIgnoreCase;
    }
}
