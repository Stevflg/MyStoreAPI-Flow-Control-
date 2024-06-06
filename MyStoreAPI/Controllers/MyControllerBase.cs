using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyStoreAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MyControllerBase : ControllerBase
    {
        //Creation of ControllerBase, to Use IMediator Services
        private IMediator _Mediator;
        protected IMediator Mediator => _Mediator ?? (_Mediator = HttpContext.RequestServices.GetRequiredService<IMediator>());
    }
}
