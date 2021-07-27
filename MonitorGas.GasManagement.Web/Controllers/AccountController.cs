using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using MonitorGas.GasManagement.Web.Models;

namespace MonitorGas.GasManagement.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
            {
                RedirectUri = returnUrl ?? Url.Action("Index", "Home")
            },
                "Auth0");
            return new HttpUnauthorizedResult();
        }

        [HttpGet]
        [Authorize]
        public void Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            HttpContext.GetOwinContext().Authentication.SignOut("Auth0");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Claims()
        {
            return View();
        }


        //[Authorize]
        //public ActionResult Tokens()
        //{
        //    var claimsIdentity = User.Identity as ClaimsIdentity;

        //    // Extract tokens
        //    string accessToken = claimsIdentity?.FindFirst(c => c.Type == "access_token")?.Value;
        //    string idToken = claimsIdentity?.FindFirst(c => c.Type == "id_token")?.Value;

        //    // Now you can use the tokens as appropriate...
        //}
    }
}