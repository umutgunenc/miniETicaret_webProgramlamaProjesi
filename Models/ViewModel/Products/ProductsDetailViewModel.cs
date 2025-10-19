using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Models.ViewModel.Products
{
    public class ProductsDetailViewModel : Product
    {
        private readonly eTicaretDBContext _eTicaretDBContext;
        public ProductsDetailViewModel()
        {

        }

        public ProductsDetailViewModel(eTicaretDBContext eTicaretDBContext)
        {
            _eTicaretDBContext = eTicaretDBContext;
        }

        public int Quantity { get; set; }

        public async Task<ProductsDetailViewModel> GetProductsDetailViewModelAsync(int id)
        {
            var query = _eTicaretDBContext.Products
                 .Where(x => x.Id == id && x.IsActive)
                 .Select(x => new ProductsDetailViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Description = x.Description,
                     Price = x.Price,
                     ImgUrl=x.ImgUrl,
                     Quantity=x.StockCount
                     
                 });

            var product = await query.FirstOrDefaultAsync();

            return product;

        }

    }
}
