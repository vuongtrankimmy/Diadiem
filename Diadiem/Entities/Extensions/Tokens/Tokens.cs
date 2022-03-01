using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Extensions.Tokens
{
    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int ExpireIn { get; set; } = 2;
        public Define Define { get; set; }= new Define();
    }

    public class Define
    {
        public string ExpireIn = "Thời gian hết hạn của token tính từ: 2 Hrs";
    }

    public partial class PostToken
    {
        public string Code { get; set; }
        public object Secrect { get; set; }
    }
}
