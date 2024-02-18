using CleanArchitectureBlazor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureBlazor.Infrastructure.Configurations
{
    internal class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.Birthdate).IsRequired();

#warning example - fake data
            builder.HasData(
                new Animal(1, "Rex", new DateTime(2022, 1, 10)),
                new Animal(2, "Scooby", new DateTime(2000, 5, 25))
            );
        }
    }
}
