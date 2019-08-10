using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApplication.Data.Context
{
    public class DatabaseContext : DbContext
    {
        // Here just configure your entities
        // public DbSet<MyEntity> MyProperty { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Here just configure your entities
            // modelBuilder.ApplyConfiguration(new YourEntityConfig());
        }
    }
}
