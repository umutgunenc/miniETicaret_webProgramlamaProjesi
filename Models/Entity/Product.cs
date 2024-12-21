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
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        public string Despriction { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int StockCount { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        public AppUser Seller { get; set; }
        [Required]
        public int SellerId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders {get;set;}

    }
}
