using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Models;
namespace MobileStore.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        StoresEntities db = new Models.StoresEntities();
        public ActionResult Index()
        {
            List<SanPham> sanPhams = db.SanPham.ToList();
            return View(sanPhams);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham sanPham)
        {
            db.SanPham.Add(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string masanpham)
        {
            ViewBag.masanpham = masanpham;
            SanPham SuaSanPham= db.SanPham.SingleOrDefault(m => m.MaSanPham == masanpham);
            /* ChucVu SuaChucVu = db.ChucVu.Find(machucvu);*/
            return View(SuaSanPham);
        }
        [HttpPost]
        public ActionResult Edit(SanPham sanPham)
        {
            var SuaSanPham= db.SanPham.SingleOrDefault(m => m.MaSanPham == sanPham.MaSanPham);
            /* SuaChucVu.MaChucVu = chucVu.MaChucVu;*/
            SuaSanPham.TenSanPham = sanPham.TenSanPham;
            SuaSanPham.MaDanhMuc = sanPham.MaDanhMuc;
            SuaSanPham.SoLuong = sanPham.SoLuong;
            SuaSanPham.Gia = sanPham.Gia;
            SuaSanPham.MoTa = sanPham.MoTa;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string masanpham)
        {
            ViewBag.masanpham = masanpham;
            var ChiTietSanPham = db.SanPham.SingleOrDefault(m => m.MaSanPham == masanpham);
            return View(ChiTietSanPham);
        }
        public ActionResult Delete(string masanpham)
        {
            var XoaSanPham = db.SanPham.SingleOrDefault(m => m.MaSanPham == masanpham);
            db.SanPham.Remove(XoaSanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}