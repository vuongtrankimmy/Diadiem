using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Helpers.Sort
{
    public static class SortExtension
    {
        public static void Sort(JObject jObj)
        {
            var props = jObj.Properties().ToList();
            foreach (var prop in props)
            {
                prop.Remove();
            }

            foreach (var prop in props.OrderBy(p => p.Name))
            {
                jObj.Add(prop);
                if (prop.Value is JObject)
                    Sort((JObject)prop.Value);
            }
        }

        public static T SortObject<T>(object doc) where T : new()
        {
            var jOb = JObject.FromObject(doc);
            Sort(jOb);
            var jsonObject = JsonConvert.SerializeObject(jOb, Formatting.Indented);
            var t = JsonConvert.DeserializeObject<T>(jsonObject);
            return t;
        }
    }
}
