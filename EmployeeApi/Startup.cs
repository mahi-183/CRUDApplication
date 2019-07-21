using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
using BusinessManager.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RepositoryManager.Interface;
using RepositoryManager.Services;

namespace EmployeeApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:44384"));
            });

            services.AddCors(cors => cors.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin();
            }));



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //here is AddTransient keyword is for 
            services.AddTransient<IEmployeeBusinessManager, EmployeeBusinessService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepositoryService>();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseCors("AllowOrigin");

            app.UseCors(options =>
            options.WithOrigins("https://localhost:44384")
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin()
           .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
