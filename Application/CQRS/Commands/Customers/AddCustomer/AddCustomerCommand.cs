using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Errors;
using Application.DTO;
using FluentResults;
using MediatR;

namespace Application.CQRS.Commands.Customers.AddCustomer
{
   // public class AddCustomerCommand : IRequest<OneOf<List<CustomerDTO>,IError>>
   public class AddCustomerCommand : IRequest<Result<List<CustomerDTO>>>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Identification { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime DateBirth { get; set; }

    }
}