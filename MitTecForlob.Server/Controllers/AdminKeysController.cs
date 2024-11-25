using Logic.Interfaces;
using Logic.Interfaces.Table_Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MitTecForlob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminKeysController : ControllerBase
    {
        private readonly IAdminKeys _adminKeys;
        private readonly IUser _user;
        private readonly IDataCollection collection;
        public AdminKeysController(IDataCollection _context)
        {
            _adminKeys = _context.AdminKeys;
            _user = _context.User;
            collection = _context;
        }
    }
}
