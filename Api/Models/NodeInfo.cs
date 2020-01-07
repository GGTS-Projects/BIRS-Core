using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class NodeInfo
    {
        [JsonProperty("nodeId")]
        public string NodeId { get; set; }

        [JsonProperty("currentBlockHeight")]
        public long CurrentBlockHeight { get; set; }
    }
}
