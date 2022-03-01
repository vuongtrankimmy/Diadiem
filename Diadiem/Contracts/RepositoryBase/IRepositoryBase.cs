using Entities.Enumerations.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enumerations.Tables;

namespace Contracts.RepositoryBase
{
    public interface IRepositoryBase<K>
    {
        Task<List<T>> FindAll<T>(Databases databases, Tables tables, List<string> filter, List<string> sort = null, int limit = 0);

        Task<T> FindByConditionSingle<T>(Databases databases, Tables tables, List<string> filter,
            List<string> sort = null, int limit = 0);
        Task<List<T>> FindByCondition<T>(Databases databases, Tables tables, List<string> filter,
            List<string> sort = null, int limit = 0);

        Task<List<T>> FindByConditionPaging<T>(Databases databases, Tables tables,
            List<string> filter, List<string> sort = null, int limit = 0, int pageno = 1);

        Task<string> Post(Databases databases, Tables tables, Dictionary<string, object> doc);
        Task<string> Put(Databases databases, string _id, Dictionary<string, object> doc);
        Task<string> Delete(Databases databases, Tables tables, string _key);
    }
}
