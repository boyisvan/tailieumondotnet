using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vũ_Trụ_Điện_Thoại.Models;

namespace Vũ_Trụ_Điện_Thoại.Controllers
{
    public class ChucVuController : Controller
    {
        // GET: ChucVuController
        vutrudienthoaiContext db = new vutrudienthoaiContext ();
        public ActionResult Index()
        {
            List<ChucVu> chucVus= db.ChucVus.ToList ();
            return View(chucVus);
        }

        // GET: ChucVuController/Details/5
        public ActionResult Details(string MaChucVu)
        {
            var chitiettimkiem = db.ChucVus.SingleOrDefault(m=>m.MaChucVu==MaChucVu);
            return View(chitiettimkiem);
        }

        // GET: ChucVuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChucVuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChucVu chucVu)
        {
            try
            {
                db.ChucVus.Add(chucVu);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Loi", "Admin");
            }
        }

        // GET: ChucVuController/Edit/5
        public ActionResult Edit(string machucvu)
        {
            var suachucvu = db.ChucVus.SingleOrDefault(c => c.MaChucVu == machucvu);
            return View(suachucvu);
        }

        // POST: ChucVuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChucVu chucVu)
        {
            try
            {
                var suachucvu = db.ChucVus.SingleOrDefault(c => c.MaChucVu == chucVu.MaChucVu);
                suachucvu.TenChucVu= chucVu.TenChucVu;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Loi", "Admin");
            }
        }

        // GET: ChucVuController/Delete/5
        public ActionResult Delete(string machucvu)
        {
            var xoachucvu = db.ChucVus.SingleOrDefault(m => m.MaChucVu == machucvu);
            db.ChucVus.Remove(xoachucvu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
