using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XTeam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            //var accounts = SettingManager.Settings.Accounts;

            //if (!accounts.Contains(model.UserName))
            //{
            //    ModelState.AddModelError("NotAuthorized", "You have not authorized login !!");
            //}

            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            return View();
        }
    }

    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}