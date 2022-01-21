namespace AliGulmen.Week2.HomeWork.RestfulApi.Services.LoggerService
{
    //This service created to use in middlewares to reduce dependencies. instead of using console writeline, this service will be used and change whenever we want.
    public interface ILoggerService
        {
            public void Log(string message);
        }
    
}
