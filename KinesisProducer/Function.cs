using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace KinesisProducer {

    public class Function {

        private ILambdaContext Context { get; set; }

        /// <summary>
        /// Puts input to kinesis stream
        /// </summary>
        /// <param name="input">  </param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(string input, ILambdaContext context) {
            context.Logger.LogLine($"---NEW RECORD---");
            this.Context = context;
            PutRecordResponse recordResponse = null;
            context.Logger.LogLine($"Beginning to put '{input}' into Kinesis Stream");
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using (MemoryStream ms = new MemoryStream(bytes)) {
                context.Logger.LogLine("Creating Client object");
                //create client that pulls creds from web.config and takes in Kinesis config
                AmazonKinesisClient client = new AmazonKinesisClient(Amazon.RegionEndpoint.USEast1);
                context.Logger.LogLine($"Client Created successfully");
                //create put request
                PutRecordRequest requestRecord = new PutRecordRequest();
                //list name of Kinesis stream
                requestRecord.StreamName = "hubportal-test";
                //give partition key that is used to place record in particular shard
                requestRecord.PartitionKey = "key";
                //add record as memorystream
                requestRecord.Data = ms;
                context.Logger.LogLine("Beginning PutRecord operation");
                recordResponse = await client.PutRecordAsync(requestRecord);
                context.Logger.LogLine($"PutRecord Response Code: {recordResponse.HttpStatusCode} \nShardID: {recordResponse.ShardId}");
                //response = $"Shard ID: {recordResponse.ShardId}, Metadata: {recordResponse.ResponseMetadata}";
            }

            return input;
        }
    }
}
