using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vũ_Trụ_Điện_Thoại.Models;

namespace Vũ_Trụ_Điện_Thoại.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVienController
        vutrudienthoaiContext db= new vutrudienthoaiContext();
        public ActionResult Index()
        {
            List<NhanVien> nhanviens=db.NhanViens.ToList();
            return View(nhanviens);
        }

        // GET: NhanVienController/Details/5
        public ActionResult Details(string manhanvien)
        {
            var chitiet = db.NhanViens.SingleOrDefault(m=>m.MaNhanVien==manhanvien);
            return View(chitiet);
        }

        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nhanVien)
        {
            try
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Loi", "Admin");
            }
        }

        // GET: NhanVienController/Edit/5
        public ActionResult Edit(string manhanvien)
        {
            var sua = db.NhanViens.SingleOrDefault(m => m.MaNhanVien == manhanvien);
            return View(sua);
        }

        // POST: NhanVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVien nhanVien)
        {
            try
            {
                var sua = db.NhanViens.SingleOrDefault(m => m.MaNhanVien == nhanVien.MaNhanVien);
                sua.MaNguoiDung = nhanVien.MaNguoiDung;
                sua.HoTen = nhanVien.MaNguoiDung;
                sua.DiaChi = nhanVien.MaNguoiDung;
                sua.SoDienThoai = nhanVien.MaNguoiDung;
                sua.Email = nhanVien.MaNguoiDung;
                sua.MaChucVu = nhanVien.MaNguoiDung;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Loi","Admin");
            }
        }

        // GET: NhanVienController/Delete/5
        public ActionResult Delete(string manhanvien)
        {
            var xoa = db.NhanViens.SingleOrDefault(m => m.MaNhanVien == manhanvien);
            db.NhanViens.Remove(xoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
