using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MyStoreAPI.Controllers
{
    public class ErrorController : ControllerBase
    {

        //Agregar el ignore API  para evitar lanzammiento de exception en swaggere x status code 500
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem();
        }
    }
}
