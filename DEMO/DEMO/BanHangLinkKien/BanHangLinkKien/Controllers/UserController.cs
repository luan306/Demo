using BanHangLinkKien.Service;
using BanHangLinkKien.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace BanHangLinkKien.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if(!ModelState.IsValid)
           
                return View(ModelState);
           var token = await _userApiClient.Authenticate(request);
            return View(token);
        }
    }
}
