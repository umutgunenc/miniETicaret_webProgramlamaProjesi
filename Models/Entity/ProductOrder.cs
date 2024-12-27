using System.ComponentModel.DataAnnotations.Schema;

namespace miniETicaret.Models.Entity
{
    public class ProductOrder
    {

        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(SellerId))]
        public int SellerId { get; set; }
        public virtual AppUser Seller { get; set; }
        public int Quantity { get; set; }
        public decimal ProductUnitPrice { get; set; }
    }
}
