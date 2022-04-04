using System.Collections.Generic;

namespace RuleResponseGenerator
{
    public interface IResponse
    {
        string result { get; set; }
        Dictionary<string, int> summary { get; set; }
    }
}