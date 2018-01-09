using AdminLayout.Areas.Admin.Models;
using AdminLayout.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminLayout.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        IEncryptor hasher;
        IMessage messageProvider;

        public AccountController()
        {
            hasher = new Md5HashProvider();
            messageProvider = new NetMessage();
        }

        // GET: Admin/Account
        public ActionResult Login()
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/admin");
            }

            return View();
        }

        //Admin sayfalarında sadece Login dışarı açıktır. Bunun dışında register, password rest gibi süreçler admin panelde bu kullanıcı rolu onayı ile oluşturulmalıdır.
        //Ama normal sitelerde kullanıcılar, yeni kullanıcı oluşturma, sisteme giriş yapma, parolayı unuttuklarında değiştirebilme gibi haklara sahip olacağından bu 3 sayfa AllowAnonymous yani herkes girebilir (Login olmayan da) şeklinde düşünülmelidir. 

        [AllowAnonymous]
        public ActionResult PasswordReset()
        {
            return View();
        }

        public ActionResult PasswordConfirm(string kod)
        {
            if (_kod == kod)
            {
                // koda gore kullanıcıyı bul view bu kullanıcıyı gönder.
                //kullanıcıidsini de alabilir.
                //bu kısım kod'a gore databaseden çağrılır.
                var model = new PasswordResetModel();
                model.Email = "test@test.com";

                return View(model);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordConfirm(PasswordResetModel model)
        {
            if (ModelState.IsValid)
            {
                //email addresine göre kullanıcıyı databaseden bul
                //var user = repository.GetByEmail(model.Email);
                //user.password = hasher.hash(model.password);
                //repository.Update(user);
                //repository.save();

                ViewBag.Message = "Parolanız Güncellendi";
            }

            return View(model);
        }

        public static string _kod;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordReset(PasswordResetModel model)
        {
            if (model.Email.Contains("@"))
            {
                //mail atma
                //inputu temizler
                _kod = Guid.NewGuid().ToString();
                string url = Path.Combine("http://localhost:54246/Admin/Account/PasswordConfirm/", "kod?=" + _kod);
                string htmlString = "<a href=" + url + ">Parolamı Resetle</a>";

                var message = (NetMessage)messageProvider;
                message.To = model.Email;
                bool Ok = message.SendMessage("Parola Değişikliği", htmlString);

                ModelState.Clear();
                ViewBag.Message = Ok ? "Gönderildi" : "Tekrar Deneyiniz";

                return View();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = hasher.Hash("Ahmet");

                if (model.EmailAddress == "test@test.com" && model.Password == "CC8C47A835D66E943D85083693042717")
                {
                    FormsAuthentication.SetAuthCookie("test@test.com", model.RememberMe);

                    return Redirect("/Admin");
                }
                else
                {
                    ViewBag.FormResult = "Kullanıcı adı veya şifre hatalı";
                    return View();
                }
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                string HashPass = hasher.Hash(model.Password);
                model.Password = HashPass;
            }

            return View();
        }

        [Authorize]
        public RedirectResult LogOut()
        {
            //cookie siler
            FormsAuthentication.SignOut();

            return Redirect("/Admin/Account/Login");
        }
    }
}