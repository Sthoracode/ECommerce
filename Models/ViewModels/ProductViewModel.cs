using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        [Required]
        public List<string> Categories { get; set; }
        [Required]
        [FromForm]
        public List<IFormFile> Photos { get; set; }

        public IEnumerable<Category> LstCategories {  get; set; }
    }
}
