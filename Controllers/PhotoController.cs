using ECommerce.Data;
using ECommerce.Infrastructure;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IRepositoryWrapper repository;

        public PhotoController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }
        //public IActionResult Create()
        //{

        //}
        public IActionResult Delete(int id)
        {
            Photo photo = repository.Photo.GetById(id);
            FileActions.DeleteFile(photo);
            repository.Photo.Delete(photo);
            repository.SaveChanges();
            TempData["AlertMessage"] = "A photo was deleted successfully";
            TempData.Keep();
            return RedirectToAction("edit", "product", new { id = photo.ProductId.Value, msg = photo.Path + " was deleted successfully." });
        }
    }
}
