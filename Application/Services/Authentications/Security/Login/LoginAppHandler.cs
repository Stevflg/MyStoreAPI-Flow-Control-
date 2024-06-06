using Application.Contracts.SecurityApp;
using Application.Contracts.TokenDTO;
using Domain.Entities;
using Identity.PasswordHasher;
using Infraestructure.context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentications.Security.Login
{
    internal class LoginAppHandler : IRequestHandler<LoginAppQuery, MyTokenAppDTO>
    {
        private readonly MyStoreAppContext _context;
        private readonly IGenerateToken _generateToken;
        private readonly IPasswordHasher _passwordHasher;

        public LoginAppHandler(MyStoreAppContext context, IGenerateToken generateToken, IPasswordHasher passwordHasher)
        {
            _context = context;
            _generateToken = generateToken;
            _passwordHasher = passwordHasher;
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
                    var roles = await (from a in _context.Roles
                                       join b in _context.Userrols
                                       on a.Id equals b.RolId
                                       where b.UserId.Equals(getUser)
                                       select new Role
                                       {
                                           Id = a.Id,
                                           Name = a.Name,
                                       }).ToListAsync();


                    var myTokenApp = new MyTokenAppDTO
                    {
                        UserId = getUser.Id,
                        UserName = getUser.Name,
                        Token = _generateToken.Create(getUser, roles)
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
