using ECommerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IRepositoryWrapper wrapper;

        public AdminController(IRepositoryWrapper wrapper)
        {
            this.wrapper = wrapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
