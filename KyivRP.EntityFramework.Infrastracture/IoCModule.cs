using KyivRP.Domain.Interfaces;
using KyivRP.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KyivRP.EntityFramework.Infrastracture
{
    public static class IoCModule
    {
        public static IServiceCollection AddInfrastracture(this IServiceCollection services)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            services.AddSingleton<IRepository<Account>,Repository<Account>>();
            return services;
        }
    }
}
