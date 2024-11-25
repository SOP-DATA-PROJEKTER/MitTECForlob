using Microsoft.AspNetCore.Mvc;

namespace MitTecForlob.Server.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
