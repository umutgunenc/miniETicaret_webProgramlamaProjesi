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
        public DateTime OrderTime { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public AppUser Customer { get; set; }
        public int CustomerId { get; set; }
        
        public virtual ICollection<ProductOrder> ProductOrders { get; set; } 

    }
}
