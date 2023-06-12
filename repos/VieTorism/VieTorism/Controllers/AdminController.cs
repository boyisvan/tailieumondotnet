using Microsoft.AspNetCore.Mvc;

namespace VieTorism.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
