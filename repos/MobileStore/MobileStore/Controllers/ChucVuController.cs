using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Models;
namespace MobileStore.Controllers
{
    public class ChucVuController : Controller
    {
        StoresEntities db = new Models.StoresEntities();
        // GET: ChucVu
        public ActionResult Index()
        {
            List<ChucVu> chucVus = db.ChucVu.ToList();
            return View(chucVus);
        }
        public ActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(ChucVu chucVu)
        {
            db.ChucVu.Add(chucVu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string machucvu)
        {
            ViewBag.machucvu = machucvu;
            ChucVu SuaChucVu = db.ChucVu.SingleOrDefault(m => m.MaChucVu == machucvu);
           /* ChucVu SuaChucVu = db.ChucVu.Find(machucvu);*/
            return View(SuaChucVu);
        }
        [HttpPost]
        public ActionResult Edit(ChucVu chucVu)
        {
            var SuaChucVu= db.ChucVu.SingleOrDefault(m => m.MaChucVu == chucVu.MaChucVu);
           /* SuaChucVu.MaChucVu = chucVu.MaChucVu;*/
            SuaChucVu.TenChucVu = chucVu.TenChucVu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string machucvu)
        {
            ViewBag.machucvu = machucvu;
            var ChiTietChucVu = db.ChucVu.SingleOrDefault(m => m.MaChucVu == machucvu);
            return View(ChiTietChucVu);
        }
        public ActionResult Delete(string machucvu)
        {
            var ChiTietChucVu = db.ChucVu.SingleOrDefault(m => m.MaChucVu == machucvu);
            db.ChucVu.Remove(ChiTietChucVu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}