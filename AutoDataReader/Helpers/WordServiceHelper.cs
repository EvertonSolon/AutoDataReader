using AutoDataReader.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDataReader.Helpers
{
    public class WordServiceHelper
    {
        public static IWordService GetService()
        {
            var services = new ServiceCollection();
            var startup = new Startup();

            startup.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var wordService = serviceProvider.GetService<IWordService>();
            return wordService;
        }
    }
}
