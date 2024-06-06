using Application.Common.Errors;
using Application.CQRS.Commands.Customers.AddCustomer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication.ExtendedProtection;

namespace MyStoreAPI.Controllers
{
    public class CustomerController : MyControllerBase
    {
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerCommand request){
            var result = await Mediator.Send(request);
            return result.MatchFirst(
                   customerResult => Ok(customerResult),
                   firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
                ); 
        }
    }
}