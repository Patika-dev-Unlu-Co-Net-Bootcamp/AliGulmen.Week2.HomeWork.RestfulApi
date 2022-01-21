namespace AliGulmen.Week2.HomeWork.RestfulApi.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;


    // This middleware will be used for global exception
    public class CustomGlobalException
    {

        private readonly RequestDelegate _next;

        public CustomGlobalException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //instead of using seperate handlers on controller, we can write a try catch block for global exception here..
            try
            {
                await _next(context);

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


}




