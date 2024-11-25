using Microsoft.AspNetCore.Mvc;

namespace MitTecForlob.Server.Controllers
{
    public class SpecsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
