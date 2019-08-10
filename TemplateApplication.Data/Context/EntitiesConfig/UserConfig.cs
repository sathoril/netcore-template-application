using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateApplication.Data.Entities;

namespace TemplateApplication.Data.Context.EntitiesConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USUARIO");
            builder.Property(p => p.Name).HasColumnName("NOME");

            BaseEntityConfig.SetBasicConfigurations(builder);
        }
    }
}
