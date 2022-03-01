using Entities.Enumerations.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Arango;
using Core.Arango.Protocol;
using Entities.Enumerations.Tables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Repository.Query
{
    public class Query : IQuery
    {
        private readonly IArangoContext _arango;

        public Query(IArangoContext arango)
        {
            _arango = arango;
        }

        public async Task<T> Single<T>(Databases database, Tables table,
            List<string> filter = null, List<string> sort = null, int limit = 0)
        {
            var itemSort = "";
            const string item = "C";
            if (sort != null)
            {
                var sortConcat = sort.ConvertAll(x => x.Contains(item + ".") ? x : string.Concat(item, ".", x))
                    ;
                itemSort = " SORT " + string.Join(",", sortConcat);
            }

            var itemFilter = "";
            if (filter != null)
            {
                var filterConcat = filter.ConvertAll(x => x.Contains(item + ".") ? x : string.Concat(item, ".", x));
                itemFilter = " FILTER " + string.Join(" ", filterConcat);
            }

            var itemLimit = "";
            if (limit > 0)
            {
                itemLimit = " LIMIT " + limit;
            }
            var itable = table.ToString();
            var idatabase = database.ToString();
            var forPart = $"FOR {item} IN {itable:@}";
            var sortPart = $"{itemSort}";
            var filterPart = $"{itemFilter}";
            var limitPart = $"{itemLimit}";
            string returnPart = $"RETURN {item}";
            FormattableString query = $"{forPart} {sortPart} {filterPart} {limitPart} {returnPart}";
            var jObject = await _arango.Query.ExecuteAsync<JObject>(idatabase, query);
            if (!jObject.Any()) return default;
            if (jObject.Count == 0) return default;
            var strJobject = JsonConvert.SerializeObject(jObject[0]);
            return JsonConvert.DeserializeObject<T>(strJobject);
        }

        public async Task<List<T>> List<T>(Databases database, Tables table,
            List<string> filter = null, List<string> sort = null, int limit = 0, int pageno = 1)
        {
            var lst = new List<T>();

            var itemSort = "";
            const string item = "C";
            if (sort != null)
            {
                var sortConcat = sort.ConvertAll(x => x.Contains(item + ".") ? x : string.Concat(item, ".", x))
;
                itemSort = " SORT " + string.Join(",", sortConcat);
            }

            var itemFilter = "";
            if (filter != null)
            {
                var filterConcat = filter.ConvertAll(x => x.Contains(item + ".") ? x : string.Concat(item, ".", x));
                itemFilter = " FILTER " + string.Join(" ", filterConcat);
            }

            var itemLimit = "";
            if (limit > 0)
            {
                itemLimit = " LIMIT " + limit;
            }
            var itable = table.ToString();
            var idatabase = database.ToString();
            var forPart = $"FOR {item} IN {itable:@}";
            var sortPart = $"{itemSort}";
            var filterPart = $"{itemFilter}";
            var limitPart = $"{itemLimit}";
            string returnPart = $"RETURN {item}";
            FormattableString query = $"{forPart} {sortPart} {filterPart} {limitPart} {returnPart}";
            var jObject = await _arango.Query.ExecuteAsync<JObject>(idatabase, query);
            if (!jObject.Any()) return lst;
            var strJobject = JsonConvert.SerializeObject(jObject);
            return JsonConvert.DeserializeObject<List<T>>(strJobject);
        }

        public async Task<string> Post(Databases database, Tables table, Dictionary<string, object> doc)
        {
            var result = "";

            var existCollect = await _arango.Collection.ExistAsync(database.ToString(), table.ToString());
            if (!existCollect)
            {
                await _arango.Collection.CreateAsync(database.ToString(), table.ToString(), ArangoCollectionType.Document);
            }
            var arangoResult = await _arango.Document.CreateAsync(database.ToString(), table.ToString(), doc);
            if (arangoResult.Id != "")
            {
                result = arangoResult.Id;
            }
            return result;
        }

        public async Task<string> Put(Databases database, string _id, Dictionary<string, object> dic)
        {
            var result = "";
            var arangoResult = await _arango.Document.UpdateAsync(database.ToString(), _id, dic);
            if (arangoResult.Id != "")
            {
                result = arangoResult.Id;
            }
            return result;
        }

        public async Task<string> Delete(Databases database, Tables table, string _key)
        {
            var result = "";
            var arangoResult = await _arango.Document.DeleteAsync<string>(database.ToString(), table.ToString(), _key);
            if (arangoResult.Id != "")
            {
                result = arangoResult.Id;
            }
            return result;
        }
    }
}
