using Microsoft.EntityFrameworkCore;
using Management.Application.Interfaces;
using Management.Domain.Entities;
using Management.Persistence.EntityTypeConfigurations;

namespace Management.Persistence {
    public class ManagementDbContext : DbContext {
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new ServicesConfiguration());
            builder.ApplyConfiguration(new ServiceCategoriesConfiguration());
            builder.ApplyConfiguration(new SpecializationsConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
