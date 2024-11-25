using Microsoft.AspNetCore.Mvc;

namespace MitTecForlob.Server.Controllers
{
    public class EducationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
