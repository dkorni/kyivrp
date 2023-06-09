using KyivRP.Domain;
using KyivRP.Domain.Constants;
using KyivRP.Domain.Interfaces;
using KyivRP.Domain.Interfaces.Services;
using KyivRP.Domain.Models;
using System;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlTypes;

namespace KyivRP.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<Account> repository;
        private const int iterations = 350000;
        private const int hashLength = 32;

        public AuthService(IRepository<Account> repository)
        {
            this.repository = repository;
        }

        public async Task<Result<Account>> Login(string username, string password)
        {
            var result = new Result<Account>();
            var existedUser = await repository.GetByPredicate(x => x.Username == username);
            if (existedUser == null)
            {
                result.Error = Errors.UserDoesNotExist;
                return result;
            }

            // validate user
            byte[] hashBytes;
            var saltBytes = Convert.FromBase64String(existedUser.Salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, iterations))
            {
                hashBytes = pbkdf2.GetBytes(hashLength);
            }
            var hash = Convert.ToBase64String(hashBytes);

            bool passwordIsCorrect = hash == existedUser.PasswordHash;

            if(!passwordIsCorrect) 
            {
                result.Error = Errors.InvalidPassword;
                return result;
            }

            result.Value = existedUser;
            return result;
        }

        public async Task<Result<Account>> Register(string username, string email, string password)
        {
            var result = new Result<Account>();
            var existedUser = await repository.GetByPredicate(x => x.Username == username);
            if (existedUser != null)
            {
                result.Error = Errors.UserAlreadyRegistered;
                return result;
            }

            // TODO validate password value by regex

            var account = new Account();
            account.Username = username;
            account.Group = 0;
            account.Id = Guid.NewGuid();

           
            const int keySize = 64;

            byte[] saltBytes = new byte[keySize];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }

            byte[] hashBytes;

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, iterations))
            {
                hashBytes = pbkdf2.GetBytes(hashLength);
            }

            var hash = Convert.ToBase64String(hashBytes);
            var salt = Convert.ToBase64String(saltBytes);

            account.PasswordHash = hash;
            account.Salt = salt;

            await repository.CreateOrUpdate(account);
            result.Value = account;
            return result;
        }
    }
}
