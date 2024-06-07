using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commons.Errors
{
    public static partial class AuthError
    {
            public static Error InvalidUser
                                => Error.NotFound(
                                        code:"User.NotFound",
                                        description:"Invalid User"
                                    );

            public static Error InvalidPassword
                                => Error.Unauthorized(
                                    code: "User.Unauthorized",
                                    description: "Invalid Credentials");

            public static Error UserLocked
                                => Error.Unauthorized(
                                    code: "User.Unauthorized",
                                    description: "User is already Locked");

    }
}
