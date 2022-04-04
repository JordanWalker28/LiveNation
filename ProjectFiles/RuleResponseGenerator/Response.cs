using System.Collections.Generic;
using System.Linq;

namespace RuleResponseGenerator
{
    public class Response
    {
        public string result { get; set; }
        public Dictionary<string, int> summary { get; set; }

        public Response(string result) {
            this.result = result;
            this.summary = CreateSummary(result);
        }

        private Dictionary<string, int> CreateSummary(string result) {

            Dictionary<string, int> dictionaryValues = new Dictionary<string, int>();
            int integerCount = 0;

            List<string> modifiedString = result.Split(' ').ToList();

            foreach (string value in modifiedString) {
                bool isNumber = int.TryParse(value, out int n);

                if (dictionaryValues.ContainsKey(value) && !isNumber) {
                    dictionaryValues[value]++;
                } else {
                    if (isNumber) {
                        integerCount++;
                    } else {
                        dictionaryValues.Add(value, 1);
                    }
                }
            }


            dictionaryValues.Add("Integer", integerCount);


            return dictionaryValues;
        }
    }
}
