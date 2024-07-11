using ECommerce.Models;

namespace ECommerce.Data
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetProductsWithPhotos();
        Product GetProductWithPhotosAndCategories(int id);
    }
}
