using miniETicaret.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace miniETicaret.Models.Entity
{
    public class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        public int Id { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        public string Despriction { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public AppUser Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public AppUser Seller { get; set; }
        [Required]
        public int SellerId { get; set; }
        
        public virtual ICollection<ProductOrder> ProductOrders { get; set; } 

    }
}
