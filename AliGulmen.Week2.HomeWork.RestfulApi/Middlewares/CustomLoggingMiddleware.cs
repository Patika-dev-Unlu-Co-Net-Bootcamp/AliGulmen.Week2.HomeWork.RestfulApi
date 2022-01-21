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
			//instead of using seperate handlers on controller, we can write a try catch block for global exception here..
			try
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
			catch (Exception ex)
			{
				await HandleException(context, ex);
			}

		}


		//global exception
		private Task HandleException(HttpContext context, Exception ex)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //500 if unexpected
			string message = "[ERROR] HTTP "
				+ context.Request.Method
				+ " - "
				+ context.Response.StatusCode
				+ " Error Message " + ex.Message;
			 Console.WriteLine(message);

			//Use Newtonsoft to serialize ex.Message to json and return to client
			var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
			return context.Response.WriteAsync(result);
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
