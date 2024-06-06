using Application.Contracts.SecurityApp;
using Domain.Entities;
using Identity.PasswordHasher;
using Infraestructure.context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentications.Security.AddUser
{
    internal class AddUserHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly MyStoreAppContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IGetUserSession _userSession;

        public AddUserHandler(MyStoreAppContext context,
                IPasswordHasher passwordHasher, IGetUserSession getUserSession)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _userSession = getUserSession;
        }

        async Task<Unit> IRequestHandler<AddUserCommand, Unit>
            .Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                    var user = await _context.Users.FirstOrDefaultAsync(a => a.Name.Equals(request.Name));
                    if (user != null)
                        throw new Exception("El usuario ya existe en el sistema");
                    var UserIdSession = _userSession.GetUserId();
                    var newUser = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = request.Name,
                        Email = request.Email,
                        Password = _passwordHasher.HashPassword(request.Password),
                        EmployeeId = request.EmployeeId,
                        CreatedBy = UserIdSession,
                    };

                    _context.Add(newUser);

                    if (request.Roles != null)
                    {
                        foreach (var role in request.Roles)
                        {
                            _context.Add(new Userrol
                            {
                                UserId = newUser.Id,
                                RolId = role,
                                CreatedBy = UserIdSession,
                            });
                        }
                    }

                    var result = await _context.SaveChangesAsync();
                       await transaction.CommitAsync();
                if (result <= 0)
                    await transaction.RollbackAsync();

                return Unit.Value;


            }
        }
    }
}
