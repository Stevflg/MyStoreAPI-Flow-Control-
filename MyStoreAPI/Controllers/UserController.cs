using Microsoft.AspNetCore.Mvc;

namespace MyStoreAPI.Controllers
{
    public class UserController : MyControllerBase
    {
        [HttpGet("GetUser")]
        public async Task<string> GetUser()
        {
            return "Hola esta es mi API";
        }
    }
}
