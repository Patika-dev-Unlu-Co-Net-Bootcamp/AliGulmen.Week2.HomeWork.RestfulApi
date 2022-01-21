using System;
using System.IO;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Services.LoggerService
{
    //log actions to file 
    public class TextFileLogger : ILoggerService
    {
        public void Log(string message)
        {
            using (StreamWriter writer = File.AppendText("actions.log"))
            {
                writer.WriteLine("[TextFileLogger] - " + message);
            }

        }
    }
}
