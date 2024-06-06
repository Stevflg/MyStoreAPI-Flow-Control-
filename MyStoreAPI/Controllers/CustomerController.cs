using Application.Common.Errors;
using Application.CQRS.Commands.Customers.AddCustomer;
using Application.DTO;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOf.Types;

namespace MyStoreAPI.Controllers
{
    public class CustomerController : MyControllerBase
    {
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerCommand request){

            // OneOf<List<CustomerDTO>, IError> result =  await Mediator.Send(request);
            //return result.Match(customerResult => Ok(customerResult),
            //                    error => Problem(statusCode: (int)error.StatusCode,title: error.Message));
            return Ok();
        }
    }
}