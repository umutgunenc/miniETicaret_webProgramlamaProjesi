using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Models.ViewModel.Seller
{
    public class AddProductViewModel : Product
    {
        private readonly eTicaretDBContext _eTicaretDBContext;
        public AddProductViewModel()
        {

        }

        public AddProductViewModel(eTicaretDBContext eTicaretDBContext)
        {
            _eTicaretDBContext = eTicaretDBContext;
        }

        public IFormFile ProductPhoto { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public async Task<List<SelectListItem>> GetCategoriesAsync()
        {
            var query = _eTicaretDBContext.Categories
                .Where(x => x.IsActive == true)
                .Select(x => new
                {
                    x.Id,
                    x.Name
                });

            var categories = await query.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name

            }).ToListAsync();

            return categories;
        }
    }
}
