using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) 
            : base(appDbContext)
        {
        }

        public IEnumerable<Product> GetProductsWithPhotos()
        {
            return _appDbContext.Products.Include(p => p.Photos);
        }

        public Product GetProductWithPhotosAndCategories(int id)
        {
            return _appDbContext.Products
                .Include(p => p.Photos).Include(p => p.ProductCategories).ThenInclude(pc => pc.Category)
                .FirstOrDefault(p => p.ProductId == id);
        }
    }
}
