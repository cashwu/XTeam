using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XTeam.Service;
using XTeam.Service.Interface;

namespace XTeam.Controllers
{
    public class HomeController : Controller
    {
        public IConfigService ConfigService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ConfigService.Accounts.Contains(model.UserName.ToLower()))
            {
                ModelState.AddModelError("NotAuthorized", "You have not authorized login !!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Script");
        }
    }

    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("UserName", ErrorMessage = "UserName or Password Error !!")]
        public string Password { get; set; }
    }
}