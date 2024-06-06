using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts.TokenDTO
{
    public class MyTokenAppDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CompleteName { get; set; }
        public string Token { get; set; }
        public string Image { get; set; }
        public IEnumerable<RolDTO> Roles { get; set; }
    }
}