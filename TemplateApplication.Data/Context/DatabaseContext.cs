using Microsoft.EntityFrameworkCore;
using TemplateApplication.Data.Context.EntitiesConfig;
using TemplateApplication.Domain.Entities;
using TemplateApplication.Domain.Entities.Logs;

namespace TemplateApplication.Data.Context
{
    public class DatabaseContext : DbContext
    {
        // Here just configure your entities
        public DbSet<User> User { get; set; }
        public DbSet<ApplicationLog> ApplicationLog { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Here just configure your entities
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ApplicationLogConfig());
        }
    }
}
