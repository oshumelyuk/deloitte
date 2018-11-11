using System.Threading.Tasks;
using System.Web.Mvc;
using Deloitte.DAL.Interfaces;
using Deloitte.Web.DryIoc;
using Deloitte.Web.ViewModels;
using DryIoc;

namespace Deloitte.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountRepository accountRepository;

        public AccountController()
        {
       //     accountRepository = IoC.Instance.Resolve<IAccountRepository>();
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
            if (!TryValidateModel(model))
            {
                return View();
            }

            var validationResult = await accountRepository.ValidateAccountAsync(model.Login, model.Password);
            if (validationResult.IsValid)
            {
               // AuthenticationManager.
                HttpContext.Session["UserName"] = validationResult.Account.Name;
            }

            return RedirectToAction("Index", "User");
        }
    }
}