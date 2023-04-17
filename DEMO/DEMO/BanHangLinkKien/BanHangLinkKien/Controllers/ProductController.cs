using BanHangLinkKien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanHangLinkKien.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoplinkkienContext _context;
        public ProductController(ShoplinkkienContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProductId == id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
