using System;
using System.Collections.Generic;
using System.Text;
using TemplateApplication.Data.Context;
using TemplateApplication.Domain.Entities.Logs;
using TemplateApplication.Domain.Repositories;

namespace TemplateApplication.Data.Repositories
{
    public class ApplicationLogRepository : BaseRepository<ApplicationLog>, IApplicationLogRepository
    {
        protected readonly DatabaseContext context;

        public ApplicationLogRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
            this.context.Set<ApplicationLog>();
        }
    }
}
