using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CustomerDTO
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Identification { get; set; }

        public string Address { get; set; } = null!;

        public DateTime DateBirth { get; set; }

         public bool State { get; set; }
    }
}