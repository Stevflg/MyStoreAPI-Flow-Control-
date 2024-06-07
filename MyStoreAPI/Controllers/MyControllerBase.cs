using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyStoreAPI.Http;

namespace MyStoreAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MyControllerBase : ControllerBase
    {
        //Creation of ControllerBase, to Use IMediator Services
        private IMediator _Mediator;
        protected IMediator Mediator => _Mediator ?? (_Mediator = HttpContext.RequestServices.GetRequiredService<IMediator>());

        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
                return Problem();

            if (errors.All(error => error.Type == ErrorType.Validation))
                return ValidationProblem(errors);

            HttpContext.Items[HttpContextItemKey.Errors] = errors;

            var firstError = errors[0];

            return Problem(firstError);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: error.Description);
        }


        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(
                        error.Code,
                        error.Description
                    );
            }
            return ValidationProblem(modelStateDictionary);
        }
    }
}
