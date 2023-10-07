using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieAppAPI.Dto;
using MovieAppAPI.Services;
using MovieAppDomain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UsersController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromForm] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            await _userService.RegisterUserAsync(registerDto);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user=await _userService.LoginUserAsync(loginDto);
           

            if (user == null)
                return BadRequest("Username or password incorrects.");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return BadRequest("Username or password incorrect.");

            string token = GenerateToken(user);

            return Ok(new {token});
        }
        private string GenerateToken(User user)
        {
            List<Claim> authclaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Secret").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expiretime = DateTime.Now.AddHours(1);
            var token = new JwtSecurityToken(
                claims: authclaims, 
                expires: expiretime, 
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            //CookieOptions cookieOptions = new CookieOptions()
            //{
            //    Expires = expiretime,
            //    Secure = true
            //};
            //Response.Cookies.Append("jwt-token", jwt, cookieOptions);

            return jwt;
        }
    }

}
