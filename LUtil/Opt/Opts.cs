using System;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;

namespace LUtil.Opt {
    [PublicAPI]
    public static class Opts {
        public static TOutput Parse<TParser, TOutput>(IEnumerable<string> args) where TParser : IOptParser, new() where TOutput : new() =>
            Parse<TOutput>(new TParser(), args);

        public static TOutput Parse<TOutput>(IOptParser parser, IEnumerable<string> args) where TOutput : new() {
            var output = new TOutput();

            foreach (var kv in parser.Parse(args)) {
                if (kv.Key == null) continue;
                foreach (var field in typeof(TOutput).GetProperties()) {
                    if (field.Name.Equals(kv.Key, parser.KeyComparison)) {
                        if (field.PropertyType == typeof(bool) || field.PropertyType == typeof(bool?)) {
                            field.SetValue(output, kv.Value == null || TruthyString(kv.Value));
                        } else {
                            field.SetValue(output, TypeDescriptor.GetConverter(field.PropertyType).ConvertFromString(kv.Value));
                        }
                    }
                }
            }

            return output;
        }

        private static bool TruthyString(string str) {
            return !str.Equals("false", StringComparison.CurrentCultureIgnoreCase)
                && !str.Equals("no", StringComparison.CurrentCultureIgnoreCase)
                && !str.Equals("off", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
