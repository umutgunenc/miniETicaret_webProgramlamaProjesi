using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Models.ViewModel.Auth
{
    public class RegisterViewModel : AppUser
    {
        private readonly eTicaretDBContext _eTicaretDBContext;

        public string ConfirmPassword { get; set; }


    }
}
