using Application.Contracts.SecurityApp;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Security.TokenAccess
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration _configuration;
        public GenerateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string IGenerateToken.Create(User userLogin, List<Role> roles)
        {
            var Claims = new List<Claim>();

            Claims.Add(new Claim(
                    ClaimTypes.Name, userLogin.Name
                ));

            Claims.Add(new Claim(
                    ClaimTypes.Sid, userLogin.Id
                    ));

            Claims.Add(new Claim(
                    ClaimTypes.Email, userLogin.Email
                ));
            foreach (var rol in roles)
            {
                Claims.Add(
                    new Claim(ClaimTypes.Role, rol.Name)
                    );
            }

            var credentials = new SigningCredentials( new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"].ToString()))
                                                ,SecurityAlgorithms.EcdsaSha256);
            var tokenDescriptions = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials  
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptions));

            return token;
        }
    }
}
