using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using storeBL;
using storeDAL;
using storeModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user= new User();
        private readonly IConfiguration _configuration;

        private readonly IUserService _IUserService;

        public AuthController(IConfiguration configuration, IUserService IUserService)
        {
            this._configuration= configuration;
            _IUserService = IUserService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody]UserDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _IUserService.AddUser(request.Username, request.Password);
            user.Username = request.Username;   
          
           
            return Ok(($"User :{0} created successfully",user.Username));
        }


        [HttpPost("login")]
        public ActionResult<User> Login([FromBody]UserDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _IUserService.GetUser(request.Username,request.Password);

            if (result.isSuccess) {
                return Ok(result.message );
            }
            else
                return BadRequest(result.message);


        }

    }
}
