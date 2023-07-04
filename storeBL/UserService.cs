using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using storeDAL;
using storeModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace storeBL
{
    public interface IUserService
    {
        public void AddUser(string username, string password);
        public void RemoveUser(string username);
        public List<User> GetAllUsers();
        public Result GetUser(string username, string password);
        public string CreateToken(User user);
    }
    public class UserService: IUserService
    {
        private readonly IUserManager _IUserManager;
        private readonly IConfiguration _Configuration;
        public UserService(IUserManager IUserManager, IConfiguration configuration)
        {
            _IUserManager = IUserManager;
            _Configuration = configuration;
        }
        public void AddUser(string username, string password)
        {
            _IUserManager.AddUser(username, password);
        }
        public void RemoveUser(string username)
        {
            _IUserManager.RemoveUser(username);
        }
        public List<User> GetAllUsers()
        {
            return _IUserManager.GetAllUsers();
        }
        public Result GetUser(string username, string password)
        {
            Result res = new Result();
            var user= _IUserManager.GetUser(username);
            if (user == null || user.Username == string.Empty)
            {
                res.isSuccess = false;
                res.message = "user not found";
                return res;
             
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user?.Passwordhash))
            {
                res.isSuccess = false;
                res.message = "Wrong password";
                return res;
            }
            string token = CreateToken(user);
            res.message = token;
            return res;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Name, user.Username) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}