using AliGulmen.Week2.HomeWork.RestfulApi.Services.LoggerService;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Middlewares
{

    // This middleware will be used for global logging and global exception for now.
    // The logic might be changed in the future
    public class CustomLoggingMiddleware
	{

		private readonly RequestDelegate _next;
		private readonly ILoggerService _loggerService;

        public CustomLoggingMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
		{
				//Request has the informations which comes from client. we will write the method and the name of path to console.

				string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
			_loggerService.Log(message);

			// Call the next delegate/middleware in the pipeline
			await _next(context);

				// Do tasks after middleware here, we can work with "Response" and log the status code we returned.
				message = "[Request] HTTP "
					+ context.Request.Method + " - "
					+ context.Request.Path
					+ " responded " + context.Response.StatusCode;
			_loggerService.Log(message);


		}


	}


}
