using Entities.ExtendedModels.MethodErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.App.Pages.Category
{
    public interface ICategoryDAL
    {
        Task<Response> Get(int perPage);
        Task<Response> Post(Dictionary<string, object> doc);
    }
}
