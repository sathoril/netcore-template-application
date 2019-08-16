using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TemplateApplication.Domain.Helpers;

namespace TemplateApplication.Domain.Entities.Logs
{
    public class Log
    {
        public Log() { }

        public Int32 Id { get; set; }
        public Int32 LogType { get; private set; }
        public String Message { get; private set; }
        public DateTime LogTime { get; private set; }

        public Log(string message, LogTypeEnumerator logType)
            : this(message, logType, new Exception()) { }

        public Log(LogTypeEnumerator logType, Exception ex)
            : this(ex.Message, logType, ex) { }

        public Log(string message, LogTypeEnumerator logType, Exception ex)
        {
            this.LogType = (Int32)logType;
            this.LogTime = DateTime.Now;

            if (this.LogType == (Int32)LogTypeEnumerator.ApplicationLog)
                this.CreateApplicationLogMessage(message);
            else
                this.CreateExceptionLogMessage(message, ex);
        }

        private void CreateExceptionLogMessage(string message, Exception ex)
        {
            var json = new
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = ex.Message,
                InnerException = ex.InnerException,
                Source = ex.Source,
                StackTrace = ex.StackTrace
            };

            this.Message = JsonConvert.SerializeObject(json);
        }

        private void CreateApplicationLogMessage(string message)
        {
            this.Message = $"-- {this.LogTime.ToString("dd/MM/yyyy hh:mm:ss")} {message} --";
        }
    }
}
