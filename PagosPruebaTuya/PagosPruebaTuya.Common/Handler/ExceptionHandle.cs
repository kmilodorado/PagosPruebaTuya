using PagosPruebaTuya.Common.Enviroments;
using PagosPruebaTuya.Common.Utils.LoggerTy;
using PagosPruebaTuya.Dto.Config.Common;
using System.Net;

namespace PagosPruebaTuya.Common.Handler
{
    public class ExceptionHandle
    {
        private readonly ILoggerTy<ExceptionHandle> _loggerTy;

        public ExceptionHandle(ILoggerTy<ExceptionHandle> loggerTy)
        {
            _loggerTy = loggerTy ?? throw new ArgumentNullException(nameof(loggerTy));
        }

        public HttpResponseErrorDto GenerateException(Exception ex)
        {
            _ = _loggerTy.SetError(ex);
            if (ex is StatusCodeException)
                return new HttpResponseErrorDto()
                {
                    Codigo = ValidateStatus(ex),
                    Mensaje = ex.Message
                };
            else if (!Variables.DEBUG && !(ex is BusinessException))
                return new HttpResponseErrorDto()
                {
                    Codigo = (int)HttpStatusCode.InternalServerError,
                    Mensaje = Variables.Message.ERROR_GENERAL
                };

            return new HttpResponseErrorDto()
            {
                Codigo = (int)HttpStatusCode.InternalServerError,
                Mensaje = ex.Message
            };
        }

        #region private
        private static int ValidateStatus(Exception ex)
        {
            return ex.HResult != 0 ? ex.HResult : (int)HttpStatusCode.InternalServerError;
        }
        #endregion
    }
}
