using ECommerce.Models;

namespace ECommerce.Data
{
    public class CartItemsRepository : RepositoryBase<CartItem>, ICartItemsRepository
    {
        public CartItemsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
