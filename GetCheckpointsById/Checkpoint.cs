using System;

namespace GetCheckpointsById {
    public class Checkpoint {
        public int CheckpointId { get; set; } = (int)((new Random()).NextDouble() * 10000000.0);

        public int ElapsedTime { get; set; } = (int)((new Random()).NextDouble() * 1000);

        public int ID { get; set; } = (int)((new Random()).NextDouble() * 10000000.0);

        public string Location { get; set; } = "Location";

        public string ServerName { get; set; } = "Name of the server";

        public int Size { get; set; } = (int)((new Random()).NextDouble() * 10000000.0);

        public DateTime? Time { get; set; } = DateTime.Now;

        public string TransactionId { get; set; } = "0101000sd0d0d0023020";

        public string Type { get; set; } = "Checkpoint Type";
    }
}
