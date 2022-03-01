using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Websites.v1.Base
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]        
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
    [IgnoreAntiforgeryToken]
    public class BaseController : ControllerBase
    {

    }
}
