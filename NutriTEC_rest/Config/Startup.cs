using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriTEC_rest.DB_Context;

namespace NutriTEC_rest
{
    public class Startup
    {
        public readonly string _myCors = "MyCors";
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _configuration = configuration;
            
        }
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NutriTEC_rest", Version = "v1" });
            });
            services.AddCors(options =>
                options.AddPolicy(name: _myCors, builder => {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                })
            );
            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
                    .AddCertificate(options => options.AllowedCertificateTypes = CertificateTypes.All);
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NutriTEC_rest v1"));
            }
            app.UseCors(_myCors);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
