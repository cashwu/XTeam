using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using XTeam.Models;
using XTeam.Service.Interface;

namespace XTeam.Controllers
{
    public class HomeController : BaseController
    {
        public IConfigService ConfigService { get; set; }

        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model, string returnUrl)
        {
            if (!ConfigService.Accounts.Contains(model.UserName.ToLower()))
            {
                ModelState.AddModelError("NotAuthorized", "You have not authorized login !!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!IsAuth)
            {
                SetAuthentication(model.UserName);
            }

            return RedirectToLocal(returnUrl);
        }

        private void SetAuthentication(string userName)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(
                new AuthenticationProperties
                {
                    IsPersistent = false,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.Add(TimeSpan.FromMinutes(30))
                },
                claimsIdentity);
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Script");
        }
    }
}