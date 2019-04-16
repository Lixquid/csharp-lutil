using System.Collections.Generic;
using System.Linq;
using LUtil.Opt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Opt {
    [TestClass]
    public class PowershellParserTests {
        private static KeyValuePair<string, string> KV(string key, string value) =>
            new KeyValuePair<string, string>(key, value);

        [TestMethod]
        public void Parse_Args() {
            CollectionAssert.AreEqual(new[] {
                KV(null, "a"), KV(null, "b"), KV(null, "c")
            }, new PowershellParser().Parse(new[] {
                "a", "b", "c"
            }).ToList());
        }

        [TestMethod]
        public void Parse_Opts() {
            CollectionAssert.AreEqual(new[] {
                KV("one", "1"), KV("two", "2")
            }, new PowershellParser().Parse(new[] {
                "-one", "1", "-two", "2"
            }).ToList());
        }

        [TestMethod]
        public void Parse_Switches() {
            CollectionAssert.AreEqual(new[] {
                KV("bool", null), KV("flag", null)
            }, new PowershellParser().Parse(new[] {
                "-bool", "-flag"
            }).ToList());
        }

        [TestMethod]
        public void Parse_Compound() {
            CollectionAssert.AreEqual(new[] {
                KV("switch", null), KV("opt", "value"), KV(null, "arg")
            }, new PowershellParser().Parse(new[] {
                "-switch", "-opt", "value", "arg"
            }).ToList());
        }
    }
}
