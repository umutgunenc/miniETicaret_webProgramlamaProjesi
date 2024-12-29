using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace miniETicaret.Models.ViewModel.Seller
{
    public class EditProductViewModel
    {
        public int Id { get; set; } // Ürün ID
        public string Name { get; set; } // Ürün Adı
        public string Despriction { get; set; } // Ürün Açıklaması
        public decimal Price { get; set; } // Ürün Fiyatı
        public int StockCount { get; set; } // Stok Miktarı
        public int CategoryId { get; set; } // Kategori ID
        public IFormFile ProductPhoto { get; set; } // Yeni Fotoğraf Dosyası
        public string CurrentImgUrl { get; set; } // Mevcut Görsel URL
        public List<SelectListItem> Categories { get; set; } // Kategori Listesi
    }

}

