using BanHangLinkKien.System.Users;

namespace BanHangLinkKien.Areas.Admin.Controllers
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
    }
}