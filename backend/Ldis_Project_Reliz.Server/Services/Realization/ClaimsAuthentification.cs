using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class ClaimsAuthentification : IClaimsAuthentificationService
    {
        IDataProtectionProvider ProtectionProvider;
        IHttpContextAccessor HttpAccessor;
        IRepository Repository;
        //HttpContextAccessor _httpAccessor;
        public ClaimsAuthentification(IHttpContextAccessor HttpAccessor, IRepository Repository, IDataProtectionProvider ProtectionProvider)
        {
            this.ProtectionProvider = ProtectionProvider;
            this.Repository = Repository;
            this.HttpAccessor = HttpAccessor;
            //this._httpAccessor.HttpContext = HttpAccessor.HttpContext;
        }
        /* Аутентификация юзера на основе Claims */
        public async Task Authentification(string Email)
        {
            var ClaimsUser = new List<Claim>
            {
                new Claim(ClaimTypes.Email,Email)
            };
            //if (HttpAccessor.HttpContext.Request.Headers.ContainsKey("X-Correlation-ID"))
            //{
            //    HttpAccessor.HttpContext.TraceIdentifier = HttpAccessor.HttpContext.Request.Headers["X-Correlation-ID"];
            //    // WORKAROUND: On ASP.NET Core 2.2.1 we need to re-store in AsyncLocal the new TraceId, HttpContext Pair
            //}
            HttpAccessor.HttpContext.Response.Cookies.Append(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail, Email);
            //contextAccessor.HttpContext.Response.Cookies.Append(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail, Email);
            var IdentityUser = new ClaimsIdentity(ClaimsUser, CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimsPrincipal = new ClaimsPrincipal(IdentityUser);
            await HttpAccessor.HttpContext.SignInAsync(ClaimsPrincipal);
        }
        public async Task Authentification(string Email, HttpContext context)
        {
            var ClaimsUser = new List<Claim>
            {
                new Claim(ClaimTypes.Email,Email)
            };
            //if (HttpAccessor.HttpContext.Request.Headers.ContainsKey("X-Correlation-ID"))
            //{
            //    HttpAccessor.HttpContext.TraceIdentifier = HttpAccessor.HttpContext.Request.Headers["X-Correlation-ID"];
            //    // WORKAROUND: On ASP.NET Core 2.2.1 we need to re-store in AsyncLocal the new TraceId, HttpContext Pair
            //}
            //HttpAccessor.HttpContext.Response.Cookies.Append(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail, Email);
            HttpAccessor.HttpContext = context;
            HttpAccessor.HttpContext.Response.Cookies.Append(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail, Email);
            var IdentityUser = new ClaimsIdentity(ClaimsUser, CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimsPrincipal = new ClaimsPrincipal(IdentityUser);
            await HttpAccessor.HttpContext.SignInAsync(ClaimsPrincipal);
        }
        /*Выход из учетной записи*/
        public async Task LogOut()
        {
            HttpAccessor.HttpContext.SignOutAsync();
            HttpAccessor.HttpContext.Response.Cookies.Delete(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail);
            HttpAccessor.HttpContext.Response.Cookies.Delete(DataToCacheSessionCookieKey.UserName);
            Repository.LogOut();
        }
    }
}
