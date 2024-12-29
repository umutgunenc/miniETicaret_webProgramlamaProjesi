using miniETicaret.Models.Entity;
using System;

namespace miniETicaret.Models.ViewModel.Seller
{
    public class ShowSoldProductsViewModel
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string CustomerNameSurname { get; set; }
        public string CustomerAdress { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
