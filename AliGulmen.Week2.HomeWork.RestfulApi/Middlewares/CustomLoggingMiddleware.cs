using Microsoft.AspNetCore.Builder;
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

		public CustomLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
				//Request has the informations which comes from client. we will write the method and the name of path to console.

				string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
			 Console.WriteLine(message);

				// Call the next delegate/middleware in the pipeline
				await _next(context);

				// Do tasks after middleware here, we can work with "Response" and log the status code we returned.
				message = "[Request] HTTP "
					+ context.Request.Method + " - "
					+ context.Request.Path
					+ " responded " + context.Response.StatusCode;
			 Console.WriteLine(message);
			

		}


	}
	public static class CustomLoggingMiddlewareExtension
	{
		//start.cs : app.UseCustoLoggingMiddleware()
		public static IApplicationBuilder UseCustomLoggingMiddleware(this IApplicationBuilder builder)
		{

			return builder.UseMiddleware<CustomLoggingMiddleware>();
		}
	}


}
