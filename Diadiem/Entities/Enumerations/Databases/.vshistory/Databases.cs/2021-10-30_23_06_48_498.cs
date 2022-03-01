using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enumerations.Databases
{
    partial class Database
    {
        private string _partner = "tkt_";
    }    
    public enum Databases
    {
        Accounts,
        Customers,
        Erp,
        Hrs,
        Orders,
        Systems,
        Reports,
        Users
    }
}
