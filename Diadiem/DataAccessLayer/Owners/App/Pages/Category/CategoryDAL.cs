using BusinessLogicLayer.Owners.App.Pages.Category;
using Contracts.RepositoryWrapper;
using Entities.ExtendedModels.Localize;
using Entities.ExtendedModels.MethodErrorHandling;
using Entities.Models.Owners.Items.Categories.Category;
using Helpers.Helper.Convert;
using Microsoft.Extensions.Localization;

namespace DataAccessLayer.Owners.App.Pages.Category
{
    public class CategoryDAL: ICategoryDAL
    {
        private readonly IStringLocalizer<Resource> localizer;
        private readonly IRepositoryWrapper repository;
        public CategoryDAL(IStringLocalizer<Resource> localizer, IRepositoryWrapper repository)
        {
            this.repository = repository;   
            this.localizer = localizer;
        }

        public async Task<Response> Get(int perPage)
        {
            var response = new Response { StatusCode = 200 };
            var categoryList = await repository.Category.GetTopNew<CategoryModel>(perPage);
            if (categoryList != null && categoryList.Any())
            {
                response.Data = categoryList;
                response.StatusCode = 200;
            }
            return response;
        }

        public async Task<Response> Post(Dictionary<string,object> doc)
        {
            var response = new Response { StatusCode = 200 };
            doc["CreateDate"] = DateTimeOffset.Now.ConvertTime();//Vietnam: UTC:+7
            var post = await repository.Category.Post(doc);
            if(post != null && post != "")
            {
               response.Data = post;
                response.StatusCode = 200;
            }
            return response;
        }
    }
}
