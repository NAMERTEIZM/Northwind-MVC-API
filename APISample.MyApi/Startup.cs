using APISample.MyApi.Models;
using APISample.MyApi.Models.Context;
using APISample.MyApi.Models.DAL;
using APISample.MyApi.Models.Exception;
using APISample.MyApi.Models.Helpers;
using APISample.MyApi.Models.IDAL;
using APISample.MyApi.Models.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace APISample.MyApi
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
            services.AddControllers();
            services.AddDbContext<MyContext>(a => a.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddScoped<IShipperDAL, ShipersDAL>();
            services.AddSingleton<ConnectionHelper>();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<ISupplierDAL, SupplierDAL>();
            //dapper yapýlandýrmasi
            string connectionString = Configuration.GetConnectionString("myconn");
            services.AddScoped<IDbConnection>(conn => new SqlConnection(connectionString));
            services.AddSwaggerGen();
            services.AddScoped<Mapper>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Implement Swagger UI",
                    Description = "A simple example to Implement Swagger UI",
                });
            });

            //Rate Limit Tanýmlarý



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Error");
            }


            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Bir hata oluþtu. Lütfen tekrar deneyin.");
                }
            });



            app.UseSwagger();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Calisan}/{method=calisanGetir}/{id?}");
            });
        }
    }
}
