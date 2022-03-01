﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Core.Arango.Serialization.Json;
using Newtonsoft.Json.Converters;

namespace Core.Arango.Protocol
{
    /// <summary>
    ///     User access modes for database and collection
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum ArangoAccess
    {
        /// <summary>
        ///     No access
        /// </summary>
        [EnumMember(Value = "none")] None,

        /// <summary>
        ///     Read access only
        /// </summary>
        [EnumMember(Value = "ro")] ReadOnly,

        /// <summary>
        ///     Read and write access
        /// </summary>
        [EnumMember(Value = "rw")] ReadWrite
    }
}