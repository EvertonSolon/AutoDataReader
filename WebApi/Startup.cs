using WebApi.Repositories;
using WebApi.Repositories.Contracts;
using WebApi.Service;
using WebApi.Service.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Context;

namespace WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<WebApiContext>(opt =>
            {
                //opt.UseSqlite("Data Source=Context\\WebApiDataBase.db");
                opt.UseSqlite($"Data Source={_configuration.GetValue<string>("DbSettings:MySql:DbFileLocation")}");
            });
            services.AddMvc();

            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IWordService, WordService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //IdentityModelEventSource.ShowPII = true;
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}
