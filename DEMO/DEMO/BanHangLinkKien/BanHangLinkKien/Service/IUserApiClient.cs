using BanHangLinkKien.System.Users;

namespace BanHangLinkKien.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);   
    }
}
