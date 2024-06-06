using Application.Contracts.SecurityApp;
using Application.Contracts.TokenDTO;
using Application.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Identity.PasswordHasher;
using Infraestructure.context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Authentications.Security.Login
{
    internal class LoginAppHandler : IRequestHandler<LoginAppQuery, MyTokenAppDTO>
    {
        private readonly MyStoreAppContext _context;
        private readonly IGenerateToken _generateToken;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public LoginAppHandler(MyStoreAppContext context, IGenerateToken generateToken,
                                IPasswordHasher passwordHasher,IMapper mapper)
        {
            _context = context;
            _generateToken = generateToken;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        async Task<MyTokenAppDTO> IRequestHandler<LoginAppQuery, MyTokenAppDTO>.Handle(LoginAppQuery request, CancellationToken cancellationToken)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var getUser = await _context.Users.FirstOrDefaultAsync(a => a.Name.Equals(request.UserName));

                    if (getUser == null)
                        throw new Exception("El usuario Ingresado es Incorrecto");
                    if (getUser.Locked > DateTime.Now || getUser.State.Equals(false))
                        throw new Exception("El Usuario Esta Bloqueado o Deshabilitado");
                    if (!_passwordHasher.VerifyHashedPassword(getUser.Password, request.Password))
                    {
                        getUser.Counter += 1;
                        if (getUser.Counter >= 3)
                        {
                            getUser.Locked = DateTime.MaxValue;
                            getUser.Counter = 0;
                        }
                        _context.Entry(getUser).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        throw new Exception("Contraseña Incorrecta");
                    }
                    if (getUser.Counter > 0)
                    {
                        getUser.Counter = 0;
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }

                    var userToken = await _context.Users.AsNoTracking().
                                       Where(a => a.Id.Equals(getUser.Id))
                                           .ProjectTo<UserDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

                    var myToken = new MyTokenAppDTO
                    {
                        UserId = userToken.Id,
                        UserName = userToken.Name,
                        CompleteName = userToken.CompleteName,
                        Token = _generateToken.Create(userToken),
                        Image = userToken.Image,
                        Roles = userToken.Roles
                    };

                    return new MyTokenAppDTO();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
