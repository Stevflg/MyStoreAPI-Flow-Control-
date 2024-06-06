using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserDTO
    {
        public string Id { get; set; } 

        public string Name { get; set; } 
        public string CompleteName { get; set; }
        public string Email { get; set; }
        public bool? State { get; set; }
        public string Image {  get; set; }
        public IEnumerable<RolDTO> Roles { get; set; } = new List<RolDTO>();
    }
}
