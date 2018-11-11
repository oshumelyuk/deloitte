using System.Threading.Tasks;
using System.Web.Mvc;
using Deloitte.DAL.Interfaces;

namespace Deloitte.Web.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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