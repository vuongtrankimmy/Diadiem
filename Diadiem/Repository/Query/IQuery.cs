using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Enumerations.Databases;
using Entities.Enumerations.Tables;

namespace Repository.Query
{
    public interface IQuery
    {
        Task<T> Single<T>(Databases database, Tables table,
            List<string> filter = null, List<string> sort = null, int limit = 0);
        Task<List<T>> List<T>(Databases database, Tables table,
            List<string> filter = null, List<string> sort = null, int limit = 0, int pageno = 1);
        Task<string> Post(Databases database, Tables table, Dictionary<string, object> dic);
        Task<string> Put(Databases database, string _id, Dictionary<string, object> dic);
        Task<string> Delete(Databases database, Tables table, string _key);
    }
}
