using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Text;

namespace FoodOrdering.API.Filters
{

    public class MySampleActionFilter : IActionFilter
    {

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            request.EnableBuffering();
            request.Body.Position = 0;

            using var streamReader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, leaveOpen: true);

            var requestBody = await streamReader.ReadToEndAsync();

            Console.WriteLine(requestBody);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
