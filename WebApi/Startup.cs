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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<WebApiContext>(opt =>
            {
                opt.UseSqlite("Data Source=Context\\WebApiDataBase.db");
            });
            services.AddMvc();

            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IWordService, WordService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
