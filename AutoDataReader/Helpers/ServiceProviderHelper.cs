using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoDataReader.Helpers
{
    public class ServiceProviderHelper
    {
        public static ServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            var startup = new Startup();

            startup.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
