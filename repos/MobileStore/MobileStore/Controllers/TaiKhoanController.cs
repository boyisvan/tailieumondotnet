using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Models;
namespace MobileStore.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        StoresEntities db = new Models.StoresEntities();
        public ActionResult Index()
        {
            List<TaiKhoan> taiKhoans = db.TaiKhoan.ToList();
            return View(taiKhoans);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TaiKhoan taiKhoan)
        {
            db.TaiKhoan.Add(taiKhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string manguoidung)
        {
            ViewBag.manguoidung = manguoidung;
            TaiKhoan SuaTaiKhoan = db.TaiKhoan.SingleOrDefault(m => m.MaNguoiDung == manguoidung);
            /* ChucVu SuaChucVu = db.ChucVu.Find(machucvu);*/
            return View(SuaTaiKhoan);
        }
        [HttpPost]
        public ActionResult Edit(TaiKhoan taiKhoan)
        {
            var SuaTaiKhoan = db.TaiKhoan.SingleOrDefault(m => m.MaNguoiDung == taiKhoan.MaNguoiDung);
            /* SuaChucVu.MaChucVu = chucVu.MaChucVu;*/
            SuaTaiKhoan.TenTaiKhoan = taiKhoan.TenTaiKhoan;
            SuaTaiKhoan.MatKhau = taiKhoan.MatKhau;
            SuaTaiKhoan.LoaiTaiKhoan = taiKhoan.LoaiTaiKhoan;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string manguoidung)
        {
            ViewBag.manguoidung = manguoidung;
            var ChiTietTaiKhoan = db.TaiKhoan.SingleOrDefault(m => m.MaNguoiDung == manguoidung);
            return View(ChiTietTaiKhoan);
        }
        public ActionResult Delete(string manguoidung)
        {
            var XoaTaiKhoan = db.TaiKhoan.SingleOrDefault(m => m.MaNguoiDung == manguoidung);
            db.TaiKhoan.Remove(XoaTaiKhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}