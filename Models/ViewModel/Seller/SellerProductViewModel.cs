using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Models.ViewModel.Seller
{
    public class SellerProductViewModel
    {
        public int Id { get; set; } // Ürün ID
        public string Name { get; set; } // Ürün Adı
        public decimal Price { get; set; } // Ürün Fiyatı
        public int StockCount { get; set; } // Stok Miktarı
        public string ImgUrl { get; set; } // Ürün Görsel URL'si
    }
}
