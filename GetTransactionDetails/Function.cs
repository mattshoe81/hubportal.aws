using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace GetTransactionDetails {

    public class Function {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input">  </param>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<TransactionDetail> FunctionHandler(JObject queryParams, ILambdaContext context) {
            context.Logger.LogLine("---New Lambda Call---");
            context.Logger.LogLine($"Input value: {queryParams.ToString()}");
            List<TransactionDetail> details = new List<TransactionDetail>();
            for (int k = 0; k < 5; k++) {
                details.Add(new TransactionDetail());
            }

            return details;
        }
    }
}
