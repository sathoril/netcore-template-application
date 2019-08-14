using System;
using System.Collections.Generic;
using System.Text;
using TemplateApplication.Domain.Entities;
using TemplateApplication.Domain.Entities.Logs;
using TemplateApplication.Domain.Repositories;
using TemplateApplication.Domain.Repositories.Interfaces;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.Domain.Services
{
    public class LogService<T> : BaseService<T>, ILogService<T> where T : class
    {
        private readonly IExceptionLogRepository exceptionLogRepository;
        private readonly IApplicationLogRepository applicationLogRepository;
        private readonly IBaseRepository<T> baseRepository;
        public LogService(IExceptionLogRepository exceptionLogRepository, IApplicationLogRepository applicationLogRepository) : base(exceptionLogRepository)
        {
            this.baseRepository = baseRepository;
            //if(typeof(T) == typeof(ExceptionLog))
            //    this.exceptionLogRepository = (IExceptionLogRepository)baseRepository;

            //if (typeof(T) == typeof(ApplicationLog))
            //    this.applicationLogRepository = (IApplicationLogRepository)baseRepository;
        }

        private ExceptionLog exceptionLog;
        private ApplicationLog applicationLog;

        public void LogApplicationInfo(string message)
        {
            this.applicationLog = new ApplicationLog(message);
            this.baseRepository.Add(this.applicationLog);
        }

        public void LogException(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
