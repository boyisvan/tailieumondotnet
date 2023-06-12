using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VieTorism.Models;

namespace VieTorism.Controllers
{
    public class UserController : Controller
    {
        vietnamtorismContext db=new vietnamtorismContext();
        public IActionResult Index()
        {
            List<Sanpham> Sanpham = db.Sanphams.ToList();
            return View(Sanpham);
        }
        public IActionResult Detail(string tensanpham)
        {
            var chitiet = db.Sanphams.SingleOrDefault(s => s.Tensanpham == tensanpham);
            return View(chitiet);
        }
    }
}
