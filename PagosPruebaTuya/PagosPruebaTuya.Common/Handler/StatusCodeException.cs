using System.Net;
using System.Runtime.Serialization;

namespace PagosPruebaTuya.Common.Handler
{
    [Serializable()]
    public class StatusCodeException : Exception
    {
        public StatusCodeException() : base() { }
        public StatusCodeException(HttpStatusCode httpStatusCode, string message) : base(message) { this.HResult = (int)httpStatusCode; }
        public StatusCodeException(string message, Exception inner) : base(message, inner) { }
        protected StatusCodeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
