using CarStoreCore.Models;
using CarStoreDataAccess.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStoreDataAccess.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Name)
                .HasMaxLength(Car.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(c => c.Model)
                .HasMaxLength(Car.MAX_MODEL_LENGTH)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(Car.MAX_DISCRIPTION_LENGTH);

            builder.Property(c => c.Price)
                .IsRequired();

        }
    }
}
