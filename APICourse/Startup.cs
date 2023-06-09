using APICourse.Repository;
using APICourse.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalExceptionHandler.WebApi;
using APICourse.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AutoMapper;

namespace APICourse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            /*
             DB_HOST=localhost
                DB_PASS=123456
             */
            var host = configuration["DB_HOST"];
            var pass = configuration["DB_PASS"];
            var string_conexao = configuration["CONECT_STRING_SQLSERVER"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CourseContext>(
                context => context.UseSqlite(
                    Configuration.GetConnectionString("Default")
                    )
                );

            services.AddScoped<CourseService>();
            services.AddControllers(f => {
                f.Filters.Add<MyExceptionFilter>();
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APICourse", Version = "v1" });
            });

            //services.addAu;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APICourse v1"));
            }

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
