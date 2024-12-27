using miniETicaret.Models.Entity;
using System;

namespace miniETicaret.Models.ViewModel.Customer
{
    public class ShowOrderDetailViewModel : ProductOrder
    {
        public int? OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string SellerName { get; set; }
        public string ProductName { get; set; }
        public decimal TotalProductPrice { get; set; }
    }
}
