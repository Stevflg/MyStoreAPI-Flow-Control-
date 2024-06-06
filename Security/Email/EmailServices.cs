using FluentValidation.Validators;
using Infraestructure.Email;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Security.Email
{
    public class EmailServices : IEmailServices
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;
        public EmailServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpcontextAccessor = httpContextAccessor;
        }
        string IEmailServices.GetEmailAddress()
        {
            var emailAddress = _httpcontextAccessor?.HttpContext?.User.Claims.FirstOrDefault(a => a.Type.Equals(ClaimTypes.Email))?.Value;
            return emailAddress;
        }
    }
}
