using baikiemtra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baikiemtra.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public static List<NhanVien> nhanViens = new List<NhanVien>()
        {
            new NhanVien{MaNhanVien="1",HoTen="Duc Van",DiaChi="hà nội" },
            new NhanVien{MaNhanVien="2",HoTen="Hiền Lương",DiaChi="hà nội" },
            new NhanVien{MaNhanVien="3",HoTen="Gia Anh",DiaChi="hà nội" },
        };
        public ActionResult Index()
        {
            return View(nhanViens);
        }
        public ActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Creat(NhanVien nhanVien)
        {
            nhanViens.Add(nhanVien);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string MaNhanVien)
        {
            var SuaNhanVien = nhanViens.SingleOrDefault(m => m.MaNhanVien == MaNhanVien);
            return View(SuaNhanVien);
        }
        [HttpPost]
        public ActionResult Edit(NhanVien nhanVien)
        {
            var SuaNhanVien = nhanViens.SingleOrDefault(m => m.MaNhanVien == nhanVien.MaNhanVien);
            SuaNhanVien.MaNhanVien = nhanVien.MaNhanVien;
            SuaNhanVien.HoTen = nhanVien.HoTen;
            SuaNhanVien.DiaChi = nhanVien.DiaChi;
            nhanViens.Add(nhanVien);
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(string MaNhanVien)
        {
            var SuaNhanVien = nhanViens.SingleOrDefault(m => m.MaNhanVien == MaNhanVien);
            nhanViens.Remove(SuaNhanVien);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string MaNhanVien)
        {
            var SuaNhanVien = nhanViens.SingleOrDefault(m => m.MaNhanVien == MaNhanVien);
            return View(SuaNhanVien);
        }
    }
}