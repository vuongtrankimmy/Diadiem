using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.RepositoryBase;
using Entities.Enumerations.Databases;
using Entities.Enumerations.Tables;
using Repository.Query;

namespace Repository.RepositoryBase
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly IQuery _query;

        protected RepositoryBase(IQuery query)
        {
            _query = query;
        }

        public async Task<List<T>> FindAll<T>(Databases databases, Tables tables,List<string> filter, List<string> sort = null, int limit = 0) => 
            await _query.List<T>(databases, tables, filter, sort, limit, 0);

        public async Task<T> FindByConditionSingle<T>(Databases databases, Tables tables, List<string> filter,
            List<string> sort = null, int limit = 0)
        {
            return await _query.Single<T>(databases, tables, filter, sort, limit);
        }

        public async Task<List<T>> FindByCondition<T>(Databases databases, Tables tables, List<string> filter,
            List<string> sort = null, int limit = 0) => await _query.List<T>(databases, tables, filter, sort, limit);

        public async Task<List<T>> FindByConditionPaging<T>(Databases databases, Tables tables,
            List<string> filter, List<string> sort = null, int limit = 0, int pageno = 1) => await _query.List<T>(databases, tables, filter, sort, limit, pageno);

        public async Task<string> Post(Databases databases,Tables tables,Dictionary<string,object> doc)
        {
            return await _query.Post(databases, tables, doc);
        }

        public async Task<string> Put(Databases databases, string _id, Dictionary<string, object> doc)
        {
            return await _query.Put(databases, _id, doc);
        }

       public async Task<string> Delete(Databases databases, Tables tables, string _key)
        {
            return await _query.Delete(databases, tables, _key);
        }
    }
}
