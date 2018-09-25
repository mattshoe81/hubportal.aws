using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using Amazon.Lambda.KinesisEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace KinesisConsumer {

    public class Function {

        public async Task<List<string>> FunctionHandler(KinesisEvent kinesisEvent, ILambdaContext context) {
            context.Logger.LogLine($"---NEW RECORD---");
            PutItemResponse response = null;
            DateTime now = DateTime.Now;
            DateTime time = new DateTime(now.Year, now.Month, now.Day, now.Hour - 4, now.Minute, now.Second);
            context.Logger.LogLine($"Beginning to process {kinesisEvent.Records.Count} records...");
            List<string> recordContents = new List<string>();
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
            foreach (KinesisEvent.KinesisEventRecord record in kinesisEvent.Records) {
                string recordData = GetRecordContents(record.Kinesis, context);
                recordContents.Add(recordData);
                Dictionary<string, AttributeValue> item = new Dictionary<string, AttributeValue> {
                    // Just make id random number
                    ["id"] = new AttributeValue { S = ((int)((new Random()).NextDouble() * 10000000.0)).ToString() },
                    ["Time"] = new AttributeValue { S = time.ToString("MM/dd/yyyy hh:mm:ss tt") },
                    ["Shard ID"] = new AttributeValue { S = record.EventId },
                    ["EventName"] = new AttributeValue { S = record.EventName },
                    ["RecordData"] = new AttributeValue { S = recordData }
                };
                PutItemRequest request = new PutItemRequest {
                    TableName = "hubportal-kinesis-test",
                    Item = item
                };
                response = await client.PutItemAsync(request);
            }

            context.Logger.LogLine("Stream processing complete.");

            return recordContents;
        }

        private string GetRecordContents(KinesisEvent.Record streamRecord, ILambdaContext context) {
            context.Logger.LogLine("Reading record contents.");
            string recordContents = "error reading record from stream";
            using (StreamReader reader = new StreamReader(streamRecord.Data, Encoding.ASCII)) {
                recordContents = reader.ReadToEnd();
            }
            if (String.IsNullOrEmpty(recordContents)) recordContents = "Error reading record. Cannot be null or empty";
            context.Logger.LogLine($"Record was read successfully: {recordContents}");
            return recordContents;
        }
    }
}
