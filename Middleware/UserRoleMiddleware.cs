using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using miniETicaret.Models.Entity;
using System.Threading.Tasks;
using miniETicaret.Models;


namespace miniETicaret.Middleware
{

    public class UserRoleMiddleware
    {
        private readonly RequestDelegate _next;

        public UserRoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, UserManager<AppUser> userManager)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(httpContext.User);
                if (user != null)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Contains("ADMIN"))
                        httpContext.Items["UserRoleId"] = 1;
                    else if (roles.Contains("SELLER"))
                        httpContext.Items["UserRoleId"] = 2;
                    else if (roles.Contains("CUSTOMER"))
                        httpContext.Items["UserRoleId"] = 3;
                }
            }

            await _next(httpContext);
        }
    }

}
