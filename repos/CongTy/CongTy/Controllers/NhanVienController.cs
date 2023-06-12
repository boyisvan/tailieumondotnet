using CongTy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CongTy.Controllers
{
    public class NhanVienController : Controller
    {
        CongTyContext db = new CongTyContext();

        // GET: NhanVienController
        public ActionResult Index()
        {
            List<NhanVien> nhanviens= db.NhanViens.ToList();
            return View(nhanviens);
        }

        // GET: NhanVienController/Details/5
        public ActionResult Details(string manv)
        {
            var ChiTiet = db.NhanViens.SingleOrDefault(m=>m.MaNv==manv);
            return View(ChiTiet);
        }

        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVienController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NhanVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVienController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NhanVienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
