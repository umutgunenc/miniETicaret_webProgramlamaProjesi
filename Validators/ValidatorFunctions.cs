using System.Threading.Tasks;
using System.Threading;
using miniETicaret.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace miniETicaret.Validators
{
    public static class ValidatorFunctions
    {
        private static readonly eTicaretDBContext _context = new();
        public static bool BeUniqueCategoryName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return true;
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
            return _context.Categories.Any(x => x.Id == id);
        }

        public static bool BeUniqueEmailAdress(string eMail)
        {

            if (string.IsNullOrEmpty(eMail))
                return true;
            return !_context.Users.Any(x => x.Email.ToUpper() == eMail.ToUpper());
        }

        public static bool BeNumber(string TCKN)
        {
            if (string.IsNullOrEmpty(TCKN))
                return true;

            return TCKN.All(c => c >= '0' && c <= '9');

        }

        public static bool BeUniqueTCKN(string TCKN)
        {
            if (string.IsNullOrEmpty(TCKN))
                return true;

            return !_context.Users.Any(x => x.TCKN.ToUpper() == TCKN.ToUpper());
        }

        public static bool BeUniquePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return true;

            return !_context.Users.Any(x => x.PhoneNumber.ToUpper() == phoneNumber.ToUpper());
        }
        public static bool BePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return true;

            var phonePattern = @"^\+90\d{10}$";

            var regex = new Regex(phonePattern);
            return regex.IsMatch(phoneNumber);

        }
        public static bool BeUniqueUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return true;

            return !_context.Users.Any(x => x.UserName.ToUpper() == userName.ToUpper());

        }
    }
}
