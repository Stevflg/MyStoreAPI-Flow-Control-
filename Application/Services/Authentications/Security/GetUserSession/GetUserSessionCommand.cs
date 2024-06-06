using Application.Contracts.TokenDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentications.Security.GetUserSession
{
    public class GetUserSessionCommand : IRequest<MyTokenAppDTO> { }
}
