using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VieTorism.Models;

namespace VieTorism.Controllers
{
    public class SanPhamController : Controller
    {
        vietnamtorismContext db = new vietnamtorismContext();
        private readonly IWebHostEnvironment webHostEnvironment;

        public SanPhamController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Sanpham> sanphams = db.Sanphams.ToList();
            return View(sanphams);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Madanhmuc = GetSelectList();
            Sanpham sanpham = new Sanpham();
            return View(sanpham);
        }
        [HttpPost]
        public ActionResult Create(Sanpham sanpham)
        {
            string tenfileduynhat = UploadFile(sanpham);
            sanpham.Anh = tenfileduynhat;
            db.Attach(sanpham);
            db.Entry(sanpham).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private string UploadFile(Sanpham sanpham)
        {
            string tenfileduynhat = null;

            if (sanpham.Anhtailen != null)
            {
                string forderTaiLen = Path.Combine(webHostEnvironment.WebRootPath, "images");
                tenfileduynhat = Guid.NewGuid().ToString() + "_" + sanpham.Anhtailen.FileName ;
                string filePath  = Path.Combine(forderTaiLen, tenfileduynhat);  
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    sanpham.Anhtailen.CopyTo(fileStream);
                }
            }
            return tenfileduynhat;
        }
        private List<SelectListItem> GetSelectList()
        {
            var listdanhmuc = new List<SelectListItem>();
            listdanhmuc = db.Danhmucs.Select(x => new SelectListItem
            {
                Value = x.Madanhmuc.ToString(),
                Text = x.Tendanhmuc,
            }).ToList();

            var dmyItem = new SelectListItem()
            {
                Value = null,
                Text = "---Chọn danh mục---",
            };
            listdanhmuc.Insert(0, dmyItem);
            return listdanhmuc;
        }


        public IActionResult Edit(string tensanpham)
        {
            ViewBag.tensanpham = tensanpham;
            //Sanpham Sua = db.Sanphams.SingleOrDefault(m => m.Tensanpham == tensanpham);
            //Sanpham Sua = db.Sanphams.Find(tensanpham);
            return View();
        }
        /*[HttpPost]
        public IActionResult Edit(string tensanpham,IFormFile Anhtailen)
        {
            ViewBag.tensanpham = tensanpham;;
            return View();
        }*/
        /*public ActionResult Edit(TaiKhoan taiKhoan)
        {
            var SuaTaiKhoan = db.TaiKhoan.SingleOrDefault(m => m.MaNguoiDung == taiKhoan.MaNguoiDung);
            SuaChucVu.MaChucVu = chucVu.MaChucVu;
        SuaTaiKhoan.TenTaiKhoan = taiKhoan.TenTaiKhoan;
        SuaTaiKhoan.MatKhau = taiKhoan.MatKhau;
        SuaTaiKhoan.LoaiTaiKhoan = taiKhoan.LoaiTaiKhoan;
        db.SaveChanges();
        return RedirectToAction("Index");
    }*/

    public ActionResult Details(string manguoidung)
    {
        ViewBag.manguoidung = manguoidung;
        var ChiTiet = db.Sanphams.SingleOrDefault(m => m.Tensanpham == manguoidung);
        return View(ChiTiet);
    }
        public IActionResult Delete(string tenxoa)
        {
            var Xoa = db.Sanphams.SingleOrDefault(m => m.Tensanpham == tenxoa);
            db.Sanphams.Remove(Xoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
