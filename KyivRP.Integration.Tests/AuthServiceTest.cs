using KyivRP.Domain.Interfaces.Services;
using KyivRP.Domain.Models;
using KyivRP.EntityFramework.Infrastracture;
using KyivRP.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KyivRP.Integration.Tests
{
    public class AuthServiceTest
    {
        [Test]
        public async Task AuthService_Should_Register_And_Login_Account()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddInfrastracture();
            serviceCollection.AddServices();
            var provider = serviceCollection.BuildServiceProvider();
            var authService = provider.GetService<IAuthService>();
            var account = await authService.Login("test", "test");
            Assert.IsNotNull(account);
        }
    }
}
