using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Vũ_Trụ_Điện_Thoại.Models;

namespace Vũ_Trụ_Điện_Thoại.Controllers
{

    public class TaiKhoanController : Controller
    {
        vutrudienthoaiContext db = new vutrudienthoaiContext();
        public IActionResult Index()
        {
            List<TaiKhoan> taikhoans = db.TaiKhoans.ToList();
            return View(taikhoans);
        }
        [HttpGet]
        public IActionResult Details(string MaNguoiDung)
        {
            var taiKhoan = db.TaiKhoans.SingleOrDefault(m=>m.MaNguoiDung== MaNguoiDung);
            return View(taiKhoan);
        }
        public IActionResult Delete(string manguoidung)
        {
            var xoataikhoan = db.TaiKhoans.SingleOrDefault(m => m.MaNguoiDung == manguoidung);
            db.TaiKhoans.Remove(xoataikhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string manguoidung)
        {
            TaiKhoan suataikhoan = db.TaiKhoans.Find(manguoidung);
            return View(suataikhoan);
        }
        [HttpPost]
        public IActionResult Edit(TaiKhoan taiKhoan)
        {
            try
            {
                var suataikhoan = db.TaiKhoans.Find(taiKhoan);
                suataikhoan.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                suataikhoan.MatKhau = taiKhoan.MatKhau;
                suataikhoan.LoaiTaiKhoan = taiKhoan.LoaiTaiKhoan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Loi", "Admin");
            }
        }



        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string giatritimkiem)
        {
            giatritimkiem = Request.Form[giatritimkiem].ToString();
            List<TaiKhoan> taikhoans = db.TaiKhoans.ToList();
            var ketqua = from TaiKhoan in taikhoans where TaiKhoan.TenTaiKhoan == giatritimkiem select TaiKhoan;
            foreach(var item  in ketqua)
            {

            }
            return View(ketqua);
        }
    }
}
