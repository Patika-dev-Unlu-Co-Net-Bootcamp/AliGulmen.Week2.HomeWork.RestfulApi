using Microsoft.AspNetCore.Builder;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Middlewares
{
    public static class CustomLoggingMiddlewareExtension
	{
		// to use in start.cs : app.UseCustomLoggingMiddleware() instead of app.UseMiddleware<CustomLoggingMiddleware>();
		public static IApplicationBuilder UseCustomLoggingMiddleware(this IApplicationBuilder builder)
		{

			return builder.UseMiddleware<CustomLoggingMiddleware>();
		}
	}


}
