using API_WebLinkkien.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using API_WebLinkkien.Data;

namespace API_WebLinkkien.Service
{
    public interface IAccountsService
    {
        public Task<Response> GetAllAccounts();
        public Task<Response> Login(string email, string password);
        public Task<Response> Register(string email, string password, string fullname, string phone);
    }
    public class AccountsService : IAccountsService
    {
        public readonly IConnectData _connectdata;

        public AccountsService(IConnectData connectdata)
        {
            _connectdata = connectdata;
        }

        public async Task<Response> GetAllAccounts()
        {
            
            DataTable dt = new DataTable();
            dt = _connectdata.DataConnect("SELECT * FROM Accounts");
            Response response = new Response();
            List<Accounts> accountList = new List<Accounts>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Accounts account = new Accounts();
                    account.AccountId = Convert.ToUInt16(dt.Rows[i]["AccountID"]);
                    account.Fullname = Convert.ToString(dt.Rows[i]["Fullname"]);
                    account.Phone = Convert.ToString(dt.Rows[i]["Phone"]);
                    //account.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
                    //account.Active = Convert.ToUInt16(dt.Rows[i]["Active"]);
                    accountList.Add(account);
                }
            }
            if (accountList.Count > 0)
            {
                response.StatusCode = 1;
                response.ErrorMessage = "None";
                response.Data = accountList;
            }
            else
            {
                response.StatusCode = 0;
                response.ErrorMessage = "No data return";
            }
            return response;
        }
        public async Task<Response>Login(string email, string password)
        {
            DataTable dt = new DataTable();
            dt = _connectdata.DataConnect(string.Format("select * from Accounts where Email = '{0}' and Password = '{1}'",email,password));
            Response response = new Response();
            List<Accounts> accountList = new List<Accounts>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Accounts account = new Accounts();
                    account.AccountId = Convert.ToUInt16(dt.Rows[i]["AccountID"]);
                    account.Fullname = Convert.ToString(dt.Rows[i]["Fullname"]);
                    account.Phone = Convert.ToString(dt.Rows[i]["Phone"]);
                    account.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
                    account.Active = Convert.ToUInt16(dt.Rows[i]["Active"]);
                    accountList.Add(account);
                }
            }
            if (accountList.Count > 0)
            {
                response.StatusCode = 1;
                response.ErrorMessage = "Login Successfull";
                response.Data = accountList;
            }
            else
            {
                response.StatusCode = 0;
                response.ErrorMessage = "Login fail";
            }
            return response;
        }
        public async Task<Response>Register(string email, string password, string fullname, string phone)
        {
            DataTable dt = new DataTable();
            Response response = new Response();

            dt = _connectdata.DataConnect(string.Format("select * from Accounts where Email = '{0}'", email));
           if(dt.Rows.Count >0)
            {
                response.StatusCode = 0;
                response.ErrorMessage = "Email already exist";
            }
            else
            {
                int result = 0;
                result = _connectdata.DataConnectInsert(string.Format("INSERT INTO Accounts(Phone, FullName, Email, Password,CreateDate) values('{0}',N'{1}','{2}','{3}','{4}')", phone, fullname, email, password, DateTime.Now));

                if (result == 1)
                {
                    response.StatusCode = 1;
                    response.ErrorMessage = "register Successfull";

                }
                else
                {
                    response.StatusCode = 0;
                    response.ErrorMessage = "register fail";
                }
                
            }
            
            return response;
        }
    }
}
