using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApplication.Domain.Entities.Logs
{
    public class ApplicationLog
    {
        public Int32 Id { get; set; }
        public String Message { get; set; }
        public DateTime LogTime { get; set; }

        public ApplicationLog(string message)
        {
            this.Message = message;
            this.LogTime = DateTime.Now;
        }
    }
}
