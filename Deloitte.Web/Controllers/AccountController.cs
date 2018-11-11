using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Deloitte.DAL.Interfaces;
using Deloitte.Web.ViewModels;

namespace Deloitte.Web.Controllers
{
    public class AccountController : BaseController
    {
        private IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return await LogOut();
            }

            if (!TryValidateModel(model))
            {
                return View();
            }

            var validationResult = await accountRepository.ValidateAccountAsync(model.Login, model.Password);
            if (validationResult.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                HttpContext.Session[SessionKeys.Username] = validationResult.Account.Name;
            }

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> LogOut()
        {
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }
    }
}