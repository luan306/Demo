using API_WebLinkkien.Models;
using API_WebLinkkien.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;


namespace API_WebLinkkien.Controllers
{
    [Route("[controller]/[Action]"), ApiController]
    public class AccountsController : ControllerBase
    {
        public readonly IAccountsService _accountService;
        public AccountsController(IAccountsService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetFullAccounts()
        {
            Response res = new Response();
            res.Data = await _accountService.GetAllAccounts();
            return res;
        }
        [HttpPost]
        public async Task<ActionResult<Response>>Login(string email, string password)
        {
            Response res = new Response();
            res.Data = await _accountService.Login(email, password);
            return res;
        }
        [HttpPut]
        public async Task<ActionResult<Response>>Register(string email, string password, string fullname, string phone)
        {
            Response res = new Response();
            res.Data = await _accountService.Register(email, password, fullname, phone);
            return res;
        }
    }
}
