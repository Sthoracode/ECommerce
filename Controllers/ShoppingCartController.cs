using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IRepositoryWrapper repository;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ShoppingCartController(IRepositoryWrapper repository, UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Cart()
        {
            string sUserId = userManager.GetUserId(User);
            Cart cart = repository.Cart.FindByCondition(c => c.AppUserId == sUserId).FirstOrDefault();
            if(cart != null)
            {
                cart = repository.Cart.GetDetails(cart.CartId);
                return View(cart);
            }
            return View();
        }
        public IActionResult AddToCart(int id, int quantity = 1)
        {
            string sUserId = userManager.GetUserId(User);
            Cart cart = repository.Cart.FindByCondition(c => c.AppUserId == sUserId).FirstOrDefault();
            Product product = repository.Product.GetById(id);
            if(cart == null)
            {
                cart = new Cart
                {
                    AppUserId = sUserId,
                    DateCreated = DateTime.Now,
                    ShippingPrice = 50,
                    TotalPrice = product.Price,
                    TotalQuantity = quantity,
                    
                };
                repository.Cart.Create(cart);
                repository.SaveChanges();
            }
            else
            {
                cart.TotalPrice += product.Price;
                cart.TotalQuantity += quantity;
                repository.Cart.Update(cart);
            }
            CartItem cartItem = repository.CartItem.FindByCondition(c => c.CartId == cart.CartId && c.ProductId == id).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
                repository.CartItem.Update(cartItem);
            }
            else
            {
                cartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = id,
                    Quantity = quantity
                };
                repository.CartItem.Create(cartItem);

            }
            repository.SaveChanges();
            if(HttpContext.Request.Headers.Referer.ToString().ToLower().Contains("account"))
                return RedirectToAction("details", "product", new {id = id});

            return Redirect(HttpContext.Request.Headers.Referer);

        }
    }
}
