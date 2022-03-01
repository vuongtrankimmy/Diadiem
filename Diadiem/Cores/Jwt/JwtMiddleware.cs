 using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cores.Jwt
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        readonly IOptions<TokenManagement> _tokenManager;

        public JwtMiddleware(RequestDelegate next, IOptions<TokenManagement> tokenManagement)
        {
            _tokenManager = tokenManagement;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Get the upload token, which can be customized and extended
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last()
                        ?? context.Request.Headers["X-Token"].FirstOrDefault()
                        ?? context.Request.Query["Token"].FirstOrDefault()
                        ?? context.Request.Cookies["Token"];

            if (token != null)
                AttachUserToContext(context, token);
            
            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenValue = _tokenManager?.Value;
                if (tokenValue != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(tokenValue.Secret);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var user = jwtToken.Claims;

                    //Write authentication information to facilitate the use of business classes
                    var claimsIdentity = new ClaimsIdentity(user);
                    Thread.CurrentPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // attach user to context on successful jwt validation
                    context.Items["User"] = user;                    
                }
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
                throw;
            }
        }
    }
}
