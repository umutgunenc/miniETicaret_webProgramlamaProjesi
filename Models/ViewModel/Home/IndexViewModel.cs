using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace miniETicaret.Models.ViewModel.Home
{
    public class IndexViewModel
    {
        private readonly eTicaretDBContext _eTicaretDBContext;

        public IndexViewModel()
        {

        }

        public IndexViewModel(eTicaretDBContext eTicaretDBContext)
        {
            _eTicaretDBContext = eTicaretDBContext;
        }


        public List<Product> Products { get; set; }

        public async Task<List<Product>> GetProductsAsync()
        {
            IQueryable<Product> query = _eTicaretDBContext.Products
                .Where(x => x.IsActive == true)
                .Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Despriction = x.Despriction,
                    ImgUrl = x.ImgUrl
                });

            Products = await query.ToListAsync();
            return Products;
        }
    }
}
