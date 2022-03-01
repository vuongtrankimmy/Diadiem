using Contracts.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtC = Entities.Models.Owners.Items.Categories.Category;
namespace Contracts.Owners.Items.Categories.Category
{
    public interface ICategoryRepository : IRepositoryBase<EtC.CategoryModel>
    {
        Task<List<T>> GetAll<T>();
        Task<List<T>> GetTopNew<T>(int perPage);
        Task<List<T>> GetAllBy_id<T>(string _id);
        Task<List<T>> GetAllBy_idList<T>(string _idList);
        Task<T> FindByHandle<T>(string handle, int pageNo = 1);
        Task<List<T>> Find<T>(string keyword, int pageNo = 1);
        Task<string> Post(Dictionary<string, object> doc);
        Task<string> Put(string _id, Dictionary<string, object> doc);
    }
}
