using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Owners.Accounts.Account;
using Contracts.Owners.Users.Categories.Category;
using Contracts.Owners.Users.Locations.Location;
using Contracts.Owners.Users.Products.Product;

namespace Contracts.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        ILocationRepository Location { get; }
    }
}
