using Microsoft.AspNetCore.Mvc;
using quanlisinhvien.Models;
using System.Security.Cryptography.X509Certificates;
namespace quanlisinhvien.Controllers
{
    public class SVController : Controller
    {
        public List<sinhvien> sinhvien = new List<sinhvien>()
        {
            new sinhvien(){MaSv="sv01",HoTen="hoang duc van",DiaChi="Thái bình"},
            new sinhvien(){MaSv="sv02",HoTen="nguyen thuy duc",DiaChi="nghệ an"},
            new sinhvien(){MaSv="sv03",HoTen="Nguyễn Phú Trang",DiaChi="quốc oai"},
            new sinhvien(){MaSv="sv4",HoTen="Hoàng Văn Tuyển",DiaChi="hà nội"}
        };
        public IActionResult Index()
        {
            
            return View(sinhvien);
        }
        public ActionResult UserModel(sinhvien model)
        {
            String Masinhvien = model.MaSv;
            String Hotensinhvienn = model.HoTen;
            String Diachisinhvien = model.DiaChi;
            new sinhvien() { MaSv = Masinhvien, HoTen = Hotensinhvienn, DiaChi = Diachisinhvien };

            return View(sinhvien);
        }
    }
}
