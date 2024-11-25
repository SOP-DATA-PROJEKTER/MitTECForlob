using Microsoft.AspNetCore.Mvc;

namespace MitTecForlob.Server.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
