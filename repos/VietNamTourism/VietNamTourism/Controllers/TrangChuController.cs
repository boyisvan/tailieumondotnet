using Microsoft.AspNetCore.Mvc;
using VietNamTourism.Models;

namespace VietNamTourism.Controllers
{
    public class TrangChuController : Controller
    {
        vietnamContext db = new vietnamContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string tendangnhap, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var data = db.Taikhoans.Where(s => s.Tendangnhap.Equals(tendangnhap) && s.Matkhau.Equals(matkhau)).ToList();
                if (data.Count() > 0)
                {
                    var checkrole = data.SingleOrDefault(m => m.Maquyen == "0");
                    if (checkrole == null)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public IActionResult DangKi()
        {
            return View();
        }
    }
}
