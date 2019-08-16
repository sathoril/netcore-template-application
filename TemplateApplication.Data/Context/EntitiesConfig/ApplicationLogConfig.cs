using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateApplication.Domain.Entities.Logs;

namespace TemplateApplication.Data.Context.EntitiesConfig
{
    public class LogConfig : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("LOG");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.LogType).HasColumnName("LOG_TYPE");
            builder.Property(p => p.Message).HasColumnName("MESSAGE");
            builder.Property(p => p.LogTime).HasColumnName("LOG_TIME");
        }
    }
}
