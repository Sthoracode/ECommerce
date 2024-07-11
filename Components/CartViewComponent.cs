using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IRepositoryWrapper repository;
        private readonly UserManager<AppUser> userManager;

        public CartViewComponent(IRepositoryWrapper repository, UserManager<AppUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }


        public IViewComponentResult Invoke()
        {
            if(User.Identity.IsAuthenticated)
            {
                string sUserId = userManager.GetUserId(UserClaimsPrincipal);
                Cart cart = repository.Cart.FindByCondition(c => c.AppUserId == sUserId).FirstOrDefault();
                if (cart != null)
                {
                    return View(cart.TotalQuantity);
                }

            }
            return View(0);
        }
    }
}
