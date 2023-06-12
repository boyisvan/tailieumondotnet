using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VieTorism.Models;

namespace VieTorism.Controllers
{
    public class HomeController : Controller
    {
        vietnamtorismContext db = new vietnamtorismContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TrangChu()
        {
            ViewBag.sotaikhoan = db.Taikhoans.Count();
            ViewBag.sodanhmuc = db.Danhmucs.Count();
            ViewBag.sosanpham = db.Sanphams.Count();
            return View();
        }
    }
}