using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Models.ViewModel.Admin
{
    public class EditCategoryViewModel : Category
    {
        private readonly eTicaretDBContext _eTicaretDBContext;

        public EditCategoryViewModel()
        {
            
        }
        public EditCategoryViewModel(eTicaretDBContext context)
        {
            _eTicaretDBContext = context;
        }

        public List<SelectListItem> Categories { get; set; }
        public async Task<List<SelectListItem>> GetCategoriesAsync()
        {
            var categories = await _eTicaretDBContext.Categories
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToListAsync();

            return categories;
        }
    }
}
