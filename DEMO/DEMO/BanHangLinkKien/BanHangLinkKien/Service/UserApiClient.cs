using BanHangLinkKien.System.Users;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BanHangLinkKien.Service
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserApiClient(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory=httpClientFactory;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new  StringContent(json,Encoding.UTF8,"application/json");
            var httpClient = new HttpClient();
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7020");
            var response = await client.PostAsync("/Accounts/GetFullAccounts", httpContent);
            //var response = await httpClient.GetAsync("https://localhost:7020/Accounts/GetFullAccounts");
            var token= await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}
