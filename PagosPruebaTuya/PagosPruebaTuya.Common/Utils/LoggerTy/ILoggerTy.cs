namespace PagosPruebaTuya.Common.Utils.LoggerTy
{
    public interface ILoggerTy<TCategoryName>
    {
        Task<bool> SetError(Exception ex);
        Task<bool> SetLog(string message);
    }
}
