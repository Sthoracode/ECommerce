using ECommerce.Data;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositoryWrapper wrapper;

        public HomeController(IRepositoryWrapper wrapper)
        {
            this.wrapper = wrapper;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.SlideShow = wrapper.SlideShow.GetSlideShowWithhAllImages("HomeSlideShow");
            homeViewModel.Products = wrapper.Product.GetProductsWithPhotos();
            return View(homeViewModel);
        }
    }
}
