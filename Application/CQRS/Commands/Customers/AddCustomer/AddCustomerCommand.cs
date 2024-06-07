using Application.DTO;
using ErrorOr;
using MediatR;

namespace Application.CQRS.Commands.Customers.AddCustomer
{
   // public class AddCustomerCommand : IRequest<OneOf<List<CustomerDTO>,IError>>
   public class AddCustomerCommand : IRequest<ErrorOr<List<CustomerDTO>>>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Identification { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime DateBirth { get; set; }

    }
}