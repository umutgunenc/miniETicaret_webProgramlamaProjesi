using System.Threading.Tasks;
using System.Threading;
using miniETicaret.Data;
using System.Linq;

namespace miniETicaret.Validators
{
    public static class ValidatorFunctions
    {
        private static readonly eTicaretDBContext _context = new();
        public static bool BeUniqueCategoryName(string name)
        {
            return !_context.Categories.Any(x => x.Name.ToUpper() == name.ToUpper());
        }

        /// <summary>
        /// Aynı isme sahip ve kendisi dışında başka bir kayıt olup olmadığını kontrol eder
        /// </summary>
        /// <param name="name"></param>
        /// <param name="currentCategoryId"></param>
        /// <returns></returns>
        public static bool BeUniqueCategoryName(string name, int categoryId)
        {
            if (string.IsNullOrEmpty(name))
                return true;
            return !_context.Categories.Any(c => c.Name.ToUpper() == name.ToUpper() && c.Id != categoryId);
        }

        public static bool BeCategory(int id)
        {
            return _context.Categories.Any(x=>x.Id == id);
        }
    }
}
