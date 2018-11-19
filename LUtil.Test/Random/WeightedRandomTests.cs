using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LUtil.Test.Random {
    [TestClass]
    public class WeightedRandomTests {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetValues() {
            var r = new LUtil.Random.WeightedRandom<string>(
                new System.Random(),
                ("common", 0.9m), ("uncommon", 0.09m), ("rare", 0.01m)
            );

            const int ITERATION_COUNT = 10000;
            var common = 0;
            var uncommon = 0;
            var rare = 0;

            for (var i = 0; i < ITERATION_COUNT; i++) {
                switch (r.Next()) {
                    case "common":
                        common++;
                        break;
                    case "uncommon":
                        uncommon++;
                        break;
                    case "rare":
                        rare++;
                        break;
                    default:
                        Assert.Fail("Unknown outcome received");
                        return;
                }
            }
            TestContext.WriteLine($"Common 90%: {(float)common / ITERATION_COUNT}, Uncommon 9%: {(float)uncommon / ITERATION_COUNT}, Rare 1%: {(float)rare / ITERATION_COUNT}");
        }
    }
}
