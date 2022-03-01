using Entities.Models.Views.Modules.Token;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entities.Extensions.NullDySession
{
    /// 
    ///Current session object
    /// 
    public class NullDySession
    {
        /// 
        ///Get dysession instance
        /// 
        public static NullDySession Instance { get; } = new NullDySession();
        /// 
        ///Get current user information
        /// 
        public static TokenView TokenUser
        {
            get
            {
                var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;

                var claimsIdentity = claimsPrincipal?.Identity as ClaimsIdentity;

                var device_id = claimsIdentity?.Claims.FirstOrDefault(c => c.Type == "Device_id");
                if (device_id == null || string.IsNullOrEmpty(device_id.Value))
                {
                    return null;
                }
                TokenView tokenView =null;
                var userClaim = claimsIdentity?.Claims.ToList();
                if(userClaim != null && userClaim.Any())
                {
                    var claim =JsonConvert.SerializeObject(userClaim.ToDictionary(x => x.Type, y=>y.Value));
                    tokenView = JsonConvert.DeserializeObject<TokenView>(claim);
                }
                return tokenView;
            }
        }

        private NullDySession()
        {
        }
    }
}
