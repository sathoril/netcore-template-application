using System;
using TemplateApplication.Domain.Entities.Logs;
using TemplateApplication.Domain.Helpers;
using TemplateApplication.Domain.Repositories.Interfaces;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.Domain.Services
{
    public class LogService : BaseService<Log>, ILogService
    {
        private readonly IBaseRepository<Log> logRepository;

        public LogService(IBaseRepository<Log> logRepository) : base(logRepository)
        {
            this.logRepository = logRepository;
        }

        public void LogApplicationInfo(string message)
        {
            var applicationLog = new Log(message, LogTypeEnumerator.ApplicationLog);
            this.logRepository.Add(applicationLog);
        }

        public void LogException(Exception ex)
        {
            var exceptionLog = new Log(LogTypeEnumerator.ExceptionLog, ex);
            this.logRepository.Add(exceptionLog);
        }
    }
}
