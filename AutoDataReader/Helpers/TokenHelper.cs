using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutoDataReader.Helpers
{
    //TODO: In the future, implment to use JWT in API.
    public class TokenHelper
    {
        public static object BuildToken()
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, "UniqueName")
            };

            var key = new BuilderHelper()._configuration["APIWord_Access:ApiKey"];
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
