using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApplication.Domain.Services.Interfaces
{
    public interface ILogService
    {
        void LogException(Exception ex);
        void LogApplicationInfo(string message);
    }
}
