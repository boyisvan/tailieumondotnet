using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vũ_Trụ_Điện_Thoại.Models;

namespace Vũ_Trụ_Điện_Thoại.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMucController
        vutrudienthoaiContext db = new vutrudienthoaiContext();
        public ActionResult Index()
        {
            List<DanhMuc> danhmucs= db.DanhMucs.ToList();
            return View(danhmucs);
        }

        // GET: DanhMucController/Details/5
        public ActionResult Details(string MaDanhMuc)
        {
            var chitietdanhmuc = db.DanhMucs.SingleOrDefault(a=>a.MaDanhMuc == MaDanhMuc);
            return View(chitietdanhmuc);
        }

        // GET: DanhMucController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMucController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMuc danhMuc)
        {
            try
            {
                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Loi", "Admin");
            }
        }

        // GET: DanhMucController/Edit/5
        public ActionResult Edit(string MaDanhMuc)
        {
            var suadanhmuc = db.DanhMucs.SingleOrDefault(a => a.MaDanhMuc == MaDanhMuc);
            return View(suadanhmuc);
        }

        // POST: DanhMucController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMuc danhMuc)
        {
            try
            {
                var suadanhmuc = db.DanhMucs.SingleOrDefault(a => a.MaDanhMuc == danhMuc.MaDanhMuc);
                suadanhmuc.TenDanhMuc = danhMuc.TenDanhMuc;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Loi", "Admin");
            }
        }

        // GET: DanhMucController/Delete/5
        public ActionResult Delete(string MaDanhMuc)
        {
            var xoadanhmuc = db.DanhMucs.SingleOrDefault(a => a.MaDanhMuc == MaDanhMuc);
            db.DanhMucs.Remove(xoadanhmuc);
            db.SaveChanges() ;
            return RedirectToAction("Index");
        }
    }
}
