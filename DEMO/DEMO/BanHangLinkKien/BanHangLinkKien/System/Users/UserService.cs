//using BanHangLinkKien.Models;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace BanHangLinkKien.System.Users
//{
//    public class UserService : IUserService
//    {
//        private readonly UserManager<Account> _userManager;
//        private readonly SignInManager<Account> _signInManager;
//        private readonly RoleManager<Account> _roleManager;
//        private readonly IConfiguration _config;
//        public UserService(UserManager<Account> userManager, SignInManager<Account> signInManager, RoleManager<Account> roleManager, IConfiguration config) 
//        { 
//            _userManager=userManager;
//            _signInManager=signInManager;
//            _roleManager = roleManager;
//            _config = config;
//        }
       
//        public async Task<string> Authencate(LoginRequest request)
//        {
//            var user = await _userManager.FindByNameAsync(request.Email);
//            if (user == null) return null;
//            var result = _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
//            if (!result.IsCompletedSuccessfully)
//            {
//                return null;
//            }
//            var roles = await _userManager.GetRolesAsync(user);
//            var claims = new[]
//           {
//                new Claim(ClaimTypes.Email,user.Email),
//                //new Claim(ClaimTypes.Role, string.Join(";",roles)),

//            };
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
//                _config["Tokens:Issuer"],
//                claims,
//                expires: DateTime.Now.AddHours(3),
//                signingCredentials: creds);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        private Exception BanHangException(string v)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> Register(RegisterRequest request)
//        {
//            throw new NotImplementedException();
//        }

      
//    }
//}
