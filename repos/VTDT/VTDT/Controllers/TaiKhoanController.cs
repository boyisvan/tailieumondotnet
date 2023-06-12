using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VTDT.Models;

namespace VTDT.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        vutrudienthoaiEntities db = new Models.vutrudienthoaiEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSachTaiKhoan()
        {
            // lấy danh sách tài khoản ở database
            List<TaiKhoan> taiKhoans = db.TaiKhoan.ToList();
            return View(taiKhoans);
        }
        public ActionResult ThemMoiTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiTaiKhoan(TaiKhoan taiKhoan)
        {
            //thêm bản ghi mới
            db.TaiKhoan.Add(taiKhoan);
            //lưu lại thay đổi 
            db.SaveChanges();
            return RedirectToAction("DanhSachTaiKhoan");
        }
        public ActionResult SuaTaiKhoan(string manguoidung)
        {
            vutrudienthoaiEntities db = new Models.vutrudienthoaiEntities();
            //var SuaTaiKhoan = db.TaiKhoan.SingleOrDefault(m => m.MaNguoiDung== MaNguoiDung);
            //cách 2 
            TaiKhoan SuaTaiKhoan = db.TaiKhoan.Find(manguoidung);
            return View(SuaTaiKhoan);
        }
        [HttpPost]
        public ActionResult SuaTaiKhoan(TaiKhoan taiKhoan)
        {
            vutrudienthoaiEntities db = new Models.vutrudienthoaiEntities();
            //var SuaTaiKhoan = db.TaiKhoan.SingleOrDefault(m => m.MaNguoiDung== MaNguoiDung);
            //Tìm đối tượng
            var SuaTaiKhoan = db.TaiKhoan.Find(taiKhoan.MaNguoiDung);
            //gán giá trị
            SuaTaiKhoan.MaNguoiDung = taiKhoan.MaNguoiDung;
            SuaTaiKhoan.TenTaiKhoan = taiKhoan.TenTaiKhoan;
            SuaTaiKhoan.MatKhau = taiKhoan.MatKhau;
            SuaTaiKhoan.LoaiTaiKhoan = taiKhoan.LoaiTaiKhoan;
            //lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("DanhSachTaiKhoan");
        }
        public ActionResult XoaTaiKhoan(TaiKhoan taiKhoan)
        {
            vutrudienthoaiEntities db = new Models.vutrudienthoaiEntities();
            var XoaTaiKhoan = db.TaiKhoan.Find(taiKhoan.MaNguoiDung);
            db.TaiKhoan.Remove(XoaTaiKhoan);
            return RedirectToAction("DanhSachTaiKhoan");
        }
    }
}