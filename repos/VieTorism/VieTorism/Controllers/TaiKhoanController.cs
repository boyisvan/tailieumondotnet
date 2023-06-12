using Microsoft.AspNetCore.Mvc;
using VieTorism.Models;

namespace VieTorism.Controllers
{
    public class TaiKhoanController : Controller
    {
        vietnamtorismContext db = new vietnamtorismContext();
        public IActionResult Index()
        {
            List<Taikhoan> taikhoans = db.Taikhoans.ToList();
            return View(taikhoans);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Taikhoan taiKhoan)
        {
            db.Taikhoans.Add(taiKhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string tendangnhap)
        {
            ViewBag.tendangnhap = tendangnhap;
            Taikhoan Sua = db.Taikhoans.SingleOrDefault(m => m.Tendangnhap == tendangnhap);
            //ChucVu SuaChucVu = db.ChucVu.Find(machucvu);
            return View(Sua);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Taikhoan taiKhoan)
        {
            var sua = db.Taikhoans.SingleOrDefault(m => m.Tendangnhap == taiKhoan.Tendangnhap);
            sua.Matkhau = taiKhoan.Matkhau;
            sua.Trangthai = taiKhoan.Trangthai;
            sua.Role = taiKhoan.Role;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(string tendangnhap)
        {
            var taiKhoan = db.Taikhoans.SingleOrDefault(m => m.Tendangnhap == tendangnhap);
            return View(taiKhoan);
        }
        public IActionResult Delete(string tendangnhap)
        {
            var taiKhoan = db.Taikhoans.SingleOrDefault(m => m.Tendangnhap == tendangnhap);
            db.Taikhoans.Remove(taiKhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
