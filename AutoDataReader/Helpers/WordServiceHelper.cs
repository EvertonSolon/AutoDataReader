using AutoDataReader.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDataReader.Helpers
{
    public class WordServiceHelper
    {
        public static IWordService GetService()
        {
            var serviceProvider = ServiceProviderHelper.GetServiceProvider();

            var wordService = serviceProvider.GetService<IWordService>();
            return wordService;
        }
    }
}
