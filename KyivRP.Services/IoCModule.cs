using KyivRP.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KyivRP.Services
{
    public static class IoCModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            services.AddSingleton<IAuthService, AuthService>();
            return services;
        }
    }
}
