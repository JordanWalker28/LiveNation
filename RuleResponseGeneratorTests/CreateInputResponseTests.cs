using NUnit.Framework;
using System.Collections.Generic;

namespace RuleResponseGenerator.Tests
{
    [TestFixture()]
    public class CreateInputResponseTests
    {
        private List<IRule> _rules;
        private List<IRule> _rules2;


        [SetUp]
        public void SetUp() {
            _rules = new List<IRule> { new Rule(3, "Live"), new Rule(5, "Nation") };
            _rules2 = new List<IRule> { new Rule(3, "Test"), new Rule(5, "System") };
        }

        [Test]
        [TestCase(1, 2, "1 2")]
        [TestCase(3, 3, "Live")]
        [TestCase(1, 10, "1 2 Live 4 Nation Live 7 8 Live Nation")]
        [TestCase(1, 20, "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation")]
        public void GenerateResponeTest(int arg1, int arg2, string response) {
            var result = new CreateInputResponse(_rules).GenerateRespone(arg1, arg2);
            Assert.AreEqual(result, response);
        }

        [Test]
        [TestCase(1, 2, "1 2")]
        [TestCase(3, 3, "Test")]
        [TestCase(1, 10, "1 2 Test 4 System Test 7 8 Test System")]
        [TestCase(1, 20, "1 2 Test 4 System Test 7 8 Test System 11 Test 13 14 TestSystem 16 17 Test 19 System")]
        public void GenerateResponeTest_NewRules(int arg1, int arg2, string response) {
            var result = new CreateInputResponse(_rules2).GenerateRespone(arg1, arg2);
            Assert.AreEqual(result, response);
        }
    }
}