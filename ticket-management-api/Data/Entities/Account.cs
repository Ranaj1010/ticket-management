using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ticket_management_api.Base;
using ticket_management_api.Data.ValueObjects;
using ticket_management_api.Enum;
using ticket_management_api.Utilities;

namespace ticket_management_api.Data.Entities
{
    public class Account : BaseEntity
    {
        public AccountId? Id { get; private set; }
        public AccountRoleEnum Role { get; private set; }
        public AccountId? CoordinatorId { get; private set; }
        public string? DisplayName { get; private set; }
        public Address? Address { get; private set; }
        public string MobileNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string GcashAccount { get; private set; }
        public string? InitialPasswordValue { get; private set; }
        public double AvailableBalance { get; private set; }

        public static Account Create(AccountId? coordinatorId, AccountRoleEnum accountRoleEnum, string displayName, Address? address, string mobileNumber, string emailAddress, string username, string initialPassowrd, string password, string gcashAccount)
        {
            return new Account
            {
                Id = new AccountId(Guid.NewGuid()),
                Role = accountRoleEnum,
                CoordinatorId = coordinatorId,
                DisplayName = displayName,
                Address = address,
                MobileNumber = mobileNumber,
                EmailAddress = emailAddress,
                Username = username,
                Password = password,
                InitialPasswordValue = initialPassowrd,
                AvailableBalance = 0,
                GcashAccount = gcashAccount,
            };
        }

        public void UpdatePassword(string value)
        {
            Password = value;
        }
    }

    public record AccountId(Guid Value);
}