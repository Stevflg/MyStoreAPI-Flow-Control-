using Application.Contracts.TokenDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentications.Security.Login
{
    public class LoginAppQuery : IRequest<MyTokenAppDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
