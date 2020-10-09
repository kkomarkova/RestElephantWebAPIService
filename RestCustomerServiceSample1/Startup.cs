using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RestCustomerServiceSample1
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
            
            services.AddCors(options =>
            {
                // 1 st policy --> allow specific origin
                options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("https://www.zealand.dk/").AllowAnyHeader().AllowAnyMethod();
                });

                // 2nd Policy --> allow any origins -- Now you have to public your services
                options.AddPolicy("AllowAnyOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

                // 3rd Policy --> allow only Get Put Method 
                options.AddPolicy("AllowAnyOriginsGetPUT",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("GET", "PUT");
                });
            });

            services.AddControllers();

        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Shows which cors policy you would to like to define here. use.cors
             app.UseCors("AllowAnyOriginsGetPUT");
            //app.UseCors("AllowSpecificOrigins");
            //app.UseCors("AllowAnyOrigins");


            app.UseHttpsRedirection();

            app.UseRouting();

           

            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
