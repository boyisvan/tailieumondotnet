using Microsoft.AspNetCore.Mvc;
using Vũ_Trụ_Điện_Thoại.Models;

namespace Vũ_Trụ_Điện_Thoại.Controllers
{
    public class AdminController : Controller
    {
        vutrudienthoaiContext db= new vutrudienthoaiContext();
        public IActionResult Index()
        {
            ViewBag.sochucvu= db.ChucVus.Count();
            ViewBag.sodanhmuc= db.DanhMucs.Count();
            ViewBag.sohoadon= db.HoaDons.Count();
            ViewBag.sokhachhang= db.KhachHangs.Count();
            ViewBag.sonhanvien= db.NhanViens .Count();
            ViewBag.sosanpham= db.SanPhams.Count();
            ViewBag.sotaikhoan= db.TaiKhoans.Count();
            return View();
        }
        public IActionResult Loi()
        {
            return View();
        }
    }

}
