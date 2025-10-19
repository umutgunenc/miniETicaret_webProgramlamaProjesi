using miniETicaret.Models.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace miniETicaret.Models.Entity
{
    public class Product
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int StockCount { get; set; }
        public string ImgUrl { get; set; }
        public AppUser Seller { get; set; }
        public int SellerId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders {get;set;}

    }
}
