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
