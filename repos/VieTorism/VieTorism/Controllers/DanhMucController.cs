using Microsoft.AspNetCore.Mvc;
using VieTorism.Models;

namespace VieTorism.Controllers
{
    public class DanhMucController : Controller
    {
        vietnamtorismContext db= new vietnamtorismContext();
        public IActionResult Index()
        {
            List<Danhmuc> danhmucs = db.Danhmucs.ToList();
            return View(danhmucs);
        }
        [HttpPost]
        public IActionResult Creat(Danhmuc danhmuc)
        {
            db.Danhmucs.Add(danhmuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string madanhmuc)
        {
            ViewBag.madanhmuc= madanhmuc;
            Danhmuc Sua = db.Danhmucs.SingleOrDefault(m => m.Madanhmuc == madanhmuc);
            return View(Sua);
        }
        [HttpPost]
        public ActionResult Edit(Danhmuc danhmuc)
        {
            var Sua = db.Danhmucs.SingleOrDefault(m => m.Madanhmuc == danhmuc.Madanhmuc);
            Sua.Tendanhmuc = danhmuc.Tendanhmuc;
            Sua.Trangthai = danhmuc.Trangthai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string madanhmuc)
        {
            ViewBag.madanhmuc = madanhmuc;
            var ChiTiet = db.Danhmucs.SingleOrDefault(m => m.Madanhmuc == madanhmuc);
            return View(ChiTiet);
        }
        public ActionResult Delete(string madanhmuc)
        {
            var Xoa= db.Danhmucs.SingleOrDefault(m => m.Madanhmuc == madanhmuc);
            db.Danhmucs.Remove(Xoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
