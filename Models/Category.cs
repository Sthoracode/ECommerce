using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerce.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [DisplayName("Category name")]
        [Required(ErrorMessage = "Please enter a category name.")]
        public string CategoryName { get; set; }

        //Navigation property
        public IEnumerable<ProductCategory> Products { get; set; }
    }
}
