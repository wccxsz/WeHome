using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WeHome.Entities;
using WeHome.Framework;
using WeHome.Framework.Tools;

namespace WeHome.Web.Api
{
    public class AuthController : BaseController
    {

        [HttpPost]
        public ResultState Login(User user)
        {
            var password = user.Password;
            var state = new ResultState();
            var userBll = Work.UserBll;
            user = userBll.GetUser(userName: user.UserName);
            if (user == null)
            {
                state.Data = false;
                state.Status = 0;
                return state;
            }
            if (user.Password == EncryptTool.Encrypt(password.Trim()))
            {
                var principal = CreatePrincipal(user);
                HttpContext.Current.GetOwinContext()
                    .Authentication.SignIn(
                        new AuthenticationProperties() {IsPersistent = true, ExpiresUtc = DateTime.Now.AddDays(1)},
                        principal.Identities.ToArray());
                state.Status = 1;
                state.Data = true;
            }
            else
            {
                state.Data = false;
                state.Status = 0;
            }
            
            return state;
        }

        private ClaimsPrincipal CreatePrincipal(User user)
        {
            var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim("DisplayName", user.EmployeeName));
            var principal = new ClaimsPrincipal(identity);
            return principal;
        }
    }
}