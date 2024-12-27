using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Models.ViewModel.Customer
{
    public class ShowCartViewModel : Cart
    {
        private readonly eTicaretDBContext _eTicaretDBContext;
        private readonly AppUser _user;
        public ShowCartViewModel()
        {

        }
        public ShowCartViewModel(eTicaretDBContext eTicaretDBContext, AppUser user)
        {
            _eTicaretDBContext = eTicaretDBContext;
            _user = user;
        }


        public bool IsActive { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }

        public List<ShowCartViewModel> Carts { get; set; }

        public async Task<List<ShowCartViewModel>> GetChartDetailsAsync()
        {
            var query = _eTicaretDBContext.Carts
                .Include(c => c.Product)
                .Where(c => c.CustomerId == _user.Id)
                .Select(c => new ShowCartViewModel
                {
                    ProductId = c.ProductId,
                    ProductName = c.Product.Name,
                    Quantity = c.Quantity,
                    ProductPrice = c.Product.Price,
                });

            Carts = await query.ToListAsync();

            return Carts;
        }
    }
}
