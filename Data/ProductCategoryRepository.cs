using ECommerce.Models;

namespace ECommerce.Data
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
