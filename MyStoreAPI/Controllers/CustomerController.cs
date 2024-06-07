using Application.CQRS.Commands.Customers.AddCustomer;
using Microsoft.AspNetCore.Mvc;

namespace MyStoreAPI.Controllers
{
    public class CustomerController : MyControllerBase
    {
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerCommand request){
            var result = await Mediator.Send(request);
            return result.Match(
                   customerResult => Ok(customerResult),
                   errors => Problem(errors)
                ); 
        }
    }
}