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
using FIMEFavor.DAL.EF;
using FIMEFavor.DAL.Repos.Interfaces;
using FIMEFavor.DAL.Repos;

namespace FIMEFavor.API
{
    public class Startup
    {

        private IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            _env = env;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(options =>
                options.EnableEndpointRouting = false);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FIMEFavor.API", Version = "v1" });
            });


            services.AddDbContext<FimeContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));

            services.AddScoped<ICategoriaRepo, CategoriaRepo>();
            services.AddScoped<ICuentasRepo, CuentasRepo>();
            services.AddScoped<IDetallesOrdenesRepo, DetallesOrdenesRepo>();
            services.AddScoped<IMochilaRepo, MochilaRepo>();
            services.AddScoped<IOrdenRepo, OrdenRepo>();
            services.AddScoped<IProductoRepo, ProductoRepo>();
            services.AddScoped<IReseñaRepo, ReseñasRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FIMEFavor.API v1"));
            }

            app.UseCors(x=>x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());  // has to go before UseMvc

            app.UseMvc();

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
