using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Models;
namespace MobileStore.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        StoresEntities db = new Models.StoresEntities();
        // GET: ChucVu
        public ActionResult Index()
        {
            List<DanhMuc> danhMucs = db.DanhMuc.ToList();
            return View(danhMucs);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DanhMuc danhMuc)
        {
            db.DanhMuc.Add(danhMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string madanhmuc)
        {
            ViewBag.madanhmuc = madanhmuc;
            DanhMuc SuaDanhMuc = db.DanhMuc.SingleOrDefault(m => m.MaDanhMuc == madanhmuc);
            return View(SuaDanhMuc);
        }
        [HttpPost]
        public ActionResult Edit(DanhMuc danhMuc)
        {
            var SuaDanhMuc = db.DanhMuc.SingleOrDefault(m => m.MaDanhMuc == danhMuc.MaDanhMuc);
            SuaDanhMuc.TenDanhMuc = danhMuc.TenDanhMuc;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string madanhmuc)
        {
            ViewBag.madanhmuc = madanhmuc;
            var ChiTietDanhMuc = db.DanhMuc.SingleOrDefault(m => m.MaDanhMuc == madanhmuc);
            return View(ChiTietDanhMuc);
        }
        public ActionResult Delete(string madanhmuc)
        {
            var ChiTietDanhMuc = db.DanhMuc.SingleOrDefault(m => m.MaDanhMuc == madanhmuc);
            db.DanhMuc.Remove(ChiTietDanhMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}