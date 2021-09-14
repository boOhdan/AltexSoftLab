using FoodOrdering.BLL.Contracts;
using FoodOrdering.BLL.Services;
using FoodOrdering.DAL.Contracts;
using FoodOrdering.DAL.DataAccess;
using FoodOrdering.DAL.Date;
using FoodOrdering.DAL.Models;
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
                options => options.UseSqlServer(Configuration.GetConnectionString("FoodOrderingDatabase")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IWorkingWithFile<>), typeof(WorkingWithFile<>));
            services.AddScoped(typeof(IWorkingWithAPI<ExchangeRateInfo>), 
                _ => new WorkingWithAPI<ExchangeRateInfo>("https://api.privatbank.ua/p24api/exchange_rates?json&date=13.06.2021"));
            services.AddScoped<IExchangeRateService, ExchangeRateService>();
            services.AddScoped<ILogger, Logger>(_ => new Logger(@"D:\Test.txt"));
            services.AddScoped<IValidationService, ValidationService>();

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "mvc/{controller=ProductsMvc}/{action=Index}/{id?}");
            });
        }
    }
}
