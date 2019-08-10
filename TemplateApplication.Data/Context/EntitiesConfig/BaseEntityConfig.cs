using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateApplication.Data.Entities;

namespace TemplateApplication.Data.Context.EntitiesConfig
{
    public static class BaseEntityConfig
    {
        public static void SetBasicConfigurations<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.CreationUser).HasColumnName("CREATION_USER");
            builder.Property(p => p.CreationDate).HasColumnName("CREATION_DATE");
            builder.Property(p => p.ModifiedUser).HasColumnName("MODIFIED_USER");
            builder.Property(p => p.ModifiedDate).HasColumnName("MODIFIED_DATE");
            builder.Property(p => p.Active).HasColumnName("ACTIVE");
        }
    }
}
