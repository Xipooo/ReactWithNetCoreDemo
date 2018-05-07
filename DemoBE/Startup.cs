using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoBE.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DemoBE
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
            services.AddCors();
            services.AddDbContext<DemoContext>(options => options.UseInMemoryDatabase("DemoDB"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder =>
            builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            SeedDatabase(app.ApplicationServices);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void SeedDatabase(IServiceProvider services)
        {
            var context = services.GetRequiredService<DemoContext>();
            context.HomePages.Add(new HomePage
            {
                Id = 1,
                Title = "Sleep Application",
                Description = "This is our Sleep app!"
            });
            context.SaveChanges();
        }
    }
}
