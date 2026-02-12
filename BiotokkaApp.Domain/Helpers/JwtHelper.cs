using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BiotokkaApp.Domain.Helpers
{
    public class JwtHelper
    {
        private static string _secretKey = "A096AB20-A582-49B0-8D3B-5E224FBBF04E";

        public static string GenerateToken(string email, string perfil)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, email), new Claim(ClaimTypes.Role, perfil)

        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: "BiotokkaApp", audience: "BiotokkaApp", claims: claims, expires: DateTime.UtcNow.AddHours(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}