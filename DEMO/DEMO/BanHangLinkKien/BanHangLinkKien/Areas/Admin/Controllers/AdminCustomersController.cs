using System;
using Microsoft.AspNetCore.Mvc;
using BanHangLinkKien.Models;
using Newtonsoft.Json;

namespace BanHangLinkKien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCustomersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Account> reservationList = new List<Account>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7020/Accounts/GetFullAccounts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ResData res = new ResData();
                    res = JsonConvert.DeserializeObject<ResData>(apiResponse);
                    foreach(var item in res.Data)
                    {
                        Account ac = new Account();
                        ac.Email=item.email;
                        ac.Password = item.password;
                        reservationList.Add(ac);
                    }

                    ViewBag.data = reservationList;
                }
            }
           
            return View();
        }
           
    }
}
