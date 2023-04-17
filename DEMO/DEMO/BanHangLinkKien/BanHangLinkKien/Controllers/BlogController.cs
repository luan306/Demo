using Microsoft.AspNetCore.Mvc;

namespace BanHangLinkKien.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
