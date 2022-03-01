using Entities.ExtendedModels.MethodErrorHandling;
using Entities.Extensions.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.App.Modules.Jwt
{
    public interface IJwtDAL
    {
        Task<Response> Get(PostToken doc);
    }
}
