using Ecommerce.Micro.CarShop.Application;
using Ecommerce.Micro.CarShop.Persistence;
using Ecommerce.Micro.CarShop.RemoteInterface;
using Ecommerce.Micro.CarShop.RemoteServices;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Micro.CarShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBooksService, BookServices>();

            services.AddControllers();

            services.AddDbContext<ContextCarShop>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DBConnecion"));
            });

            services.AddMediatR(typeof(RegisterCarShopSession.Handler).Assembly);
            services.AddHttpClient("Books", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Books"]);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
