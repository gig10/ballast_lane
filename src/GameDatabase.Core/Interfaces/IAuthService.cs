using GameDatabase.Core.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Core.Interfaces
{
    public interface IAuthService
    {
        Task<Authentication> AuthenticateUser(string email, string password);
        Task<Authentication> SignupUser(string email, string password, string username);
    }
}
