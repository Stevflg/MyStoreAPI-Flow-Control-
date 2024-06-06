using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentications.Security.AddUser
{
    public class AddUserCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public string EmployeeId { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
