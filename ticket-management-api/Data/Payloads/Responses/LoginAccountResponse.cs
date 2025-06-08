using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticket_management_api.Data.Objects;

namespace ticket_management_api.Data.Payloads.Responses
{
    public class LoginAccountResponse
    {
        public AccountDto? Account { get; set; }
    }
}