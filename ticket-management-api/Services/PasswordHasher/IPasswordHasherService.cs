using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticket_management_api.Services.PasswordHasher
{
    public interface IPasswordHasherService
    {
        string Hash(string password);
        bool Verify(string password, string passwordHash);
    }
}