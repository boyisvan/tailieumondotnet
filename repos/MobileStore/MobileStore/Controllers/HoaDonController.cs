using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        StoresEntities db = new Models.StoresEntities();
        // GET: ChucVu
        public ActionResult Index()
        {
            List<HoaDon> hoaDons = db.HoaDon.ToList();
            return View(hoaDons);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HoaDon hoaDon)
        {
            db.HoaDon.Add(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string mahoadon)
        {
            ViewBag.mahoadon = mahoadon;
            HoaDon SuaHoaDon = db.HoaDon.SingleOrDefault(m => m.MaHoaDon == mahoadon);
            /* ChucVu SuaChucVu = db.ChucVu.Find(machucvu);*/
            return View(SuaHoaDon);
        }
        [HttpPost]
        public ActionResult Edit(HoaDon hoaDon)
        {
            var SuaHoaDon = db.HoaDon.SingleOrDefault(m => m.MaHoaDon == hoaDon.MaHoaDon);
            /* SuaChucVu.MaChucVu = chucVu.MaChucVu;*/
            SuaHoaDon.MaSanPham = hoaDon.MaSanPham;
            SuaHoaDon.MaKhachHang = hoaDon.MaKhachHang;
            SuaHoaDon.MaNhanVien= hoaDon.MaNhanVien;
            SuaHoaDon.SoLuong = hoaDon.SoLuong;
            SuaHoaDon.TongTienThanhToan = hoaDon.TongTienThanhToan;
            SuaHoaDon.Ngay = hoaDon.Ngay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string mahoadon)
        {
            ViewBag.mahoadon = mahoadon;
            var ChiTietHoaDon = db.HoaDon.SingleOrDefault(m => m.MaHoaDon == mahoadon);
            return View(ChiTietHoaDon);
        }
        public ActionResult Delete(string mahoadon)
        {
            var ChiTietHoaDon = db.HoaDon.SingleOrDefault(m => m.MaHoaDon== mahoadon);
            db.HoaDon.Remove(ChiTietHoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}