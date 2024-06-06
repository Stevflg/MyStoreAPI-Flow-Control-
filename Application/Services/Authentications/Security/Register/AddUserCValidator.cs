using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentications.Security.AddUser
{
    public class AddUserCValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Email).NotEmpty();
            RuleFor(a => a.EmployeeId).NotEmpty();
        }
    }
}
