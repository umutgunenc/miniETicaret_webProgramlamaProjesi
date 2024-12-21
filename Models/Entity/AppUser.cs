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

        }
        [Required]
        [MaxLength(11)]
        public string TCKN { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string SurName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool TermOfUse { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public ICollection<Order> CustomerOrders { get; set; }
        public ICollection<Order> SellerOrders { get; set; }

        public virtual ICollection<Product> SellerProducts { get; set; }
        public Cart Cart { get; set; }


    }
}
