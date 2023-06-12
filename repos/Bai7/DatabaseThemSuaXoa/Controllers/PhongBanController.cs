using DatabaseThemSuaXoa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseThemSuaXoa.Controllers
{
    public class PhongBanController : Controller
    {
        CongTyContext _context = new CongTyContext(); 
        public IActionResult Index()
        {
            PhongBan phongbans = _context.PhongBans.ToList();
            return View(phongbans);
        }
    }
}
