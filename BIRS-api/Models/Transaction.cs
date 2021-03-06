﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIRS_api.Models
{
    public class Transaction
    {
        public Transaction(Guid pId, long pTimestamp, string pPayload)
        {
            Id = pId;
            Timestamp = pTimestamp;
            Payload = pPayload;
        }

        [JsonProperty("id", Order = 1)]
        public Guid Id { get; set; }

        [JsonProperty("payload", Order = 3)]
        public string Payload { get; set; }

        [JsonProperty("timestamp", Order = 2)]
        public long Timestamp { get; set; }

        public static Transaction fromJson(string json)
        {
            return JsonConvert.DeserializeObject<Transaction>(json);
        }
    }
}


