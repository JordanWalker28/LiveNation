using NUnit.Framework;
using System.Collections.Generic;

namespace RuleResponseGenerator.Tests
{
    [TestFixture()]
    public class ResponseTests
    {
        private Dictionary<string, int> dict1 = new Dictionary<string, int> {
            { "Integer", 2 }
        };

        private Dictionary<string, int> dict2 = new Dictionary<string, int> {
            {"Live", 1 },{ "Integer", 0 }
        };

        private Dictionary<string, int> dict3 = new Dictionary<string, int> {
            {"Live", 3 },{ "Nation", 2 },{ "Integer", 5 }
        };

        private Dictionary<string, int> dict4 = new Dictionary<string, int> {
            {"Live", 5 },{ "Nation", 3 },{"LiveNation", 1 },{ "Integer", 11 }
        };

        [Test()]
        [TestCase("1 2")]
        public void ResponseTestNumberOnly(string arg1) {
            Response response = new Response(arg1);
            var resultPartA = response.result;
            var resultPartB = response.summary;
            Assert.AreEqual(arg1, resultPartA);
            Assert.AreEqual(dict1, resultPartB);
        }

        [Test()]
        [TestCase("Live")]
        public void ResponseTextSameNumber(string arg1) {
            Response response = new Response(arg1);
            var resultPartA = response.result;
            var resultPartB = response.summary;
            Assert.AreEqual(arg1, resultPartA);
            Assert.AreEqual(dict2, resultPartB);
        }

        [Test()]
        [TestCase("1 2 Live 4 Nation Live 7 8 Live Nation")]
        public void ResponseTextShortRange(string arg1) {
            Response response = new Response(arg1);
            var resultPartA = response.result;
            var resultPartB = response.summary;
            Assert.AreEqual(arg1, resultPartA);
            Assert.AreEqual(dict3, resultPartB);
        }

        [Test()]
        [TestCase("1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation")]
        public void ResponseTextLongerRange(string arg1) {
            Response response = new Response(arg1);
            var resultPartA = response.result;
            var resultPartB = response.summary;
            Assert.AreEqual(arg1, resultPartA);
            Assert.AreEqual(dict4, resultPartB);
        }
    }
}