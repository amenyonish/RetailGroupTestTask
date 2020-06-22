using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    public class ComputerInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("computerNane")]
        public string ComputerName { get; set; }

        [JsonProperty("diskCfreeSpace")]
        public long DiskCfreeSpace { get; set; }

        [JsonProperty("updateTimestamp")]
        public DateTime UpdateTimestamp { get; set; }

    }
}
