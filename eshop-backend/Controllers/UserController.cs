using eshop_backend.Helpers;
using eshop_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace my_eshop_api.Controllers
{
    [Route("api/users")]
    [EnableCors("angular_eshop_AllowSpecificOrigins")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EshopContext Context;
        private readonly AppSettings AppSettings;

        public UserController(EshopContext context, 
            IOptions<AppSettings> appSettings)
        {
            Context = context;
            AppSettings = appSettings.Value;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User formParams)
        {
            if (formParams == null || formParams.Password == null)
                return BadRequest(new { message = "Log in failed" });

            var user = await Context.Users
                .SingleOrDefaultAsync(x => x.Username == formParams.Username);

            if (user == null || user.Password == null)
                return BadRequest(new { message = "Log in failed" });

            if (!PasswordHasher
                .VerifyPassword(formParams.Password, user.Password))
                return BadRequest(new { message = "Log in failed" });

            user.Token = CreateToken(user);
            user.Password = null;

            return Ok(user);

        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await Context.Users
                .Select(x => new User()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    Password = null,
                    Role = x.Role,
                    Email = x.Email
                })
                .ToListAsync();
        }

        private string CreateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, user.Role)
                });
            var credentials = 
                new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
