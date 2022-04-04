using System;
using System.Collections.Generic;

namespace RuleResponseGenerator
{
    public class Entry: IEntry
    {
        public Response CreateResponse(string arg) {

            if (!arg.Contains(",")) {
                throw new ArgumentException("Parameter input was incorrect. Invalid range was given \n To use this api add /number,number at the end of the URL e.g. https://localhost:44393/LiveNationAPI/1,20");
            }

            var sanitise = arg.Split(',');
            bool arg1 = int.TryParse(sanitise[0], out int firstArgument);
            bool arg2 = int.TryParse(sanitise[1], out int secondArgument);

            if(!arg1 || !arg2) {
                throw new ArgumentException("Parameter input was incorrect. Your first argument was " + firstArgument + " and your second " + secondArgument
                    + "\n To use this api add /number,number at the end of the URL e.g. https://localhost:44393/LiveNationAPI/1,20");
            }

            if (firstArgument > secondArgument) {
                throw new ArgumentException("Second argument must be greater than the first \n To use this api add /number,number at the end of the URL e.g. https://localhost:44393/LiveNationAPI/1,20");
            }


            var rules = new List<IRule> { new Rule(3, "Live"), new Rule(5, "Nation") };

            ICreateInputResponse inputResponse = new CreateInputResponse(rules);
            string result = inputResponse.GenerateRespone(firstArgument, secondArgument);

            return new Response(result);
        }
    }
}
