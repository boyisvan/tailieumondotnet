using Microsoft.AspNetCore.Mvc;
using VieTorism.Models;

namespace VieTorism.Controllers
{
    public class LoginController : Controller
    {
        vietnamtorismContext db = new vietnamtorismContext();
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangNhap(string tendangnhap, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var data = db.Taikhoans.Where(s => s.Tendangnhap.Equals(tendangnhap) && s.Matkhau.Equals(matkhau)).ToList();
                if (data.Count() > 0)
                {
                    var checkrole = data.SingleOrDefault(m => m.Role == "1");
                    if (checkrole != null)
                    {
                        return RedirectToAction("TrangChu", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("DangNhap");
                }
            }
            return View();
        }
        public IActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKi(Taikhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var check = db.Taikhoans.FirstOrDefault(s => s.Tendangnhap == taiKhoan.Tendangnhap);
                if (check == null)
                {
                    db.Taikhoans.Add(taiKhoan);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap");
                }
                else
                {
                    ViewBag.error = "Tên người dùng đã tồn tại";
                    return View();
                }
            }
            return View();
        }
    }
}
