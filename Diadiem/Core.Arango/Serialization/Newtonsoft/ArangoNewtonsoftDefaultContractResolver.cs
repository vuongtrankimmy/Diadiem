﻿using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Core.Arango.Serialization.Newtonsoft
{
    /// <summary>
    ///     System.Json.Text PascalCase Naming Policy for Arango
    /// </summary>
    public class ArangoNewtonsoftDefaultContractResolver : DefaultContractResolver
    {
        /// <summary>
        ///     System.Json.Text PascalCase Naming Policy for Arango
        /// </summary>
        public ArangoNewtonsoftDefaultContractResolver()
        {
            NamingStrategy = new DefaultNamingStrategy();
        }

        /// <inheritdoc />
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (member.GetCustomAttribute<ArangoIgnoreAttribute>() != null)
            {
                property.ShouldDeserialize = i => true;
                property.ShouldSerialize = i => false;
            }

            property.PropertyName = property.PropertyName switch
            {
                "Id" => "_id",
                "Key" => "_key",
                "Revision" => "_rev",
                "From" => "_from",
                "To" => "_to",
                _ => property.PropertyName
            };

            return property;
        }
    }
}