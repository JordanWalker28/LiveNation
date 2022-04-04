namespace RuleResponseGenerator
{
    public class Rule : IRule
    {
        private readonly int numberToApplyRule;
        private readonly string ruleText;

        public Rule(int numberToApplyRule, string ruleText) {
            this.numberToApplyRule = numberToApplyRule;
            this.ruleText = ruleText;
        }

        public string Run(double number) {
            return (number % numberToApplyRule) == 0 ? ruleText : string.Empty;
        }
    }
}
