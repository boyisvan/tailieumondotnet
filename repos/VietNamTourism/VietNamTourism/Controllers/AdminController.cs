using Microsoft.AspNetCore.Mvc;
using VietNamTourism.Models;

namespace VietNamTourism.Controllers
{
    public class AdminController : Controller
    {
        vietnamContext db = new vietnamContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PhanHoi()
        {
            List<Phanhoi> phanhois= db.Phanhois.ToList();
            return View(phanhois);
        }

        //Quản lí phản hồi
        public IActionResult ThemPhanHoi()
        {
            return View();
        }
    }
}
