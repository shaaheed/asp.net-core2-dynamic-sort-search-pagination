using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicFilterAndPaginationExample.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DynamicFilterAndPaginationExample
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
            // use in memory database
            services.AddDbContext<UserDbContext>(option =>
            {
                option.UseInMemoryDatabase("UserDatabase");
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //var _context = app.ApplicationServices.GetRequiredService<UserDbContext>();
                //new DataSeeder(_context).Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
