using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace EMS_MVC_07Jan2024.Controllers
{

    public class AccountController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string UserId,string Password)
        {
            if(UserId == "admin" && Password == "123456")
            {
                FormsAuthentication.SetAuthCookie(UserId, false);
                return RedirectToAction("Index", "Department");
            }
            else
            {
                Notification("Error Message", "Invalid UserId or Password!", MessageType.error);
            }
            return View();
        }


        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}