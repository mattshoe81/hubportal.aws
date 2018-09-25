using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace GetProcessNames {

    public class Function {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input">  </param>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<string> FunctionHandler(ILambdaContext context) {
            List<string> names = new List<string> { "process 1", "another process", "and another" };
            context.Logger.LogLine($"Process Names: {names}");
            return names;
        }
    }
}
