using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetTransactionsByQuery {

    public class Transaction {

        [JsonProperty("checkpointCount")]
        public int CheckpointCount { get; set; } = (int)((new Random()).NextDouble() * 10.0);

        [JsonProperty("clientName1")]
        public string ClientName1 { get; set; } = "Client Name 1";

        [JsonProperty("clientName2")]
        public string ClientName2 { get; set; } = "Client Name 2";

        [JsonProperty("pingFlag")]
        public string PingFlag { get; set; } = "fjdkasl";

        [JsonProperty("processName")]
        public string ProcessName { get; set; } = "Process Name";

        [JsonProperty("successful")]
        public string Successful { get; set; } = "N";

        [JsonProperty("totalElapsedTime")]
        public decimal? TotalElapsedTime { get; set; } = (decimal?)((new Random()).NextDouble() * 100000);

        [JsonProperty("transactionCompleted")]
        public bool? TransactionCompleted { get; set; } = false;

        [JsonProperty("transactionId")]
        public string TransactionID { get; set; } = "90f90dsgf89d67d98sg98fd";

        [JsonProperty("transactionTime")]
        public DateTime? TransactionTime { get; set; } = DateTime.Now;

        [JsonProperty("transactionTypeName")]
        public string TransactionTypeName { get; set; } = "Name of the transaction type";

        [JsonProperty("url")]
        public string Url { get; set; } = "https://theurlofthething.com";
    }
}
