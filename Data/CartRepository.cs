using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Cart GetDetails(int id)
        {
            return _appDbContext.Cart.Include(c => c.CartItems).ThenInclude(ci => ci.Product).ThenInclude(p=> p.Photos).FirstOrDefault(c => c.CartId == id);
        }
    }
}
