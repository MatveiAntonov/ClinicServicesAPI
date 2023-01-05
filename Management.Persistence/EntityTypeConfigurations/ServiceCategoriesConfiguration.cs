using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Management.Domain.Entities;

namespace Management.Persistence.EntityTypeConfigurations {
    public class ServiceCategoriesConfiguration : IEntityTypeConfiguration<ServiceCategory> {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder) {
            builder.HasKey(serviceCategory => serviceCategory.ServiceCategoryId);
            builder.HasIndex(serviceCategory => serviceCategory.ServiceCategoryId).IsUnique();
            builder.Property(serviceCategory => serviceCategory.ServiceCategoryName).HasMaxLength(350)
                .IsRequired();
            builder.Property(serviceCategory => serviceCategory.TimeSlotSize).HasColumnType("smalldatetime")
                .IsRequired(false);
        }
    }
}
