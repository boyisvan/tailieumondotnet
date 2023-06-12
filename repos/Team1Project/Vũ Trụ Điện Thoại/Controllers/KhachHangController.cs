using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vũ_Trụ_Điện_Thoại.Models;

namespace Vũ_Trụ_Điện_Thoại.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHangController
        vutrudienthoaiContext db = new vutrudienthoaiContext();
        public ActionResult Index()
        {
            List<KhachHang> khachhangs = db.KhachHangs.ToList();
            return View(khachhangs);
        }

        // GET: KhachHangController/Details/5
        public ActionResult Details(string makhachhang)
        {
            var chitietkhachhang = db.KhachHangs.SingleOrDefault(m=>m.MaKhachHang==makhachhang);
            return View(chitietkhachhang);
        }

        // GET: KhachHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhachHang khachHang)
        {
            try
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Loi", "Admin");
            }
        }

        // GET: KhachHangController/Edit/5
        public ActionResult Edit(string makhachhang)
        {
            var suakhachhang = db.KhachHangs.SingleOrDefault(m=>m.MaKhachHang == makhachhang);
            return View(suakhachhang);
        }

        // POST: KhachHangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhachHang khachHang)
        {
            try
            {
                var suakhachhang = db.KhachHangs.SingleOrDefault(m => m.MaKhachHang == khachHang.MaKhachHang);
                suakhachhang.MaNguoiDung = khachHang.MaNguoiDung;
                suakhachhang.Tuoi=khachHang.Tuoi;
                suakhachhang.SoDienThoai=khachHang.SoDienThoai;
                suakhachhang.Email=khachHang.Email;
                suakhachhang.DiaChi=khachHang.DiaChi;
                suakhachhang.GioiTinh=khachHang.GioiTinh;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Loi", "Admin");
            }
        }

        // GET: KhachHangController/Delete/5
        public ActionResult Delete(string makhachhang)
        {
            var xoakhachhang=db.KhachHangs.SingleOrDefault(m=>m.MaKhachHang==makhachhang);
            db.KhachHangs.Remove(xoakhachhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: KhachHangController/Delete/5
        
    }
}
