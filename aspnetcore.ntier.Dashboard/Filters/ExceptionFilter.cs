using aspnetcore.ntier.BLL.Services.Dashboard;
using aspnetcore.ntier.BLL.Services.IServices;
using aspnetcore.ntier.BLL.Services.Log;
using aspnetcore.ntier.BLL.Utilities.CustomExceptions;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aspnetcore.ntier.Dashboard.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {

            if (context.Exception.GetType() == typeof(BadRequestException) || context.Exception.GetType() == typeof(UserNotFoundException))
            {
                context.Result = new BadRequestObjectResult(new { Error = context.Exception?.InnerException?.Message is null ? context.Exception?.Message : context.Exception?.InnerException?.Message });
            }
            else
            {
                var request = context.HttpContext.Request;
                var logService = (LogRequestService)context.HttpContext.RequestServices.GetService(typeof(ILogRequestsService));
                var queryString = request.QueryString.ToString();
                var path = request.Path;
                var method = request.Method;
                var schema = request.Scheme;
                var body = context.HttpContext.Items["RequestBody"]?.ToString();
                await logService.LogRequest(new DTO.DTOs.LogRequestDto
                {
                    Schema = schema,
                    Body = body,
                    HttpMethod = method,
                    Path = path,
                    QueryString = queryString,
                    RequestAt = DateTime.UtcNow,
                    Error = context.Exception.Message,
                });
                context.Result = new BadRequestObjectResult(new { Error = "Something went wrong please try again later !" });
            }
        }
    }
}
