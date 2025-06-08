using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticket_management_api.Utilities.Shared;

namespace ticket_management_api.Utilities.Errors
{
    public static class AccountErrors
    {
        public static Error NotFound(string username) => Error.NotFound(
        "Account.NotFound", $"Username '{username}' not found.");
        public static Error EmailNotFound(string email) => Error.NotFound(
        "Account.NotFound", $"Specialist with email '{email}' not found.");
        public static Error AlreadyExists() => Error.Conflict(
        "Account.AlreadyExists", $"Account already exists.");
        public static Error EmailAlreadyExists(string email) => Error.Conflict(
        "Account.EmailAlreadyExists", $"Email '{email}' already exists.");
        public static Error InvalidMobileNumber(string mobileNumber) => Error.Conflict(
        "Account.InvalidMobileNumber", $"Mobile number '{mobileNumber}' is invalid.");
        public static Error InvalidUsernameOrPassword() => Error.Conflict(
        "Account.InvalidUsernameOrPassword", $"Username or Password is invalid.");
    }
}