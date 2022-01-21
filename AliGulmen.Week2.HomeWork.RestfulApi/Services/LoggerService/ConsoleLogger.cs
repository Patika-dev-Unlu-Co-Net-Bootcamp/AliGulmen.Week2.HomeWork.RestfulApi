using System;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Services.LoggerService
{
    public class ConsoleLogger : ILoggerService
    {
        //log actions to console
        public void Log(string message)
        {
            Console.WriteLine("[ConsoleLogger] - " + message);
        }
    }
}
