using hoangducvann_deso1.Models;
using Microsoft.AspNetCore.Mvc;

namespace hoangducvann_deso1.Controllers
{
    public class MemberController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Creat()
        {
            return View();
        }
    }
}
