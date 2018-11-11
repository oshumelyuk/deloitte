using System.Threading.Tasks;
using System.Web.Mvc;
using Deloitte.DAL.Interfaces;
using Deloitte.Web.DryIoc;
using DryIoc;

namespace Deloitte.Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;

        public UserController()
        {
       //     userRepository = IoC.Instance.Resolve<IUserRepository>();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var users = await userRepository.ListAllAsync();
            return View(users);
        }
    }
}