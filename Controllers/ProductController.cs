using ECommerce.Data;
using ECommerce.Infrastructure;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBreadcrumbs.Attributes;
using System.IO;

namespace ECommerce.Controllers
{
    [Breadcrumb]
    public class ProductController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProductController(IRepositoryWrapper repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            this.httpContextAccessor = httpContextAccessor;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id, string msg = null)
        {
            if(msg != null)
                TempData["AlertMessage"] = msg;
            ViewBag.Categories = new MultiSelectList(_repository.Category.FindAll(), "CategoryId", "CategoryName");
            Product product = _repository.Product.GetProductWithPhotosAndCategories(id);
            ProductViewModel productViewModel = new ProductViewModel
            {
                Product = product,
                Categories = new List<string>()
            };
            foreach(ProductCategory productCategory in product.ProductCategories)
            {
                productViewModel.Categories.Add(productCategory.CategoryId.ToString());
            }
            return View(productViewModel);
        }
        public IActionResult Details(int id)
        {
            Product product = _repository.Product.GetProductWithPhotosAndCategories(id);
            return View(new ProductViewModel { Product = product });
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = new MultiSelectList(_repository.Category.FindAll(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("Product,Photos,Categories")]ProductViewModel productVM)
        {
            ViewBag.Categories = new MultiSelectList(_repository.Category.FindAll(), "CategoryId", "CategoryName");
            if (ModelState.IsValid)
            {
                var trans = _repository.BeginTransaction();
                
                Product product = new Product
                {
                    Name = productVM.Product.Name,
                    Description = productVM.Product.Description,
                    Color = productVM.Product.Color,
                    Price = productVM.Product.Price,
                    Size = productVM.Product.Size,
                    QOH = productVM.Product.QOH,
                    DateAdded = DateTime.Now
                };
                _repository.Product.Create(product);
                _repository.SaveChanges();
                foreach(IFormFile file in  productVM.Photos)
                {
                    string savedPath = FileActions.UploadFile(file);
                    if(savedPath != string.Empty)
                    {
                        string extension = Path.GetExtension(Directory.GetCurrentDirectory()+ "\\wwwroot\\" + savedPath).ToLower();
                        if(extension != ".png" && extension != ".jpeg" && extension != ".jpg" && extension != ".gif")
                        {
                            ModelState.AddModelError("", "Only .png, .jpeg, .jpg and .gif file extensions allowed");
                            trans.Rollback();
                            foreach(IFormFile file1 in productVM.Photos)
                            {
                                FileActions.DeleteFile(new Photo { Path = "images\\products\\" + file1.FileName });
                            }
                            return View(productVM);
                        }
                        Photo photo = new Photo
                        {
                            Path = savedPath,
                            ProductId = product.ProductId
                        };
                        _repository.Photo.Create(photo);
                    }
                }
                
                foreach(string sId in productVM.Categories)
                {
                    ProductCategory productCategory = new ProductCategory
                    {
                        ProductId = product.ProductId,
                        CategoryId = int.Parse(sId)
                    };
                    _repository.ProductCategory.Create(productCategory);
                }
                _repository.SaveChanges();
                trans.Commit();
                return RedirectToAction("Products", new {msg = product.Name + " was added successfully." });
            }
            return View(productVM);
        }
        
        public IActionResult Products(string msg = null)
        {
            TempData["AlertMessage"] = msg;
            return View(_repository.Product.GetProductsWithPhotos());
        }
        public IActionResult Delete(int id)
        {
            Product product = _repository.Product.GetById(id);
            IEnumerable<Photo> photos = _repository.Photo.FindByCondition(photo => photo.ProductId == id);
            IEnumerable<ProductCategory> categories = _repository.ProductCategory.FindByCondition(productCategory => productCategory.ProductId == id);
            foreach(Photo photo in photos)
            {
                _repository.Photo.Delete(photo);
                FileActions.DeleteFile(photo);
            }
            if(categories!= null)
            {
                foreach(ProductCategory productCategory in categories)
                {
                    _repository.ProductCategory.Delete(productCategory);
                }
            }
            _repository.Product.Delete(product);
            _repository.SaveChanges();
            return RedirectToAction("Products", new { msg = product.Name + " was deleted successfully." });
            
        }
        

    }
}
