using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commons.Errors
{
    public static partial class CustomerError
    {
            public static Error DuplicateCustomer
                    => Error.Conflict(
                            code: "Customer.DuplicateCustomer",
                            description: "Customer Already Exist");

    }
}