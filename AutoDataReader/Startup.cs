using AutoDataReader.Repositories;
using AutoDataReader.Repositories.Contracts;
using AutoDataReader.Service;
using AutoDataReader.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using AutoDataReader.Context;
using Microsoft.EntityFrameworkCore;
using AutoDataReader.Helpers;

namespace AutoDataReader
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var dbPathFile = DbPathFile.GetLocation();

            services.AddDbContext<AutoDataReaderContext>(options =>
            {
                options.UseSqlite($"Data Source = {dbPathFile}");
            });

            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IWordService, WordService>();
        }
    }
}