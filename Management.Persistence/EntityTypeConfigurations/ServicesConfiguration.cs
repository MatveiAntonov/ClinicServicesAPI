using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Management.Domain.Entities;

namespace Management.Persistence.EntityTypeConfigurations {
    public class ServicesConfiguration : IEntityTypeConfiguration<Service> {
        public void Configure(EntityTypeBuilder<Service> builder) {
            builder.HasKey(service => service.ServiceId);
            builder.HasIndex(service => service.ServiceId).IsUnique();
            builder.Property(service => service.ServiceName).HasMaxLength(350)
                .IsRequired();
            builder.Property(service => service.SpecializationId).IsRequired(false);
            builder.Property(service => service.ServiceCategoryId).IsRequired();
            builder.Property(service => service.ServicePrice).HasColumnType("decimal(10,2)")
                .IsRequired(false);
            builder.HasOne(service => service.ServiceCategory)
                .WithMany(category => category.Services)
                .HasForeignKey(service => service.ServiceCategoryId);
            builder.HasOne(service => service.Specialization)
                .WithMany(specialization => specialization.Services)
                .HasForeignKey(service => service.SpecializationId);
        }
    }
}
