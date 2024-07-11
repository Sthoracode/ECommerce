using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        [Display(Name ="Quantity on hand")]
        public int QOH { get; set; }
        public DateTime DateAdded { get; set; }

        
        public IEnumerable<Photo> Photos { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }

    }
}
