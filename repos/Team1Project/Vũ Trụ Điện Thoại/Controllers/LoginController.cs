using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;
using Vũ_Trụ_Điện_Thoại.Models;

namespace Vũ_Trụ_Điện_Thoại.Controllers
{
    public class LoginController : Controller
    {
        vutrudienthoaiContext db = new vutrudienthoaiContext();
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangNhap(string tentaikhoan,string matkhau)
        {
            if (ModelState.IsValid)
            {
                var data = db.TaiKhoans.Where(s => s.TenTaiKhoan.Equals(tentaikhoan) && s.MatKhau.Equals(matkhau)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    /*Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().idUser;*/
                    var checkrole = data.SingleOrDefault(m=>m.LoaiTaiKhoan=="admin");
                    if (checkrole == null)
                    {
                        TempData["session"] = true;
                        return RedirectToAction("Index","Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index","User");
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
        public ActionResult DangKi(TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var check = db.TaiKhoans.FirstOrDefault(s => s.MaNguoiDung == taiKhoan.MaNguoiDung);
                if (check == null)
                {
                    /*db.Configuration.ValidateOnSaveEnabled = false;*/
                    db.TaiKhoans.Add(taiKhoan);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap");
                }
                else
                {
                    ViewBag.error = "Mã người dùng đã tồn tại";
                    return View();
                }
            }
            return View();
        }

        /*public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }*/

    }
}
