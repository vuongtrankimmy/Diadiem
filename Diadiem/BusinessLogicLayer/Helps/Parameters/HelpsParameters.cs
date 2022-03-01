using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helps.Parameters
{
    public static class HelpsParameters
    {
        public static readonly string _shop = "shop";
        public static readonly string _shopItem = _shop+"/" + "{0}";
        public static readonly string _item = _shop + "/" + "{0}/{1}";
    }
}
