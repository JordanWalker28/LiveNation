using NUnit.Framework;

namespace RuleResponseGenerator.Tests
{
    [TestFixture()]
    public class RuleTests
    {
        [Test]
        [TestCase(1, "test1")]
        [TestCase(15, "test15")]
        [TestCase(100000000, "ICanBeAnything")]
        public void GenerateEntryTest(int arg1, string arg2) {
            IRule rule = new Rule(arg1, arg2);
            var result = rule.Run(arg1);
            Assert.AreEqual(result, arg2);
        }
    }
}