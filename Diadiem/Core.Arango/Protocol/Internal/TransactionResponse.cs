﻿using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Core.Arango.Protocol.Internal
{
    internal class TransactionResponse
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}