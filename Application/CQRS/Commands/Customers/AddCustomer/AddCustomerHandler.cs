using Application.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using FluentResults;
using Infraestructure.context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.Customers.AddCustomer
{
    internal class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Result<List<CustomerDTO>>>
    {
        private readonly MyStoreAppContext _context;
        private readonly IMapper _mapper;
        public AddCustomerHandler(MyStoreAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<Result<List<CustomerDTO>>> IRequestHandler<AddCustomerCommand, Result<List<CustomerDTO>>>.Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var Customer =await _context.Customers.FirstOrDefaultAsync(a => a.Email.Equals(request.Email));
                if(Customer!=null)
                {
                    return null;
                }

                var newCustomer = new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    LastName = request.LastName,
                    Identification = request.Identification,
                    Address = request.Address,
                    DateBirth = request.DateBirth,
                    CreatedBy = Guid.NewGuid().ToString(),
                    Email = request.Email
                };

                _context.Customers.Add(newCustomer);
                var result = await _context.SaveChangesAsync();

               
                transaction.Commit();
                var data = await _context.Customers.AsNoTracking()
                                        .ProjectTo<CustomerDTO>(_mapper.ConfigurationProvider).ToListAsync();
                return data;
            }
        }
    }
}