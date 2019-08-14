using System;
using System.Collections.Generic;
using System.Text;
using TemplateApplication.Domain.Entities.Logs;
using TemplateApplication.Domain.Repositories.Interfaces;

namespace TemplateApplication.Domain.Repositories
{
    public interface IApplicationLogRepository : IBaseRepository<ApplicationLog>
    {
    }
}
