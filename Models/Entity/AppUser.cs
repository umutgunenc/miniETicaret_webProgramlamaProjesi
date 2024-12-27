using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

#nullable disable

namespace miniETicaret.Models.Entity
{
    public partial class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            CustomerOrders = new HashSet<Order>();
            SellerProducts = new HashSet<Product>();
            SellerOrders = new HashSet<ProductOrder>();
        }

        public string TCKN { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsActive { get; set; }
        public bool TermOfUse { get; set; }
        public string Address { get; set; }
        public Cart Cart { get; set; }
        public virtual ICollection<Order> CustomerOrders { get; set; }
        public virtual ICollection<Product> SellerProducts { get; set; }
        public virtual ICollection<ProductOrder> SellerOrders { get; set; }



    }
}
