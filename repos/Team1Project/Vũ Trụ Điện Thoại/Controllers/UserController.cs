using Microsoft.AspNetCore.Mvc;

namespace Vũ_Trụ_Điện_Thoại.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
