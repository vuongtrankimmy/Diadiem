using BusinessLogicLayer.Owners.App.Pages.Category;
using Cores.Body;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Websites.v1.Base;

namespace Websites.v1.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        readonly ICategoryDAL iCategoryDAL;

        public CategoryController(ICategoryDAL iCategoryDAL)
        {
            this.iCategoryDAL = iCategoryDAL;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get(int perPage=30)
        {
            var get = await iCategoryDAL.Get(perPage);
            return Ok(get);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Post()
        {
            var doc = await Request.GetRawBodyAsync<Dictionary<string, object>>();
            if (doc != null && doc.Any())
            {
                var post = await iCategoryDAL.Post(doc);
                return Ok(post);
            }
            return BadRequest(doc);
        }
    }
}
