using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace FoodOrdering.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CustomExceptionFilter(
            IWebHostEnvironment hostingEnvironment,
            ILogger<CustomExceptionFilter> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exeption = context.Exception;

            if (_hostingEnvironment.IsDevelopment())
            {
                var devMessage = $"An error occurred! \nMessage: \n{exeption.Message} \nStackTrace: \n{exeption.StackTrace}";

                _logger.LogWarning(exeption, devMessage);
                Console.WriteLine(devMessage);
            } 
            else if (_hostingEnvironment.IsProduction()) 
            {
                Console.WriteLine($"An error occurred! \nMessage: \n{exeption.Message}");
            }
        }
    }
}
