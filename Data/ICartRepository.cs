using ECommerce.Models;

namespace ECommerce.Data
{
    public interface ICartRepository :IRepositoryBase<Cart>
    {
        Cart GetDetails(int id);
    }
}
