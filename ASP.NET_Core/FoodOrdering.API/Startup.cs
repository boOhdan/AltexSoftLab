using FoodOrdering.BLL.Contracts;
using FoodOrdering.BLL.Services;
using FoodOrdering.DAL.Contracts;
using FoodOrdering.DAL.DataAccess;
using FoodOrdering.DAL.Date;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FoodOrdering.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FoodOrderingContext>(
                options => options.UseSqlServer("Server=DESKTOP-2MCESAJ\\SQLEXPRESS;Initial Catalog=TestFoodOrderingDB;Trusted_Connection=True;MultipleActiveResultSets=True"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ILogger>(_ => new Logger(@"D:\Test.txt"));
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped(typeof(IWorkingWithFile<>), typeof(WorkingWithFile<>));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodOrdering.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodOrdering.API v1"));
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
