using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace GetTransactionsByQuery {

    public class Function {

        /// <summary>
        /// </summary>
        /// <param name="input">  </param>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<Transaction> FunctionHandler(JObject query, ILambdaContext context) {
            context.Logger.LogLine("---New Lambda Call---");
            context.Logger.LogLine($"Input value: {query.ToString()}");

            string transactionQuery = query["query"].ToString();
            context.Logger.LogLine($"Querying transactions according to: {transactionQuery}");

            List<Transaction> transactions = new List<Transaction>();
            for (int k = 0; k < 5723; k++) {
                transactions.Add(new Transaction());
            }

            return transactions;
        }
    }
}
