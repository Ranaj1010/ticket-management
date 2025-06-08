using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticket_management_api.Data.Payloads.Requests
{
    public class LoginAccountRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}