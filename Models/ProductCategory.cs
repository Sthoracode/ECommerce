using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ProductCategory
    {
        [Key]
        [Column(Order = 1)]
        public int CategoryId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
