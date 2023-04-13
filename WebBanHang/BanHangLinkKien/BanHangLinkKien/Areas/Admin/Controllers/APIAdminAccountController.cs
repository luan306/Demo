using BanHangLinkKien.Models;
using BanHangLinkKien.Models.AccountModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanHangLinkKien.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIAdminAccountController : ControllerBase
    {
        ShoplinkkienContext db = new ShoplinkkienContext();
        [HttpGet]
        public IEnumerable<ApiAccount> GetAccounts()
        {
            var acount  = (from p in db.Accounts select new ApiAccount
                {
                    
                    Email= p.Email,
                    Password= p.Password

                }).ToList();
            return acount;
        }
    }
}
