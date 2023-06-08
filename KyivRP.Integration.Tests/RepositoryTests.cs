using KyivRP.Domain.Models;
using KyivRP.EntityFramework.Infrastracture;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace KyivRP.Integration.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAll_MustReturnAllAccounts()
        {
            var accounts = new Account[]
            {
                new Account()
                {
                    Id = Guid.NewGuid(),
                    Username = "Test 1",
                    PasswordHash = "Hash1",
                    Group = 0
                },
                new Account()
                {
                    Id = Guid.NewGuid(),
                    Username = "Test 2",
                    PasswordHash = "Hash2",
                    Group = 1
                },
            };

            var accountRepository = new Repository<Account>();
            
            foreach (var account in accounts)
            {
                await accountRepository.CreateOrUpdate(account);
            }

            var fetchedAccounts = await accountRepository.Getall();
            Assert.That(fetchedAccounts.Length, Is.EqualTo(accounts.Length));

            foreach (var account in accounts)
            {
                await accountRepository.Delete(account);
            }
        }
    }
}