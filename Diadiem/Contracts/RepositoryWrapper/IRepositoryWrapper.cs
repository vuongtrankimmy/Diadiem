using Contracts.Owners.Items.Categories.Category;

namespace Contracts.RepositoryWrapper
{
    public interface IRepositoryWrapper
    { 
        ICategoryRepository Category { get; }
    }
}
