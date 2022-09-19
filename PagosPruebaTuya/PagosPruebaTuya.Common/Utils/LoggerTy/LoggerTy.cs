using Microsoft.Extensions.Logging;

namespace PagosPruebaTuya.Common.Utils.LoggerTy
{
    public class LoggerTy<TCategoryName> : ILoggerTy<TCategoryName>
    {
        private readonly ILogger<TCategoryName> _loggerTy;

        public LoggerTy(ILogger<TCategoryName> loggerTy)
        {
            _loggerTy = loggerTy ?? throw new ArgumentNullException(nameof(loggerTy));
        }

        public Task<bool> SetError(Exception ex)
        {
            Console.WriteLine(ex.Message);
            _loggerTy.LogError(ex, ex.Message);
            return Task.FromResult(true);
        }

        public Task<bool> SetLog(string message)
        {
            Console.WriteLine(message);
            _loggerTy.LogInformation(message);
            return Task.FromResult(true);
        }
    }
}
