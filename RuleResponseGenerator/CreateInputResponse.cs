using System.Collections.Generic;

namespace RuleResponseGenerator
{
    public class CreateInputResponse : ICreateInputResponse
    {
        private List<IRule> _rules;

        public CreateInputResponse(List<IRule> rules) {
            _rules = rules ?? new List<IRule>();
        }

        public string GenerateRespone(int v1, int v2) {
            List<string> itemList = new List<string>();
            string resultString;

            for(var i = v1; i <= v2; i++) {
                var output = string.Empty;
                foreach(var rules in _rules) {
                    output += rules.Run(i);
                }

                if(output == string.Empty) {
                    output += new EmptyRule().Run(i);
                }

                itemList.Add(output);
            }

            resultString = string.Join(" ", itemList);

            return resultString;
        }
    }
}