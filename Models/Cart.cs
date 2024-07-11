using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        [Display(Name = "Total quantity")]

        public int TotalQuantity { get; set; }
        [Display(Name = "Shipping amount")]
        public decimal ShippingPrice { get; set; }
        [Display(Name = "Total price")]
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }
        public AppUser AppUser { get; set; }
    }
}
