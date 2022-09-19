using System.Runtime.Serialization;

namespace PagosPruebaTuya.Common.Handler
{
    [Serializable()]
    public class BusinessException: Exception
    {
        public BusinessException() : base() { }
        public BusinessException(string message) : base(message) {}
        public BusinessException(string message, Exception inner) : base(message, inner) { }
        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
