using Microsoft.AspNetCore.Mvc;
using VieTorism.Models;

namespace VieTorism.Controllers
{
    public class PhanHoiController : Controller
    {
        vietnamtorismContext db = new vietnamtorismContext();
        public IActionResult Index()
        {
            List<Phanhoi> Phanhoi = db.Phanhois.ToList();
            return View(Phanhoi);
        }
    }
}
