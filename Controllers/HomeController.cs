using Microsoft.AspNetCore.Mvc;
using PhamThiThuyQuynh_241230831.Models;
using System.Diagnostics;

namespace PhamThiThuyQuynh_241230831.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _context;

        public HomeController(QlhangHoaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var danhSachHangHoa = _context.HangHoas.Where(h => h.Gia >= 100).ToList();

            return View(danhSachHangHoa);
        }

        public IActionResult HienThiTheoLoai(int maloai)
        {
            var danhSachHang = _context.HangHoas.Where(h => h.MaLoai == maloai).ToList();

            return PartialView("PhamThiThuyQuynh_MainContent", danhSachHang);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
