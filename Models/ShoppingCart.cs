

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ECommerce.Models
{
    public class ShoppingCart
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCart()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public List<CartItem> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("Cart", out string value);
            List<CartItem> cartItems = JsonConvert.DeserializeObject<List<CartItem>>(value);
            return cartItems ?? new List<CartItem>();
        }

        public void AddToCart(Product product, int quantity)
        {
            var session = _httpContextAccessor.HttpContext.Response.Cookies;
            var cartItems = GetCartItems();

            // Add/update item in the cart
            var existingItem = cartItems.FirstOrDefault(item => item.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem { ProductId = product.ProductId, Quantity = quantity });
            }
            string sJsonList = JsonConvert.SerializeObject(cartItems);
            // Update session
            session.Append("Cart", sJsonList);
        }

        // Implement other methods like RemoveFromCart, ClearCart, etc.
    }
}
