using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Owners.Items.Categories.Category
{
    public partial class CategoryModel
    {
        [JsonProperty("_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string _id { get; set; }
        [JsonProperty("_key", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long _key { get; set; }
        [JsonProperty("_rev", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string _rev { get; set; }
        [JsonProperty("Id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("RefId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? RefId { get; set; }

        [JsonProperty("Name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Ansi", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Ansi { get; set; }

        [JsonProperty("Acronymn", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Acronymn { get; set; }

        [JsonProperty("Handle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Handle { get; set; }

        [JsonProperty("Description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("Color", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty("OrderNo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderNo { get; set; }

        [JsonProperty("Visible", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Visible { get; set; }

        [JsonProperty("Level", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; set; }

        [JsonProperty("CreateDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreateDate { get; set; }
        [JsonProperty("Images", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Image> Images { get; set; }
        [JsonProperty("Href", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Href { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("TypeId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? TypeId { get; set; }
        [JsonProperty("Alt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Alt { get; set; }

        [JsonProperty("Url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }
}
