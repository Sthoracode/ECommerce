﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
