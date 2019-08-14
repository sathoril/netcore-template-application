using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApplication.Domain.Entities.Logs
{
    public class ExceptionLog
    {
        public Int32 Id { get; private set; }
        public Int32 StatusCode { get; private set; }
        public String TraceId { get; private set; }
        public String Message { get; private set; }
        public String InnerException { get; private set; }
        public String Source { get; private set; }
        public String StackTrace { get; private set; }
        public DateTime ErrorTime { get; private set; }

        public ExceptionLog(int statusCode, string traceId, string message, string innerException, string source, string stackTrace, DateTime errorTime)
        {
            this.StatusCode = statusCode;
            this.TraceId = traceId;
            this.Message = message;
            this.InnerException = innerException;
            this.Source = source;
            this.StackTrace = stackTrace;
            this.ErrorTime = errorTime;
        }
    }
}
