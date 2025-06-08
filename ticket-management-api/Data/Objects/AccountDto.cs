using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticket_management_api.Data.ValueObjects;
using ticket_management_api.Enum;

namespace ticket_management_api.Data.Objects
{
    public class AccountDto
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string? CoordinatorId { get; set; }
        public string? DisplayName { get; set; }
        public Address? Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string GcashAccount { get; set; }
        public string? InitialPasswordValue { get; set; }
        public double AvailableBalance { get; set; }
    }
}