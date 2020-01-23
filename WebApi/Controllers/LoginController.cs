using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.Service.Contracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost(Name = "Login")]
        public ActionResult Login([FromBody]User user)
        {
            if (user == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = _service.Get(user);

            if (result == null)
                return NotFound();//Or StatusCode(404)

            return Ok(BuildToken(user));
        }

        private object BuildToken(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var key = _configuration["APIWord_Access:ApiKey"];
            var encodedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var sign = new SigningCredentials(encodedKey, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: exp,
                signingCredentials: sign
                );

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new { token = stringToken, expirationDate = exp };
        }
    }
}