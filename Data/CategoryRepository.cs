using ECommerce.Models;

namespace ECommerce.Data
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) 
            : base(appDbContext)
        {
        }
    }
}
