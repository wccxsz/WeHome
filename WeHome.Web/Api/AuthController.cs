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
using WeHome.Web.Models;

namespace WeHome.Web.Api
{
    public class AuthController : BaseController
    {
        [HttpPost]
        public ResultState Login(LoginViewModel loginViewModel)
        {
            var password = loginViewModel.Password;
            var state = new ResultState();
            var userBll = Work.UserBll;
            var user = userBll.GetUser(userName: loginViewModel.UserName);
            if (user != null && user.Password == EncryptTool.Encrypt(password.Trim()))
            {
                user.AccessFailedCount = 0;
                var principal = CreatePrincipal(user);
                HttpContext.Current.GetOwinContext()
                    .Authentication.SignIn(
                        new AuthenticationProperties() {IsPersistent = true, ExpiresUtc = DateTime.Now.AddDays(1)},
                        principal.Identities.ToArray());
                state.Status = true;
                state.Data = null;
            }
            else
            {
                state.Data = "用户名或密码错误!";
                state.Status = false;
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