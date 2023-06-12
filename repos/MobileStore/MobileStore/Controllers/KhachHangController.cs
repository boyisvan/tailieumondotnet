using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Models;
namespace MobileStore.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        StoresEntities db = new Models.StoresEntities();
        public ActionResult Index()
        {
            List<KhachHang> khachHangs = db.KhachHang.ToList();
            return View(khachHangs);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KhachHang khachHang)
        {
            db.KhachHang.Add(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string makhachhang)
        {
            ViewBag.makhachhang = makhachhang;
            KhachHang SuaKhachHang= db.KhachHang.SingleOrDefault(m => m.MaKhachHang == makhachhang);
            /* ChucVu SuaChucVu = db.ChucVu.Find(machucvu);*/
            return View(SuaKhachHang);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang khachHang)
        {
            var SuaKhachHang = db.KhachHang.SingleOrDefault(m => m.MaKhachHang == khachHang.MaKhachHang);
            /* SuaChucVu.MaChucVu = chucVu.MaChucVu;*/
            SuaKhachHang.MaNguoiDung= khachHang.MaNguoiDung;
            SuaKhachHang.TenKhachHang= khachHang.TenKhachHang;
            SuaKhachHang.Tuoi = khachHang.Tuoi;
            SuaKhachHang.SoDienThoai = khachHang.SoDienThoai;
            SuaKhachHang.Email = khachHang.Email;
            SuaKhachHang.DiaChi = khachHang.DiaChi;
            SuaKhachHang.GioiTinh = khachHang.GioiTinh;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string makhachhang)
        {
            ViewBag.makhachhang = makhachhang;
            var ChiTietKhachHang = db.KhachHang.SingleOrDefault(m => m.MaKhachHang == makhachhang);
            return View(ChiTietKhachHang);
        }
        public ActionResult Delete(string makhachhang)
        {
            var XoaKhachHang = db.KhachHang.SingleOrDefault(m => m.MaKhachHang == makhachhang);
            db.KhachHang.Remove(XoaKhachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}