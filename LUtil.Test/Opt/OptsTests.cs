using System;
using System.Collections.Generic;
using System.IO;
using LUtil.Opt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Opt {
    [TestClass]
    public class OptsTests {

        #region Test Classes

        private class DebugParser : IOptParser {
            public ICollection<KeyValuePair<string, string>> Parse(IEnumerable<string> args) {
                var output = new List<KeyValuePair<string, string>>();
                string currentKey = null;
                foreach (var arg in args) {
                    switch (arg[0]) {
                        case '?':
                            if (currentKey != null)
                                output.Add(new KeyValuePair<string, string>(currentKey, null));
                            currentKey = arg.Substring(1);
                            break;
                        case ':':
                            output.Add(new KeyValuePair<string, string>(currentKey, arg.Substring(1)));
                            currentKey = arg.Substring(1);
                            break;
                        default:
                            throw new InvalidDataException(arg);
                    }
                }
                if (currentKey != null)
                    output.Add(new KeyValuePair<string, string>(currentKey, null));

                return output;
            }

            public StringComparison KeyComparison => StringComparison.OrdinalIgnoreCase;
        }

        private class OptOutput {
            public string StringArg { get; set; }
            public int IntArg { get; set; }
            public bool BoolArg { get; set; }
            public bool? NullableBoolArg { get; set; }
        }
        #endregion

        [TestMethod]
        public void Parse_Types_Explicit() {
            var output = Opts.Parse<DebugParser, OptOutput>(new[] { "?StringArg", ":Hello", "?IntArg", ":5", "?BoolArg", ":true" });
            Assert.AreEqual("Hello", output.StringArg);
            Assert.AreEqual(5, output.IntArg);
            Assert.IsTrue(output.BoolArg);
        }

        [TestMethod]
        public void Parse_Types_Empty() {
            var output = Opts.Parse<DebugParser, OptOutput>(new string[0]);
            Assert.AreEqual(default(string), output.StringArg);
            Assert.AreEqual(default(int), output.IntArg);
            Assert.AreEqual(default(bool), output.BoolArg);
            Assert.AreEqual(default(bool?), output.NullableBoolArg);
        }

        [TestMethod]
        public void Parse_Types_Flags() {
            var output = Opts.Parse<DebugParser, OptOutput>(new[] { "?BoolArg" });
            Assert.IsTrue(output.BoolArg);
        }

        [TestMethod]
        public void Parse_Types_Falsey() {
            var output = Opts.Parse<DebugParser, OptOutput>(new[] { "?BoolArg", ":off", "?NullableBoolArg", ":false" });
            Assert.IsFalse(output.BoolArg);
            Assert.AreEqual(false, output.NullableBoolArg);
        }
    }
}
