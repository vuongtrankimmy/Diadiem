using Contracts.TokenManager;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.TokenManager
{
    public class TokenManager: ITokenManager
    {
        readonly IOptions<TokenManagement> _tokenManager;

        public TokenManager(IOptions<TokenManagement> tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task<string> GenerateJwtToken(IEnumerable<Claim> claims)
        {
            var tokenValue = _tokenManager?.Value;
            if (tokenValue != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValue.Secret));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: tokenValue.Issuer,
                    audience: tokenValue.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddHours(tokenValue.AccessExpiration),                    
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
            return "";
        }

        public async Task<string> GenerateJwtRefresh()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token)
        {
            var tokenValue = _tokenManager?.Value;
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValue.Secret)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
