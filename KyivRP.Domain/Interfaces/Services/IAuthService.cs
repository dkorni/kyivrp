using KyivRP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KyivRP.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<Result<Account>> Register(string username, string email, string password);

        public Task<Result<Account>> Login(string username, string password);
    }
}
