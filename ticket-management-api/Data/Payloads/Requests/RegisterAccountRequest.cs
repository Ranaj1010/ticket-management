using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticket_management_api.Data.ValueObjects;

namespace ticket_management_api.Data.Payloads.Requests
{
    public class RegisterAccountRequest
    {
        public string DisplayName { get; set; }
        public string? CoordinatorId { get; set; }
        public Address? Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string GcashAccount { get; set; }
    }
}