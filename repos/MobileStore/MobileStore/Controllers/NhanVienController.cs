using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Models;
namespace MobileStore.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        StoresEntities db = new Models.StoresEntities();
        public ActionResult Index()
        {
            List<NhanVien> nhanViens = db.NhanVien.ToList();
            return View(nhanViens);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanVien nhanVien)
        {
            db.NhanVien.Add(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string manhanvien)
        {
            ViewBag.makhachhang = manhanvien;
            NhanVien SuaKhachHang = db.NhanVien.SingleOrDefault(m => m.MaNhanVien == manhanvien);
            /* ChucVu SuaChucVu = db.ChucVu.Find(machucvu);*/
            return View(SuaKhachHang);
        }
        [HttpPost]
        public ActionResult Edit(NhanVien nhanVien)
        {
            var SuaNhanVien = db.NhanVien.SingleOrDefault(m => m.MaNhanVien == nhanVien.MaNhanVien);
            /* SuaChucVu.MaChucVu = chucVu.MaChucVu;*/
            SuaNhanVien.MaNguoiDung = nhanVien.MaNguoiDung;
            SuaNhanVien.HoTen = nhanVien.HoTen;
            SuaNhanVien.DiaChi = nhanVien.DiaChi;
            SuaNhanVien.SoDienThoai = nhanVien.SoDienThoai;
            SuaNhanVien.Email = nhanVien.Email;
            SuaNhanVien.MaChucVu = nhanVien.MaChucVu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string manhanvien)
        {
            ViewBag.manhanvien = manhanvien;
            var ChiTietNhanVien = db.NhanVien.SingleOrDefault(m => m.MaNhanVien == manhanvien);
            return View(ChiTietNhanVien);
        }
        public ActionResult Delete(string manhanvien)
        {
            var XoaNhanVien = db.NhanVien.SingleOrDefault(m => m.MaNhanVien == manhanvien);
            db.NhanVien.Remove(XoaNhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}