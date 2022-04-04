using Newtonsoft.Json;
using RuleResponseGenerator;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args) {
            Entry result = new Entry();
            var ret = result.CreateResponse("1,20");
            var output =  JsonConvert.SerializeObject(ret, Formatting.Indented);
            Console.WriteLine(output);
        }
    }
}
