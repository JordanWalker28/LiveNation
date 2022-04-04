using NUnit.Framework;

namespace RuleResponseGenerator.Tests
{
    [TestFixture()]
    public class EmptyRuleTests
    {
        [Test]
        [TestCase(1, "1")]
        [TestCase(15, "15")]
        public void GenerateEntryTest(int arg1, string arg2) {
            EmptyRule rule = new EmptyRule();
            var result = rule.Run(arg1);
            Assert.AreEqual(result, arg2);
        }
    }
}