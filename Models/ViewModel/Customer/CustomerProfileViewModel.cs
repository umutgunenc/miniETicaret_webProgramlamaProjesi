using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;

namespace miniETicaret.Models.ViewModel.Customer
{
    public class CustomerProfileViewModel
    {
        public string FullName { get; set; } // Ad ve Soyad
        public string TCKN { get; set; } // Kimlik Numarası
        public string Email { get; set; } // E-posta Adresi
        public string PhoneNumber { get; set; } // Telefon Numarası
        public string Address { get; set; } // Adres
        public bool IsActive { get; set; } // Kullanıcı Aktif mi?
    }
}

