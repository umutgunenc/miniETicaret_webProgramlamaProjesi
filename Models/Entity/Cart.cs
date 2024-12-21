using miniETicaret.Models.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace miniETicaret.Models.Entity
{
    public class Cart
    {
        public Cart()
        {

        }
        [ForeignKey(nameof(CustomerId))]
        public AppUser Customer { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
