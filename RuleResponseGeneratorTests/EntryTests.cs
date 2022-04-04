using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RuleResponseGenerator.Tests
{
    [TestFixture()]
    public class EntryTests
    {
        private IEntry _entry;
        private Dictionary<string, int> dict;

        [SetUp]
        public void SetUp() {
            _entry = new Entry();
            dict = new Dictionary<string, int> {
                {"Live", 5 },{ "Nation", 3 },{"LiveNation", 1 },{ "Integer", 11 }
            };
        }

        [Test]
        [TestCase("1, a")]
        [TestCase("a, 1")]
        [TestCase("a, b")]
        public void GenerateEntryTest_NonIntegerValues(string arg1) {
            Assert.Throws<ArgumentException>(() => _entry.CreateResponse(arg1));
        }

        [Test]
        public void GenerateEntryTest_HigherFirstInput() {
            Assert.Throws<ArgumentException>(() => _entry.CreateResponse("1,0"));
        }

        [Test]
        public void GenerateEntryTest_NoRangeGiven() {
            Assert.Throws<ArgumentException>(() => _entry.CreateResponse("1"));
        }

        [Test]
        public void GenerateEntryTest_CorrectResult() {
            var setup = _entry.CreateResponse("1,20");
            string result = "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation";
            Assert.AreEqual(result, setup.result);
            Assert.AreEqual(dict, setup.summary);
        }
    }
}