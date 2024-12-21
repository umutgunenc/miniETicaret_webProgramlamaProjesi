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
    }
}
