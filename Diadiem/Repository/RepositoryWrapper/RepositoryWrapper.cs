using Contracts.Owners.Items.Categories.Category;
using Contracts.RepositoryWrapper;
using Repository.Owners.Items.Categories.Category;
using Repository.Query;

namespace Repository.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IQuery _query;
        private ICategoryRepository _category;
        public RepositoryWrapper(IQuery query)
        {
            _query = query;
        }

        public ICategoryRepository Category { get { return _category ??= new CategoryRepository(_query); } }
    }
}
