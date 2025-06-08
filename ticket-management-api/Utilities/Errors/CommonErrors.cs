using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticket_management_api.Utilities.Shared;

namespace ticket_management_api.Utilities.Errors
{
    public static class CommonErrors
    {
        public static readonly Error InternalServerError = Error.Failure("Application.InternalServerError", "");
    }

}