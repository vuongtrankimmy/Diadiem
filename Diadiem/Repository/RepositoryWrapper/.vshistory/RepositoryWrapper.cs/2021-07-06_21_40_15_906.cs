using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Owners.Accounts.Account;
using Contracts.Owners.Users.Categories.Category;
using Contracts.Owners.Users.Locations.Location;
using Contracts.Owners.Users.Products.Product;
using Contracts.RepositoryWrapper;
using Repository.Owners.Accounts.Account;
using Repository.Owners.Users.Categories.Category;
using Repository.Owners.Users.Locations.Location;
using Repository.Owners.Users.Products.Product;
using Repository.Query;

namespace Repository.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IQuery _query;
        private IAccountRepository _account;
        private IProductRepository _product;
        private ICategoryRepository _category;
        private ILocationRepository _location;

        public RepositoryWrapper(IQuery query)
        {
            _query = query;
        }

        public IAccountRepository Account
        {
            get { return _account ??= new AccountRepository(_query); }
        }

        public IProductRepository Product
        {
            get { return _product ??= new ProductRepository(_query); }
        }

        public ICategoryRepository Category
        {
            get { return _category ??= new CategoryRepository(_query); }
        }
        public ILocationRepository Location
        {
            get { return _location ??= new LocationRepository(_query); }
        }
    }
}
