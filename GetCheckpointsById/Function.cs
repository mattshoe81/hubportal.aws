using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetCheckpointsById;
using Amazon.Lambda.Core;
using Newtonsoft.Json.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace GetCheckpointsById {

    public class Function {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="queryParams"></param>
        /// <param name="context">    </param>
        /// <returns></returns>
        public List<Checkpoint> FunctionHandler(JObject queryParams, ILambdaContext context) {
            context.Logger.LogLine("---New Lambda Call---");
            context.Logger.LogLine($"Input value: {queryParams.ToString()}");
            List<Checkpoint> checkpoints = new List<Checkpoint>();
            for (int k = 0; k < 5; k++) {
                checkpoints.Add(new Checkpoint());
            }

            return checkpoints;
        }
    }
}
