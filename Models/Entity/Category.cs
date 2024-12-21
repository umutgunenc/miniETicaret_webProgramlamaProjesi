using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace miniETicaret.Models.Entity
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Nane { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
