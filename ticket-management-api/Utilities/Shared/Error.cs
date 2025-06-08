using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticket_management_api.Utilities.Shared
{
    public record Error
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided.", ErrorType.Failure);

        private Error(string code, string description, ErrorType type)
        {
            this.Code = code;
            this.Description = description;
            this.Type = type;
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public ErrorType Type { get; set; }

        public static Error NotFound(string code, string description) => new(code, description, ErrorType.NotFound);
        public static Error Failure(string code, string description) => new(code, description, ErrorType.Failure);
        public static Error Validation(string code, string description) => new(code, description, ErrorType.Validation);
        public static Error Conflict(string code, string description) => new(code, description, ErrorType.Conflict);
    }

    public enum ErrorType
    {
        Failure = 0,
        Validation = 1,
        NotFound = 2,
        Conflict = 3
    }
}