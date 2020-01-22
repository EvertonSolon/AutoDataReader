using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutoDataReader.Service
{
    public class TokenService
    {
        public string BuildToken(string user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, "UniqueName")
            };

            //var key = "";

            return null;
        }
    }
}
