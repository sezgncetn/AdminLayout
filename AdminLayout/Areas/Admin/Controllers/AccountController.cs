using AdminLayout.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminLayout.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {

        // GET: Admin/Account
        public ActionResult Login()
        {
            //Login olduysak Login ekranıana tekrar ulaşmamızı sağlar. Kontrol.
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/admin");
            }
            return View();
        }

        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.EmailAddress == "test@test.com" && model.Password == "Sezo9095")
                {
                    FormsAuthentication.SetAuthCookie("test@test.com", model.RememberMe);
                    return Redirect("/Admin");
                }
                else
                {
                    ViewBag.FormResult = "Kullanıcı Adı veya Şifre Hatalı";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            return View();
        }

        public RedirectResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Admin/Account/Login");
        }
    }

}