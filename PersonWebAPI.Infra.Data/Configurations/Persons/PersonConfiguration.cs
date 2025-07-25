using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonWebAPI.Infra.Data.Configurations.Persons
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.HasKey(p => p.ID);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Mobile)
                .IsRequired()
                .IsUnicode() 
                .HasMaxLength(11);

            builder.Property(p => p.City)
                .HasMaxLength(100);

            builder.Property(p => p.Address)
                .HasMaxLength(250);

            builder.Property(p => p.Email)
                .HasMaxLength(100);

            builder.Property(p => p.Age)
                .HasColumnType("integer");

        }
    }
}
