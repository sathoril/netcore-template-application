using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateApplication.Domain.Entities;

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
