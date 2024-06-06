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
            //Enfoque utilizado para implementar OneOf
            // OneOf<List<CustomerDTO>, IError> result =  await Mediator.Send(request);
            //return result.Match(customerResult => Ok(customerResult),
            //                    error => Problem(statusCode: (int)error.StatusCode,title: error.Message));

            //Enfoque para implementar FluentResult (Resultados Fluidos)
            var result = await Mediator.Send(request);
            if (result.IsSuccess)
            { return Ok(result.Value); }

            var firstError = result.Errors[0];
            if (firstError is DuplicateCustomerError)
            {
                return Problem(statusCode: StatusCodes.Status409Conflict, detail: "Customer Already Exist");
            }

            return Problem();
        }
    }
}