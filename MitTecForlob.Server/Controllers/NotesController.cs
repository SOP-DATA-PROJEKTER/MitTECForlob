using Microsoft.AspNetCore.Mvc;

namespace MitTecForlob.Server.Controllers
{
    public class NotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
