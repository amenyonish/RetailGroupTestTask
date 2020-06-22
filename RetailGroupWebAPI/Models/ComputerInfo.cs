using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailGroupWebAPI.Models
{
    public class ComputerInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("computerNane")]
        public string ComputerName { get; set; }

        [JsonProperty("diskCfreeSpace")]
        public long? FreeSpace { get; set; }

        [JsonProperty("updateTimestamp")]
        public DateTime? Timestamp { get; set; }
    }
}
