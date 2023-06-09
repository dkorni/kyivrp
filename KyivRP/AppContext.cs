using Microsoft.Extensions.DependencyInjection;
using System;
using KyivRP.EntityFramework.Infrastracture;
using KyivRP.Services;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace KyivRP
{
    public static class AppContext
    {
        public static IServiceProvider ServiceProvider { 
            get {
                if(serviceProvider == null)
                {
                    var services = new ServiceCollection();
                    services.AddInfrastracture();
                    services.AddServices();
                    serviceProvider = services.BuildServiceProvider();
                    return serviceProvider;
                }else
                    return serviceProvider;
            } }

        private static IServiceProvider serviceProvider;
    }
}
