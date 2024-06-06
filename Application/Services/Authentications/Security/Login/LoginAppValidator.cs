using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentications.Security.Login
{
    internal class LoginAppValidator : AbstractValidator<LoginAppQuery>
    {
        public LoginAppValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().NotNull();
            RuleFor(a => a.Password).NotEmpty().NotNull();
        }
    }
}
