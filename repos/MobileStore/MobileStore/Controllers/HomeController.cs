using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Models;
namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        StoresEntities db = new Models.StoresEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Thông tin của chúng tôi";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Phản hồi của bạn";

            return View();
        }
        /*[HttpPost]*/
        public ActionResult Login(string UserName ,string PassWord)
        {
            StoresEntities db = new Models.StoresEntities();
            UserName = Request.Form["UserName"];
            PassWord = Request.Form["PassWord"];
            /*var TimKiemNguoiDUng = db.TaiKhoan.Find(UserName);*/
            if (UserName == "1" && PassWord=="1")
            {
                return RedirectToAction("AdminPage");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(TaiKhoan taiKhoan)
        {
            List<TaiKhoan> taiKhoans = db.TaiKhoan.ToList();
            if (ModelState.IsValid)
            {
                var check = taiKhoans.SingleOrDefault(m => m.TenTaiKhoan == taiKhoan.TenTaiKhoan);
                if (check == null)
                {
                    taiKhoans.Add(taiKhoan);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Tên người dùng đã tồn tại";
                    return View();
                }
            }
            return View();
        }
        public ActionResult AdminPage()
        {
            return View();
        } 
        public ActionResult TrangChu()
        {
            return View();
        }
    }
}