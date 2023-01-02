using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Management.Domain.Entities;

namespace Management.Persistence.EntityTypeConfigurations {
    public class SpecializationsConfiguration : IEntityTypeConfiguration<Specialization> {
        public void Configure(EntityTypeBuilder<Specialization> builder) {
            builder.HasKey(specialization => specialization.SpecializationId);
            builder.HasIndex(specialization => specialization.SpecializationId).IsUnique();
            builder.Property(specialization => specialization.SpecializationName).HasMaxLength(350)
                .IsRequired();
        }
    }
}
