using Contracts.Owners.Items.Categories.Category;
using Contracts.RepositoryBase;
using Entities.Enumerations.Databases;
using Entities.Enumerations.Tables;
using Entities.Extensions.NullDySession;
using Entities.Models.Views.Modules.Token;
using Repository.Query;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EtC = Entities.Models.Owners.Items.Categories.Category;
namespace Repository.Owners.Items.Categories.Category
{
    public class CategoryRepository : RepositoryBase<EtC.CategoryModel>, ICategoryRepository
    {
        readonly TokenView tokenView = NullDySession.TokenUser ?? new TokenView();
        public CategoryRepository(IQuery query) : base(query)
        {
        }
        public async Task<List<T>> GetAll<T>()
        {
            var sort = new List<string>
            {
                "TO_NUMBER(C._key) DESC"
            };
            var filter = new List<string> {
                tokenView.User_id!=""? "User_id=='"+tokenView.User_id+"'":""
            };
            return await FindAll<T>(Databases.Items, Tables.Items_Category, filter, sort);
        }
        public async Task<List<T>> GetTopNew<T>(int perPage)
        {
            var sort = new List<string>
            {
                "TO_NUMBER(C._key) DESC"
            };
            //var filter = new List<string> {
            //    tokenView.User_id!=null&&tokenView.User_id!=""? "User_id=='"+tokenView.User_id+"'":""
            //};
            return await FindAll<T>(Databases.Items, Tables.Items_Category, null, sort, perPage);
        }

        public async Task<List<T>> GetAllBy_id<T>(string _id)
        {
            var filter = new List<string>
            {
                "_id=='"+_id+"' AND",
                "TO_NUMBER(C.Visible)==1 AND ",
                 tokenView.User_id!=""? "User_id=='"+tokenView.User_id+"'":""
            };
            return await FindByCondition<T>(Databases.Items, Tables.Items_Category, filter);
        }

        public async Task<List<T>> GetAllBy_idList<T>(string _idList)
        {
            var filter = new List<string>
            {
                "_id IN "+_idList+" AND",
                "TO_NUMBER(C.Visible)==1 AND",
                tokenView.User_id!=""? "User_id=='"+tokenView.User_id+"'":""
            };

            return await FindByCondition<T>(Databases.Items, Tables.Items_Category, filter);
        }
        public async Task<T> FindByHandle<T>(string handle, int pageNo = 1)
        {
            var sort = new List<string>
            {
                "TO_NUMBER(C._key) DESC"
            };
            var filter = new List<string>
            {
                "LOWER(C.Handle)=='"+handle+"' AND",
                "TO_NUMBER(C.Visible)==1 AND",
                tokenView.User_id!=""? "User_id=='"+tokenView.User_id+"'":""
            };
            return await FindByConditionSingle<T>(Databases.Items, Tables.Items_Category, filter, sort);
        }
        public async Task<List<T>> Find<T>(string keyword, int pageNo = 1)
        {
            var sort = new List<string>
            {
                "TO_NUMBER(C._key) DESC"
            };
            var filter = new List<string>
            {
                "(LOWER(C.Name)=='"+keyword+"' OR",
                "LOWER(C.Ansi)=='"+keyword+"' OR",
                "LOWER(C.Acronymn)=='"+keyword+"' OR",
                "LOWER(C.Handle)=='"+keyword+"') AND",
                "TO_NUMBER(C.Visible)==1 AND",
                tokenView.User_id!=""? "User_id=='"+tokenView.User_id+"'":""
            };
            return await FindByCondition<T>(Databases.Items, Tables.Items_Category, filter, sort, 0);
        }

        public async Task<string> Post(Dictionary<string,object> doc)
        {
            return await Post(Databases.Items, Tables.Items_Category,doc);
        }

        public async Task<string> Put(string _id,Dictionary<string, object> doc)
        {
            return await Put(Databases.Items, _id, doc);
        }
    }
}
