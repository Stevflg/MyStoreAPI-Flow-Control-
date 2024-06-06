using Application.Contracts.SecurityApp;
using Application.Contracts.TokenDTO;
using Application.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infraestructure.context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Authentications.Security.GetUserSession
{
    internal class GetUserSessionHandler : IRequestHandler<GetUserSessionCommand, MyTokenAppDTO>
    {
        private readonly IGetUserSession _getUserSession;
        private readonly MyStoreAppContext _context;
        private readonly IGenerateToken _generateToken;
        private readonly IMapper _mapper;

        public GetUserSessionHandler(IGetUserSession getUserSession,
                MyStoreAppContext context,
                IGenerateToken generateToken,
                IMapper mapper)
        {
            _getUserSession = getUserSession;
            _context = context;
            _generateToken = generateToken;
            _mapper = mapper;
        }
        async Task<MyTokenAppDTO> IRequestHandler<GetUserSessionCommand, MyTokenAppDTO>.Handle(GetUserSessionCommand request, CancellationToken cancellationToken)
        {
            using(var transaction =  _context.Database.BeginTransaction())
            {
                var getUser = await _context.Users.AsNoTracking().
                                        Where(a => a.Id.Equals(_getUserSession.GetUserId()))
                                            .ProjectTo<UserDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(); 
                if (getUser == null)
                {
                    //capturar exception
                }
               
                var myToken = new MyTokenAppDTO
                {
                    UserId = getUser.Id,
                    UserName = getUser.Name,
                    CompleteName = getUser.CompleteName,
                    Token = _generateToken.Create(getUser),
                    Image = getUser.Image,
                    Roles = getUser.Roles                    
                };

                return myToken;

            }
        }
    }
}
