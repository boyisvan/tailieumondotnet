using Microsoft.AspNetCore.Mvc;
using VieTorism.Models;
namespace VieTorism.Controllers
{

    public class TrangChuController : Controller
    {
        vietnamtorismContext db = new vietnamtorismContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Phanhoi phanhoi)
        {
            db.Phanhois.Add(phanhoi);
            db.SaveChanges();
            return View();
        }   
    }
}
