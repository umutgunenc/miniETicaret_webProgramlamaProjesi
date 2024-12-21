using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace miniETicaret.Models.Entity
{
    public class AppRole :IdentityRole<int>
    {
        public AppRole()
        {
            
        }

    }
}
