using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.TokenManager
{
    public interface ITokenManager
    {
        Task<string> GenerateJwtToken(IEnumerable<Claim> claims);
        Task<string> GenerateJwtRefresh();
        Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    }
}
